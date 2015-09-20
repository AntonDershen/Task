using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;
using DataAccess.Interface.EntityFramework;
using System.Web;
namespace DataAccess.Lucene
{
    public static class LuceneSearch
    {
        private static string luceneDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lucene_index");
        private static FSDirectory directoryTemp;
        private static FSDirectory directory
        {
            get
            {
                if (directoryTemp == null) directoryTemp = FSDirectory.Open(new DirectoryInfo(luceneDir));
                if (IndexWriter.IsLocked(directoryTemp)) IndexWriter.Unlock(directoryTemp);
                var lockFilePath = Path.Combine(luceneDir, "write.lock");
                if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
                return directoryTemp;
            }
        }
        private static void addToLuceneIndex(Task taskData, IndexWriter writer)
        {
            var searchQuery = new TermQuery(new Term("Id", taskData.Id.ToString()));
            writer.DeleteDocuments(searchQuery);
            var doc = new Document();
            doc.Add(new Field("Id", taskData.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Name", taskData.Name, Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Condition", taskData.Condition, Field.Store.YES, Field.Index.ANALYZED));
            writer.AddDocument(doc);
        }
        public static void AddUpdateLuceneIndex(IEnumerable<Task> taskDatas)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);
            using (var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                foreach (var sampleData in taskDatas) addToLuceneIndex(sampleData, writer);
                analyzer.Close();
                writer.Dispose();
            }
        }
        public static void AddUpdateLuceneIndex(Task taskData)
        {
            AddUpdateLuceneIndex(new List<Task> { taskData });
        }
        public static void ClearLuceneIndexRecord(int recordId)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);
            using (var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                
                var searchQuery = new TermQuery(new Term("Id", recordId.ToString()));
                writer.DeleteDocuments(searchQuery);
                analyzer.Close();
                writer.Dispose();
            }
        }
        public static bool ClearLuceneIndex()
        {
            try
            {
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);
                using (var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    writer.DeleteAll();
                    analyzer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static void Optimize()
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);
            using (var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                analyzer.Close();
                writer.Optimize();
                writer.Dispose();
            }
        }
        private static Task mapLuceneDocumentToData(Document doc)
        {
            return new Task
            {
                Id = Convert.ToInt32(doc.Get("Id")),
                Name = doc.Get("Name"),
                Condition = doc.Get("Condition")
            };
        }
        private static IEnumerable<Task> mapLuceneToDataList(IEnumerable<Document> hits)
        {
            return hits.Select(mapLuceneDocumentToData).ToList();
        }
        private static IEnumerable<Task> mapLuceneToDataList(IEnumerable<ScoreDoc> hits,
            IndexSearcher searcher)
        {
            return hits.Select(hit => mapLuceneDocumentToData(searcher.Doc(hit.Doc))).ToList();
        }
        private static Query parseQuery(string searchQuery, QueryParser parser)
        {
            Query query;
            try
            {
                query = parser.Parse(searchQuery.Trim());
            }
            catch (ParseException)
            {
                query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
            }
            return query;
        }
        private static IEnumerable<Task> privateSearch(string searchQuery, string searchField = "")
        {
            if (string.IsNullOrEmpty(searchQuery.Replace("*", "").Replace("?", ""))) return new List<Task>();

            using (var searcher = new IndexSearcher(directory, false))
            {
                var hits_limit = 1000;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);
                if (!string.IsNullOrEmpty(searchField))
                {
                    var parser = new QueryParser(Version.LUCENE_30, searchField, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    var hits = searcher.Search(query, hits_limit).ScoreDocs;
                    var results = mapLuceneToDataList(hits, searcher);
                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
                else
                {
                    var parser = new MultiFieldQueryParser
                        (Version.LUCENE_30, new[] { "Id", "Name", "Condition" }, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    var hits = searcher.Search
                    (query, null, hits_limit, Sort.RELEVANCE).ScoreDocs;
                    var results = mapLuceneToDataList(hits, searcher);
                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
            }
        }
        public static IEnumerable<Task> Search(string input, string fieldName = "")
        {
            if (string.IsNullOrEmpty(input)) return new List<Task>();

            var terms = input.Trim().Replace("-", " ").Split(' ')
                .Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
            input = string.Join(" ", terms);

            return privateSearch(input, fieldName);
        }
        public static IEnumerable<Task> GetAllIndexRecords()
        {
            if (!System.IO.Directory.EnumerateFiles(luceneDir).Any()) return new List<Task>();
            var searcher = new IndexSearcher(directory, false);
            var reader = IndexReader.Open(directory, false);
            var docs = new List<Document>();
            var term = reader.TermDocs();
            while (term.Next()) docs.Add(searcher.Doc(term.Doc));
            reader.Dispose();
            searcher.Dispose();
            return mapLuceneToDataList(docs);
        }
    }
}

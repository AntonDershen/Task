using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
using DataAccess.Interface.Repository;
using System.Data.Entity;

namespace DataAccess.Repository
{
    public class TagRepository : ITagRepository
    {
        private  DbContext context;
        public TagRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(string tagName)
        {
            context.Set<Tag>().Add(new Tag()
            {
                Name = tagName
            });
        }
        public Tag GetTag(string tagName)
        {
            try
            {
                return context.Set<Tag>().FirstOrDefault(x => x.Name == tagName);
            }
            catch { return null; }
        }
        public IEnumerable<string> GetTagsName(string tagName)
        {
           return context.Set<Tag>().Where(x => x.Name.Contains(tagName)).Select(x => x.Name);
        }
    }
}

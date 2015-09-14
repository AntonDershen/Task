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
    public class CommentRepository : ICommentRepository
    {
        private DbContext context;
        public CommentRepository(DbContext context)
        {
            this.context = context;
        }
        public void CreateComment(Comment comment)
        {
            context.Set<Comment>().Add(comment);
        }
        public IEnumerable<Comment> Get(Func<Comment, bool> predicate)
        {
            return context.Set<Comment>().Where(predicate);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}

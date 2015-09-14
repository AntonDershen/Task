using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Interface.Repository
{
    public interface ICommentRepository :IDisposable
    {
        void CreateComment(Comment comment);
        IEnumerable<Comment> Get(Func<Comment, bool> predicate);
    }
}

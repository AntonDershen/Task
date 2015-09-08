using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Interface.Repository
{
    public interface ITagRepository
    {
        void Create(string tagName);
        Tag GetTag(string tagName);
        IEnumerable<string> GetTagsName(string tagName);
    }
}

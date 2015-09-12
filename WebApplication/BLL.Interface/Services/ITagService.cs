using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
namespace BusinessLogic.Interface.Services
{
    public interface ITagService
    {
        int CreateTag(string tagName);
        IEnumerable<int> CreateTags(List<string> tags);
        IEnumerable<string> GetTags(string tagsName);
        IEnumerable<string> GetRandomTags(int count);
    }
}

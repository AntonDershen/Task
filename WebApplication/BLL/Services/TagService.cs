using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
using BusinessLogic.Mapper;
using BusinessLogic.Interface.Services;
using DataAccess.Interface.Repository;
namespace BusinessLogic.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;
        public TagService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public int CreateTag(string name)
        {
            var currentName = unitOfWork.TagRepository.GetTag(name);
            if (currentName != null)
                return currentName.Id;
            unitOfWork.TagRepository.Create(name);
            unitOfWork.Save();
            return unitOfWork.TagRepository.GetTag(name).Id;
        }
        public IEnumerable<int> CreateTags(List<string> tags)
        {
            List<int> tagsId = new List<int>();
            foreach (var tag in tags)
                tagsId.Add(this.CreateTag(tag));
            return tagsId;
        }
        public IEnumerable<string> GetTags(string tag)
        {
            return unitOfWork.TagRepository.GetTagsName(tag);
        }
        public IEnumerable<string> GetRandomTags(int count)
        {
            int tagsCount = unitOfWork.TagRepository.GetTagsCount();
            if (tagsCount <= count)
                return unitOfWork.TagRepository.GetRandomTags(0, tagsCount);
            Random random = new Random();
            int begin = (int)(random.NextDouble()*tagsCount);
            return unitOfWork.TagRepository.GetRandomTags(Math.Abs(begin + count - tagsCount), count);
        }
    }
}

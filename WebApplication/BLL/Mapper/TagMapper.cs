using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
namespace BusinessLogic.Mapper
{
    public static class TagMapper
    {
        public static TagEntity ToTagEntity(this Tag tag)
        {
            return new TagEntity()
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }
        public static Tag ToDataTransferTag(this TagEntity tagEntity)
        {
            return new Tag()
            {
                Id = tagEntity.Id,
                Name = tagEntity.Name
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.DataTransfer;
using ORM;
namespace DataAccess.Mapper
{
    public static class TagsMapper
    {
        public static Tag ToTag(this DataTransferTag dataTransferTag)
        {
            return new Tag()
            {
                Id = dataTransferTag.Id,
                Name = dataTransferTag.Name
            };
        }
        public static DataTransferTag ToDataTransferTag(this Tag tag)
        {
            return new DataTransferTag()
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }
    }
}

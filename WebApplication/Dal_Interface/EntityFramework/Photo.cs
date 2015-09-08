using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class Photo
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}

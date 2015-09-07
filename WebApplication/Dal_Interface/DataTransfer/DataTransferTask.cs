using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  DataAccess.Interface.DataTransfer
{
    public class DataTransferTask : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Complexity { get; set; }
        public string Category { get; set; }
        public int CreateUserId { get; set; }
        public double Rate { get; set; }
        public virtual ICollection<DataTransferComment> Comments { get; set; }
        public virtual ICollection<DataTransferUser> Users { get; set; }
        public virtual ICollection<DataTransferTag> Tags { get; set; }
        public virtual ICollection<DataTransferAnswer> Answers { get; set; }
    }
}

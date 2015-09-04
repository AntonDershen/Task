using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.DataTransfer
{
    public class DataTransferUser : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.DataTransfer
{
    public class DataTransferComment : IEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
    }
}

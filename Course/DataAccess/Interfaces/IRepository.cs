using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Find(int id);
        IEnumerable<T> Get(Func<T, Boolean> predicate);
        void Create(T item);
        void Delete(int id);
    }
}

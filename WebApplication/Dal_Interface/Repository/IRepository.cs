using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Interface.DataTransfer;
namespace DataAccess.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(int Id);
        void Create(TEntity e);
        void Delete(TEntity e);
        void Update(TEntity e);
        IEnumerable<TEntity> GetAll(Func<TEntity, Boolean> predicate);
        TEntity Get(Func<TEntity, Boolean> predicate);
    }
}

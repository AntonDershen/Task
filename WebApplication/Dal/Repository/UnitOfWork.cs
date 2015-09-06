using System;
using System.Data.Entity;
using System.Diagnostics;
using DataAccess.Interface.Repository;
using DataAccess.Interface.DataTransfer;
using ORM;
namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context{get;private set;}
        private IRepository<DataTransferAuthorization> authorizationRepository;
        private  IUserRepository userRepository;
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public IRepository<DataTransferAuthorization> AuthorizationRepository
        {
            get
            {
                if (authorizationRepository == null)
                    authorizationRepository = new AuthorizationRepository(Context);
                return authorizationRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(Context);
                return userRepository;
            }
        }
        public void Save()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();

            }
        }
     
    }
}
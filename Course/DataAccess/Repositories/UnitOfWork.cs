using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.EntityFramework;
using DataAccess.Entities;
namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext context;
        private IRepository<User> userRepository;
        private IRepository<Authorization> authorizationRepository;
        public UnitOfWork(string connectionString) {
            context = new DatabaseContext(connectionString);
        }
        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }
        public IRepository<Authorization> AuthorizationRepository
        {
            get
            {
                if (authorizationRepository == null)
                    authorizationRepository = new AuthorizationRepository(context);
                return authorizationRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface.DataTransfer;
using DataAccess.Interface.Repository;
using ORM;
using System.Data.Entity;
using DataAccess.Mapper;
namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
        {
            private DbContext context;
            public UserRepository(DbContext context)
                {
                    this.context = context;
                }
            public DataTransferUser Find(int id)
            {
                User user = context.Set<User>().Find(id);
                return user.ToDataTransferUser();
            }
            public IEnumerable<DataTransferUser> GetAll()
            {
                return context.Set<User>().Select(user => user.ToDataTransferUser());
            }
            public void Create(DataTransferUser dataTransferUser)
            {
                context.Set<User>().Add(dataTransferUser.ToUser());
     
            }
            public void Update(DataTransferUser dataTransferUser)
            {
                var user = context.Set<User>().Find(dataTransferUser.Id);
                user.UserName = dataTransferUser.UserName;

            }
            public void Delete(DataTransferUser dataTransferUser)
            {
                User user = dataTransferUser.ToUser();
                user = context.Set<User>().Single(u => u.Id == user.Id);
                context.Set<User>().Remove(user);
            }
            public IEnumerable<DataTransferUser> GetAll(Func<DataTransferUser, Boolean> predicate)
            {
                return context.Set<User>().Select(x => x.ToDataTransferUser()).Where(predicate);
            }
            public DataTransferUser Get(Func<DataTransferUser, Boolean> predicate)
            {
                try
                {
                    var users = context.Set<User>().ToList();
                    DataTransferUser user = null;
                    user = users.Select(x=>x.ToDataTransferUser()).FirstOrDefault(predicate);
                    return user;
                }
                catch
                {
                    return null;
                }
            }
            public IEnumerable<DataTransferAuthorization> GetAuthorization(int id)
            {
                return context.Set<User>().Find(id).Authorizations.Select(x => x.ToDataTransferAuthorization());
            }
            public void Dispose()
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }
}

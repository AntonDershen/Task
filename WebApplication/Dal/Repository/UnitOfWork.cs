using System;
using System.Data.Entity;
using System.Diagnostics;
using DataAccess.Interface.Repository;
using DataAccess.Interface.EntityFramework;
namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context{get;private set;}
        private IRepository<Authorization> authorizationRepository;
        private IUserRepository userRepository;
        private ITaskRepository taskRepository;
        private ITagRepository tagRepository;
        private IAnswerRepository answerRepository;
        private IPhotoRepository photoRepository;
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public IRepository<Authorization> AuthorizationRepository
        {
            get
            {
                if (authorizationRepository == null)
                    authorizationRepository = new AuthorizationRepository(Context);
                return authorizationRepository;
            }
        }
        public ITaskRepository TaskRepository
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(Context);
                return taskRepository;
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
        public ITagRepository TagRepository
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(Context);
                return tagRepository;
            }
        }
        public IAnswerRepository AnswerRepository
        {
            get
            {
                if (answerRepository == null)
                    answerRepository = new AnswerRepository(Context);
                return answerRepository;
            }
        }
        public IPhotoRepository PhotoRepository
        {
            get
            {
                if (photoRepository == null)
                    photoRepository = new PhotoRepository(Context);
                return photoRepository;
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
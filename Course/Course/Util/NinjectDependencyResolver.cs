using System.Web.Mvc;
using Ninject;
using System.Collections.Generic;
using System;
using BusinessLogic.Service;
using BusinessLogic.Interfaces;
namespace Course.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel ;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUserService>().To<UserService>();
        }
    }
}
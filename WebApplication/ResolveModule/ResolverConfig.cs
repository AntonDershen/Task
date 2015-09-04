using System.Data.Entity;
using BusinessLogic.Interface.Services;
using BusinessLogic.Services;
using DataAccess.Repository;
using DataAccess.Interface.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;
using DataAccess.Interface.DataTransfer;

namespace ResolverConfig
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRepository<DataTransferUser>>().To<UserRepository>();

            kernel.Bind<IAuthorizationService>().To<AuthorizationServices>();
            kernel.Bind<IRepository<DataTransferAuthorization>>().To<AuthorizationRepository>();
        }
    }
}
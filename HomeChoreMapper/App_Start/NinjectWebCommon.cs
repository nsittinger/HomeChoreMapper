using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ChoreMapper.App_Start;
using HomeChoreMapper.DAL;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace ChoreMapper.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserDal>().To<UserSqlDAL>().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["choresDB"].ConnectionString);
            kernel.Bind<IHomeDal>().To<HomeSqlDAL>().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["choresDB"].ConnectionString);
            kernel.Bind<IChoreDal>().To<ChoreSqlDAL>().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["choresDB"].ConnectionString);
            kernel.Bind<IHomeUsersChoresDAL>().To<HomeUsersChoresSqlDAL>().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["choresDB"].ConnectionString);
        }
    }
}
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Angular_WebApi_Staff.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Angular_WebApi_Staff.App_Start.NinjectWebCommon), "Stop")]

namespace Angular_WebApi_Staff.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Core.Services;
    using DAL.Repositories;
    using DAL.UnitOfWork;
    using DAL.Infrastructure;
    using DAL;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IService<Employee>>().To<EmployeeService>().InRequestScope();
            kernel.Bind<IService<JobTitle>>().To<JobTitleService>().InRequestScope();

            kernel.Bind<IRepository<Employee>>().To<EmployeeRepository>().InRequestScope();
            kernel.Bind<IRepository<JobTitle>>().To<JobTitleRepository>().InRequestScope();

            kernel.Bind<IDBUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IDbFactory>().To<DbFactory>().InRequestScope();
        }        
    }
}

using MagazineProject.Data.Repository;
using MagazineProject.Web.Infrastructure.Sanitizer;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MagazineProject.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MagazineProject.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MagazineProject.Web.App_Start
{
    using System;
    using System.Web;
    using System.Data.Entity;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using MagazineProject.Data;
    using MagazineProject.Data.UnitOfWork;
    using MagazineProject.Services;
    using MagazineProject.Services.Administration;
    using MagazineProject.Services.Common;
    using MagazineProject.Services.Common.Data;
    using MagazineProject.Services.Common.Moderator;
    using MagazineProject.Services.Common.User;
    using MagazineProject.Services.Common.Writer;
    using MagazineProject.Services.Moderator;
    using MagazineProject.Services.Users;
    using MagazineProject.Services.Writer;
    using MagazineProject.Web.Infrastructure.Caching;
    using MagazineProject.Web.Infrastructure.Populators;

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
            kernel.Bind<DbContext>().To<MagazineProjectDbContext>();

            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            kernel.Bind<IUnitOfWorkData>().To<UnitOfWorkData>();
            //TODO:IAuditInfo !!!!
            kernel.Bind<ISanitizer>().To<HtmlSanitazerAdapter>();

            kernel.Bind<ICacheService>().To<InMemoryCache>();

            kernel.Bind<IDropDownListPopulator>().To<DropDownListPopulator>();


            kernel.Bind<ICategoriesService>().To<CategoriesService>();
            kernel.Bind<IPostsService>().To<PostsService>();
            kernel.Bind<ICommentsService>().To<CommentsService>();
            kernel.Bind<IImagesService>().To<ImagesService>();
            kernel.Bind<IProfilesService>().To<ProfilesService>();
            kernel.Bind<IWriterPostsService>().To<WriterPostsService>();
            kernel.Bind<IAdministrationPostsService>().To<AdministationPostsService>();
            kernel.Bind<IAdministrationCommentsService>().To<AdministrationCommentsService>();
            kernel.Bind<IAdminCategoriesService>().To<AdminCategoriesService>();

        }
    }
}

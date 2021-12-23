using Autofac;
using Autofac.Integration.Mvc;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;
using System.Web.Mvc;

namespace MvcProjectCamp.DependencyResolvers.Autofac
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerRequest();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerRequest();

            builder.RegisterType<WriterManager>().As<IWriterService>().InstancePerRequest();
            builder.RegisterType<EfWriterDal>().As<IWriterDal>().InstancePerRequest();

            builder.RegisterType<HeadingManager>().As<IHeadingService>().InstancePerRequest();
            builder.RegisterType<EfHeadingDal>().As<IHeadingDal>().InstancePerRequest();

            builder.RegisterType<ContentManager>().As<IContentService>().InstancePerRequest();
            builder.RegisterType<EfContentDal>().As<IContentDal>().InstancePerRequest();

            builder.RegisterType<AboutManager>().As<IAboutService>().InstancePerRequest();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().InstancePerRequest();

            builder.RegisterType<ContactManager>().As<IContactService>().InstancePerRequest();
            builder.RegisterType<EfContactDal>().As<IContactDal>().InstancePerRequest();

            builder.RegisterType<MessageManager>().As<IMessageService>().InstancePerRequest();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>().InstancePerRequest();

            builder.RegisterType<ImageManager>().As<IImageService>().InstancePerRequest();
            builder.RegisterType<EfImageDal>().As<IImageDal>().InstancePerRequest();

            builder.RegisterType<AdminManager>().As<IAdminService>().InstancePerRequest();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}

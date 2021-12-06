using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Mvc;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Entities.Abstract;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.EntityFramework.Concrete;
using MvcProjectCamp.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcProjectCamp.DependencyResolvers.Autofac
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

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

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            //    .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            //    {
            //        Selector = new AspectInterceptorSelector()
            //    }).SingleInstance();


        }
    }
}

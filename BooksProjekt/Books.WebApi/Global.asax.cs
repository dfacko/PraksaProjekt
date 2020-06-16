using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Books.Repository;
using Book.Service;
using Books.WebApi.Controllers;
using AutoMapper;
using Books.Models;
using Books.WebApi.Models;

namespace Books.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<BookController>();
            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<RepositoryModule>();

            /*automapper:*/
            containerBuilder.RegisterType<BookModel>().AsSelf();
            containerBuilder.RegisterType<Models.Book>().AsSelf();

            containerBuilder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap < BookModel, Models.Book>();

            })).AsSelf().SingleInstance();

            containerBuilder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();/*:automapper*/

            var container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

        }
    }
}

using Autofac.Core;
using Books.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Books.Repository;


namespace Books.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);  //ove dvije linije nam ostaju svima isto
            var containerBuilder = new ContainerBuilder();


            containerBuilder.RegisterType<ListController>();
            containerBuilder.RegisterType<BooksListController>();

            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<RepositoryModule>();  // u ove module cete registrirat sto treba



            var container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);


        }
    }
}

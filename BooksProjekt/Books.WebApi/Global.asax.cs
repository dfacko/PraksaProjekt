using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Books.Service;
using Books.Service.Common;
using Books.Repository;
using Books.WebApi.Controllers;
using Book.Service;
using Autofac;
using Autofac.Integration.WebApi;
using Books.Repository.Common;

namespace Books.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);  //ove dvije linije nam ostaju svima isto
            var containerBuilder = new ContainerBuilder();


            //dodano
            containerBuilder.RegisterType<BooksPublisherController>();

            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<RepositoryModule>();  // u ove module cete registrirat sto treba

            var container = containerBuilder.Build(); //i ove dvije isto
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

        }
    }
}

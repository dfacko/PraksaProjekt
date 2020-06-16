using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Book.Service;
using Books.Models;
using Books.Models.Common;
using Books.Service.Common;

namespace Books.Service {
	public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ListService>().As<IListService>();
            builder.RegisterType<BooksListService>().As<IBooksListService>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Books.Service.Common;

namespace Book.Service {
	public class ServiceModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BooksPublisherService>().As<IBooksPublisherService>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Books.Repository.Common;

namespace Books.Repository {
	public class RepositoryModule: Module 
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BooksPublisherRepository>().As<IBooksPublisherRepository>();
            builder.RegisterType<BooksCommentRepository>().As<IBooksCommentRepository>();
        }
    }
}

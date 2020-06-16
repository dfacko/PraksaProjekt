using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;

namespace Books.Service.Common
{
    public interface IBookService
    {
        Task<List<BookModel>> SeeBookListAsync();
    }
}

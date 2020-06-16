using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;

namespace Books.Repository.Common
{
    public interface IBookRepository
    {
        List<BookModel> SeeBookList();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Service.Common;
using Books.Models;
using Books.Repository;

namespace Book.Service
{
    public class BookService : IBookService
    {
        public List<BookModel> BookModelList = new List<BookModel>();

        Books.Repository.BookRepository bookRepository = new Books.Repository.BookRepository();
        public async Task<List<BookModel>> SeeBookListAsync() 
        {
            return bookRepository.SeeBookList();
        }
    }
}

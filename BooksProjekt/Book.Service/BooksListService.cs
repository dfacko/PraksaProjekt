using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;
using Books.Service.Common;

namespace Book.Service
{
    public class BooksListService : IBooksListService
    {
        public async Task<List<BooksList>> GetBooksListAsync()
        {
            
        }


        public async Task<BooksList> GetBooksListByIdAsync(Guid id)
        {

        }


        public async Task<bool> DeleteBooksListByIdAsync(Guid id)
        {

        }


        public async Task<bool> CreateBooksListByIdAsync(BooksList newBooksList, Guid id)
        {

        }


        Task<bool> UpdateBooksListByIdAsync(BooksList updateBooksList, Guid id)
        {

        }

    }
}

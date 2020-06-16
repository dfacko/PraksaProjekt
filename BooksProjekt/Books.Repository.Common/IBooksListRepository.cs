using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;

namespace Books.Repository.Common
{
    public interface IBooksListRepository
    {
        Task<List<BooksList>> GetBooksListAsync();

        Task<BooksList> GetBooksListByIdAsync(Guid id);
        Task<bool> DeleteBooksListByIdAsync(Guid id);
        Task<bool> CreateBooksListByIdAsync(BooksList newBooksList, Guid id);
        Task<bool> UpdateBooksListByIdAsync(BooksList updateBooksList, Guid id);
    }
}

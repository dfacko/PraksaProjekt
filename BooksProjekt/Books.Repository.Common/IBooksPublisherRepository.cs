using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;

namespace Books.Repository.Common
{
    public interface IBooksPublisherRepository
    {
        Task<List<BooksPublisher>> GetBooksPublishersAsync();
        Task<bool> DeleteBooksPublisherByIdAsync(Guid id);
        Task<bool> CreateBooksPublisherByIdAsync(BooksPublisher booksPublisher);

        //Model
        Task<bool> UpdateBooksPublisherByIdAsync(BooksPublisher booksPublisher);
    }
}

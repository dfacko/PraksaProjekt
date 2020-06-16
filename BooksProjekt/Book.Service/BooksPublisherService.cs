using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Service.Common;
using Books.Repository.Common;
using Books.Models;

namespace Book.Service
{
    public class BooksPublisherService: IBooksPublisherService
    {
        #region Constructor
        public BooksPublisherService(IBooksPublisherRepository repository)
        {
            this.Repository = repository;
        }
        #endregion
        protected IBooksPublisherRepository Repository { get; set; }

        public async Task<List<BooksPublisher>> GetBooksPublishersAsync()
        {
            return await Repository.GetBooksPublishersAsync();
        }

        public async Task<bool> DeleteBooksPublisherByIdAsync(Guid id)
        {
            return await Repository.DeleteBooksPublisherByIdAsync(id);
        }

        public async Task<bool> CreateBooksPublisherByIdAsync(BooksPublisher booksPublisher)
        {
            return await Repository.CreateBooksPublisherByIdAsync(booksPublisher);
        }
        public async Task<bool> UpdateBooksPublisherByIdAsync(BooksPublisher booksPublisher)
        {
            return await Repository.UpdateBooksPublisherByIdAsync(booksPublisher);
        }
    }
}

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
    public class BooksCommentService: IBooksCommentService
    {
        #region Constructor
        public BooksCommentService(IBooksCommentRepository repository)
        {
            this.Repository = repository;
        }
        #endregion
        protected IBooksCommentRepository Repository { get; set; }

        public async Task<List<BooksComment>> GetBooksCommentsAsync()
        {
            return await Repository.GetBooksCommentsAsync();
        }

        public async Task<bool> DeleteBooksCommentsByIdAsync(Guid id)
        {
            return await Repository.DeleteBooksCommentsByIdAsync(id);
        }

        public async Task<List<BooksComment>> GetBooksCommentsByIdAsync(Guid id)
        {
            return await Repository.GetBooksCommentsByIdAsync(id);
        }
    }
}

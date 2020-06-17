using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;

namespace Books.Repository.Common
{
    public interface IBooksCommentRepository
    {
        Task<List<BooksComment>> GetBooksCommentsAsync();
        Task<bool> DeleteBooksCommentsByIdAsync(Guid id);
        Task<List<BooksComment>> GetBooksCommentsByIdAsync(Guid id);

        //Task<bool> UpdateBooksCommentsAsync();
    }
}

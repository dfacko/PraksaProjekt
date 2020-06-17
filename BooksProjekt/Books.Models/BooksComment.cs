using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models.Common;
namespace Books.Models
{
    public class BooksComment: IBooksComment
    {
        public Guid CommentId { get; set; }
        public Guid BookId { get; set; }
        public string Content { get; set; }
        public int NumberOfLikes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models.Common
{
    public interface IBooksComment
    {
        Guid CommentId { get; set; }
        Guid BookId { get; set; }
        string Content { get; set; }
        int NumberOfLikes { get; set; }
    }
}

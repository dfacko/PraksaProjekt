using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models.Common;

namespace Books.Models
{
    public class BooksList : IBooksList
    {
        public Guid ListId { get; set; }
        public Guid BookId { get; set; }
    }
}

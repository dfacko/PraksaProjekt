using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models.Common
{
    public interface IBooksList
    {
        Guid ListId { get; set; }
        Guid BookId { get; set; }
        
    }
}

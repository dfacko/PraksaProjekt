using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models.Common
{
    public interface IListGeneral
    {
        Guid ListId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int NumberOfLikes { get; set; }
    }
}

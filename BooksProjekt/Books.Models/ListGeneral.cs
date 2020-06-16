using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models.Common;

namespace Books.Models
{
    public class ListGeneral : IListGeneral
    {
        public Guid ListId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfLikes { get; set; }
    }
}

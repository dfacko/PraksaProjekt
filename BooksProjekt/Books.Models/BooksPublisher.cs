using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models.Common;

namespace Books.Models
{
    public class BooksPublisher:IBooksPublisher
    {
        public Guid PublisherId { get; set; }
        public string Name { get; set; }
        public string Founded { get; set; }
        public string Headquarters { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Distribution { get; set; }
        public string OfficialWebsite { get; set; }

    }
}

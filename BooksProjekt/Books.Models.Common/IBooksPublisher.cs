using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models.Common
{
    public interface IBooksPublisher
    {
        Guid PublisherId { get; set; }
        string Name { get; set; }
        string  Founded { get; set; }
        string Headquarters { get; set; }
        string Location { get; set; }
        string Country { get; set; }
        string Distribution { get; set; }
        string OfficialWebsite{ get; set; }

    }
}

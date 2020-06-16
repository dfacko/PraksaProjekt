using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models.Common
{
    public interface IBookModel
    {
        string Title { get; set; }
        int Year { get; set; }
        int Grade { get; set; }
        int NumberOfPages { get; set; }
        string OriginalLanguage { get; set; }
        string CountryOfOrigin { get; set; }
        string OriginalTitle { get; set; }
    }
}

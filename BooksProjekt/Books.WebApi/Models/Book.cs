using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.WebApi.Models
{
    public class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Grade { get; set; }
        public int NumberOfPages { get; set; }
        public string OriginalLanguage { get; set; }
        public string CountryOfOrigin { get; set; }
        public string OriginalTitle { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Repository.Common;
using Books.Models;
using System.Data.SqlClient;

namespace Books.Repository
{
    public class BooksListRepository : IBooksListRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PRAKSA;Integrated Security=True";
        List<BooksList> booksList = new List<BooksList>();


        public async Task<List<BooksList>> GetBooksListAsync()
        {
            

        }


        
    }
}

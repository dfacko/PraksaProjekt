using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Repository.Common;
using Books.Models;
using System.Data;
using System.Data.SqlClient;

namespace Books.Repository
{
    public class BookRepository : IBookRepository
    {
        public List<BookModel> BookModelList = new List<BookModel>();
        public List<BookModel> SeeBookList()
        {
            string connectionString = @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True";

            string queryString =
                "SELECT Title, Year, Grade, NumberOfPages, OriginalLanguage, CountryOfOrigin, OriginalTitle FROM BOOK;";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    BookModelList.Add(new BookModel { Title = reader.GetString(0), Year = reader.GetInt32(1), Grade = reader.GetInt32(2), NumberOfPages = reader.GetInt32(3), OriginalLanguage = reader.GetString(4), CountryOfOrigin = reader.GetString(5), OriginalTitle = reader.GetString(6) });
                }

                // Call Close when done reading.
                reader.Close();
                return BookModelList;
            }
        }
    }
}

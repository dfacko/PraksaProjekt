using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Books.Models;
using Books.Repository.Common;

namespace Books.Repository
{
    public class BooksPublisherRepository:IBooksPublisherRepository
    {
        string connectionString = @"Data Source=(Localdb)\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True";

        // GET ALL
        public async Task<List<BooksPublisher>> GetBooksPublishersAsync()
        {
            List<BooksPublisher> booksPublishers = new List<BooksPublisher>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM PUBLISHER";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                BooksPublisher publisher = null;
                while (reader.Read())
                {
                    publisher = new BooksPublisher();
                    publisher.PublisherId = reader.GetGuid(0);
                    publisher.Name = reader.GetString(1);
                    publisher.Founded = reader.GetString(2);
                    publisher.Headquarters = reader.GetString(3);
                    publisher.Location = reader.GetString(4);
                    publisher.Country = reader.GetString(5);
                    publisher.Distribution = reader.GetString(6);
                    publisher.OfficialWebsite = reader.GetString(7);
                    booksPublishers.Add(publisher);
                }
                connection.Close();
                return await Task.FromResult(booksPublishers);
            }
        
        }
        //DELETE
        public async Task<bool> DeleteBooksPublisherByIdAsync(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "DELETE FROM Publisher WHERE PublisherID=@Id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                //check if we deleted
                int deleted = command.ExecuteNonQuery();
                connection.Close();
                if (deleted == 0)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);
            }
        }
        //CREATE
        public async Task<bool> CreateBooksPublisherByIdAsync(BooksPublisher booksPublisher)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO Publisher(Name, Founded, Headquarters,Location, Country,Distribution, OfficialWebsite) " + 
                "VALUES(@Name, @Founded, @Headquarters, @Location, @Country, @Distribution, @OfficialWebsite);";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Name", booksPublisher.Name);
                command.Parameters.AddWithValue("@Founded", booksPublisher.Founded);
                command.Parameters.AddWithValue("@Headquarters", booksPublisher.Headquarters);
                command.Parameters.AddWithValue("@Location", booksPublisher.Location);
                command.Parameters.AddWithValue("@Country", booksPublisher.Country);
                command.Parameters.AddWithValue("@Distribution", booksPublisher.Distribution);
                command.Parameters.AddWithValue("@OfficialWebsite", booksPublisher.OfficialWebsite);
                connection.Open();
                //check for insert
                int insert = command.ExecuteNonQuery();
                connection.Close();
                if (insert == 0)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);
            }
        
        }
        //UPDATE
        public async Task<bool> UpdateBooksPublisherByIdAsync(BooksPublisher booksPublisher)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "UPDATE PUBLISHER SET Name = @Name WHERE PublisherID = @Id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Name", booksPublisher.Name);
                command.Parameters.AddWithValue("@Id", booksPublisher.PublisherId);
                connection.Open();
                //check for update
                int update = command.ExecuteNonQuery();
                connection.Close();
                if (update == 0)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);

            }
        }


        //new






    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;
using Books.Repository.Common;
using System.Data.SqlClient;
using System.Data;

namespace Books.Repository
{
    public class BooksCommentRepository: IBooksCommentRepository
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True";

        //GET ALL comments from all books
        public async Task<List<BooksComment>> GetBooksCommentsAsync()
        {
            List<BooksComment> booksComments = new List<BooksComment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM COMMENT";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                BooksComment comment = null;
                while (reader.Read())
                {
                    comment = new BooksComment();
                    comment.CommentId = reader.GetGuid(0);
                    comment.BookId = reader.GetGuid(1);
                    comment.Content = reader.GetString(2);
                    comment.NumberOfLikes = reader.GetInt32(3);
                    booksComments.Add(comment);
                }
                connection.Close();
                return await Task.FromResult(booksComments);
            }
        }
        //DELETE commment on comment id
        public async Task<bool> DeleteBooksCommentsByIdAsync(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "DELETE FROM COMMENT WHERE CommentID = @Id";
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
        //Get all comments from book id
        public async Task<List<BooksComment>> GetBooksCommentsByIdAsync(Guid id)
        {
            List<BooksComment> booksComments = new List<BooksComment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM COMMENT WHERE BookId = @Id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                BooksComment comment = null;
                while (reader.Read())
                {
                    comment = new BooksComment();
                    comment.CommentId = reader.GetGuid(0);
                    comment.BookId = reader.GetGuid(1);
                    comment.Content = reader.GetString(2);
                    comment.NumberOfLikes = reader.GetInt32(3);
                    booksComments.Add(comment);
                }
                connection.Close();
                return await Task.FromResult(booksComments);
            }
        }
    }
}

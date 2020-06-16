using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;
using Books.Repository.Common;

namespace Books.Repository
{
    public class ListRepository : IListRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PRAKSA;Integrated Security=True";
        List<ListGeneral> listGeneral = new List<ListGeneral>();


        public async Task<List<ListGeneral>> GetAllListsAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "SELECT * FROM LIST";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ListGeneral lists = null;
                while (reader.Read())
                {
                    lists = new ListGeneral();
                    lists.ListId = reader.GetGuid(0);
                    lists.Name = reader.GetString(1);
                    lists.Description = reader.GetString(2);
                    lists.NumberOfLikes = reader.GetInt32(3);
                    listGeneral.Add(lists);
                }
                connection.Close();
                return await Task.FromResult(listGeneral);
            }

        }


        public async Task<ListGeneral> GetListByIdAsync(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string queryString = "SELECT * FROM LIST WHERE ListID =@Id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ListGeneral lists = null;
                while (reader.Read())
                {
                    lists = new ListGeneral();
                    lists.ListId = reader.GetGuid(0);
                    lists.Name = reader.GetString(1);
                    lists.Description = reader.GetString(2);
                    lists.NumberOfLikes = reader.GetInt32(3);
                    listGeneral.Add(lists);
                }
                connection.Close();
                return await Task.FromResult(lists);
            }
        }


        public async Task<bool> DeleteListByIdAsync(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "DELETE FROM LIST WHERE ListID=@Id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                int deleted = command.ExecuteNonQuery();
                connection.Close();
                if(deleted == 0)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);

            }
           
        }


        public async Task<bool> CreateListAsync(ListGeneral newList)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO LIST(Name, Description) VALUES (@Name, @Description)";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Name", newList.Name);
                command.Parameters.AddWithValue("@Description", newList.Description);
                connection.Open();
                int create = command.ExecuteNonQuery();
                connection.Close();
                if(create == 0)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);
            }
        }

        public async Task<bool> UpdateListAsync(ListGeneral updateList)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "UPDATE LIST SET Name = @Name WHERE ListID=@Id";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Name", updateList.Name);
                command.Parameters.AddWithValue("@Id", updateList.ListId);
                connection.Open();
                int update = command.ExecuteNonQuery();
                connection.Close();
                if(update == 0)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);
            }
        }
    }
}

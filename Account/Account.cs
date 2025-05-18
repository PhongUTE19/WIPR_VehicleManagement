using System.Data.SqlClient;

namespace VehicleManagement
{
    public class Account
    {
        public bool Insert(int id, string username, string password)
        {
            string query = @"
                INSERT INTO [User] (id, username, password)
                VALUES (@id, @username, @password)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@status", "pending");
            //command.Parameters.AddWithValue("@email", email);
            return SqlHelper.Execute(command);
        }

        public bool Update(string username, string password)
        {
            string query = @"
                UPDATE TOP(1) [User]
                SET password = @password
                WHERE username = @username";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            return SqlHelper.Execute(command);
        }
    }
}

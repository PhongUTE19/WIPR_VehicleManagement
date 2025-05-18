using System.Data.SqlClient;

namespace VehicleManagement
{
    public class Job
    {
        public bool Insert(string id, string name, string description)
        {
            string query = @"
                INSERT INTO [Job] (id, name, string description)
                VALUES (@id, @name, @description)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", int.Parse(id));
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@description", description);
            return SqlHelper.Execute(command);
        }

        public bool Update(string id, string name, string description)
        {
            string query = @"
                UPDATE [Job]
                SET name = @name, description = @description
                WHERE id = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", int.Parse(id));
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@description", description);
            return SqlHelper.Execute(command);
        }

        public bool Delete(string id)
        {
            string query = @"
                DELETE FROM [Job]
                WHERE id = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            return SqlHelper.Execute(command);
        }
    }
}

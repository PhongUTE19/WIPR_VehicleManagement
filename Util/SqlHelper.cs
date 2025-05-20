using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VehicleManagement
{
    public class SqlHelper
    {
        public static bool Execute(SqlCommand command)
        {
            MyDB db = new MyDB();
            command.Connection = db.getConnection;
            db.OpenConnection();
            int rowAffected = command.ExecuteNonQuery();
            db.CloseConnection();
            return rowAffected == 1;
        }
        public static bool Execute(string query, Dictionary<string, object> parameters)
        {
            using (SqlCommand command = new SqlCommand(query))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
                return Execute(command);
            }
        }

        public static DataTable GetTable(SqlCommand command)
        {
            MyDB db = new MyDB();
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static int GetCount(SqlCommand command)
        {
            MyDB db = new MyDB();
            command.Connection = db.getConnection;
            db.OpenConnection();
            int count = (int)command.ExecuteScalar();
            db.CloseConnection();
            return count;
        }

        public static int GetLatestId(string tableName)
        {
            SqlCommand command = new SqlCommand($@"
                SELECT ISNULL(MAX(id), 0) + 1
                FROM dbo.{tableName}");
            int count = GetCount(command);
            return count;
        }

        public static object ExecuteScalar(string query)
        {
            MyDB db = new MyDB();
            SqlCommand command = new SqlCommand(query, db.getConnection);
            db.OpenConnection();
            object result = command.ExecuteScalar();
            db.CloseConnection();
            return result;
        }
        public static object ExecuteScalar(SqlCommand command)
        {
            MyDB db = new MyDB();
            command.Connection = db.getConnection;
            db.OpenConnection();
            object result = command.ExecuteScalar();
            db.CloseConnection();
            return result;
        }

        public static DataTable GetData(string query)
        {
            SqlCommand command = new SqlCommand(query);
            return GetTable(command);
        }
    }
}

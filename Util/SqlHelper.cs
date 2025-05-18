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
    }
}

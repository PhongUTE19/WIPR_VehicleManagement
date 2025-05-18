using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VehicleManagement
{
    public class MyDB
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WINPR_DB"].ConnectionString);

        public SqlConnection getConnection
        {
            get { return connection; }
        }

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}

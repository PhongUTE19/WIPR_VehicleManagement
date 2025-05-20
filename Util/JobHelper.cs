using System.Data;
using System.Data.SqlClient;

namespace VehicleManagement
{
    public static class JobHelper
    {
        public static DataTable GetJobs()
        {
            string query = "SELECT Id, Name FROM dbo.Job";
            SqlCommand command = new SqlCommand(query);
            DataTable jobs = SqlHelper.GetTable(command);
            return jobs;
        }
        public static DataTable GetJobsByRole(string roleKey)
        {
            string query = "SELECT Id, Name FROM Job WHERE RoleKey = @roleKey";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@roleKey", roleKey);
            return SqlHelper.GetTable(command);
        }
    }
}

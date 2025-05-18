
namespace VehicleManagement
{
    public class Global
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; }
        public static string Firstname { get; set; }
        public static string Lastname { get; set; }
        public static void SetGlobalUserId(int userId, string username, string firstname, string lastname)
        {
            UserId = userId;
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}

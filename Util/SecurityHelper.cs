using System;
using System.Security.Cryptography;
using System.Text;

public class SecurityHelper
{
    public static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    public static string HashPassword(string password, string salt)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            string saltedPassword = password + salt;
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

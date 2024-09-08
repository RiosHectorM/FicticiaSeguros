using System.Security.Cryptography;
using System.Text;

namespace FicticiaSeguros.Services
{
    public class Utils
    {
        public static string HashPassword(string pass)
        {

            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(pass));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            Console.WriteLine("Hashed password: " + sb.ToString());
            return sb.ToString();
        }
    }
}

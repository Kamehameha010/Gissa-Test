using System.Security.Cryptography;
using System.Text;

namespace GissaWeb.Tools
{
    public class Encrypt
    {
        public static string EncryptSha256(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(password));
            StringBuilder strBuilder = new StringBuilder();
            foreach (var str in bytes)
            {
                strBuilder.AppendFormat("{0:x2}", str);
            }
            return strBuilder.ToString();
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace yurovskaya_backend.Models
{
    public class user
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }
        public string PasswordHash
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var b in MD5.HashData(Password))
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
            set { Password = Encoding.UTF8.GetBytes(value); }
        }

        public bool IsAdmin => Login == "admin";

        public bool CheckPassword(string password) => PasswordHash == password;

        public user() { }
    }
}
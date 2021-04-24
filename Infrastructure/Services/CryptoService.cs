using System.Security.Cryptography;
using System.Text;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class CryptoService: ICryptoService
    {
        private HMACSHA512 hmac;
        public byte[][] GetEncryption(string password, byte[] salt = null)
        {
            byte[] passwordSalt;
            if (salt == null)
            {
                hmac = new HMACSHA512();
                passwordSalt = hmac.Key;
            }
            else
            {
                hmac = new HMACSHA512(salt);
                passwordSalt = salt;
            }
            
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[][] encryption = { passwordHash, passwordSalt };
            
            hmac.Dispose();
            
            return encryption;
        }
    }
}
using System;
using System.Security.Cryptography;
using System.Text;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Infrastructure.Services
{
    public class CryptoService: ICryptoService
    {
        public string HashPassword(string password)
        {
            using var sha256 = new SHA256Managed();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));  
            // Get the hashed string.  
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
        
        // private HMACSHA512 hmac;
        // public byte[][] GetEncryption(string password, byte[] salt = null)
        // {
        //     byte[] passwordSalt;
        //     if (salt == null)
        //     {
        //         hmac = new HMACSHA512();
        //         passwordSalt = hmac.Key;
        //     }
        //     else
        //     {
        //         hmac = new HMACSHA512(salt);
        //         passwordSalt = salt;
        //     }
        //     
        //     var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //     byte[][] encryption = { passwordHash, passwordSalt };
        //     
        //     hmac.Dispose();
        //     
        //     return encryption;
        // }
        
    }
}
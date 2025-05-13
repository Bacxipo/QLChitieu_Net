using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PBL111.BLL
{
    public class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;  
        private const int Iterations = 10000;
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            // Create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            // Combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Convert to base64
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Convert base64 to bytes
            var hashBytes = Convert.FromBase64String(hashedPassword);

            // Get salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            // Check if results match
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
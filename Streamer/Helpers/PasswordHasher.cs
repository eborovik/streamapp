using System;
using System.Security.Cryptography;

namespace Streamer.Helpers
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;

        public static string Hash(string password, int iterations)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]); // random salt
            
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations); // salted hash
            var hash = pbkdf2.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize + HashSize]; //array to store result
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);  //copy salt
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize); // copy hash

            var base64Hash = Convert.ToBase64String(hashBytes);  // convert bytes to string

            return string.Format("$HASH$V1${0}${1}", iterations, base64Hash);   //save in specific format
        }

        public static string Hash(string password)
        {
            return Hash(password, 10000);
        }

        private static bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$HASH$V1$");
        }

        public static bool Verify(string password, string hashedPassword)
        {
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            var splittedHashString = hashedPassword.Replace("$HASH$V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            var hashBytes = Convert.FromBase64String(base64Hash);  // hash bytes from db

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize); //salt from db

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);   // hash of password

            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])  // compare every byte
                {
                    return false;
                }
            }
            return true;
        }
    }
}

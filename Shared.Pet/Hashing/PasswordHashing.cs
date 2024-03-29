﻿using System.Security.Cryptography;

namespace Shared.Pet.Hashing
{
    public class PasswordHashing 
    {
        private const int SaltSize = 32;
        private const int HashSize = 32;
        private const int IterationCount = 10000;
        public static string HashingHelper(string password, out string salt)
        {
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltSize))
            {
                rfc2898DeriveBytes.IterationCount = IterationCount;
                byte[] hashData = rfc2898DeriveBytes.GetBytes(HashSize);
                byte[] saltData = rfc2898DeriveBytes.Salt;
                salt = Convert.ToBase64String(saltData);
                return Convert.ToBase64String(hashData);
            }
        }
        public static bool VerifyPassword(string password, string passwordHash, string salt)
        {
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltSize))
            {
                rfc2898DeriveBytes.IterationCount = IterationCount;
                rfc2898DeriveBytes.Salt = Convert.FromBase64String(salt);
                byte[] hashData = rfc2898DeriveBytes.GetBytes(HashSize);
                return Convert.ToBase64String(hashData) == passwordHash;
            }
        }
    }
}

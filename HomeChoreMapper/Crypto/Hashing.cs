using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace HomeChoreMapper.Crypto
{
    public class Hashing
    {
        private const int WorkFactor = 10000;

        public string SaltValue { get; private set; }

        public string HashPassword(string plainTextPassword)
        {
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(plainTextPassword, 8, WorkFactor);

            byte[] hash = rfc.GetBytes(20);

            SaltValue = Convert.ToBase64String(rfc.Salt);

            return Convert.ToBase64String(hash);
        }

        public bool VerifyPasswordMatch(string existingHashedPassword, string plainTextPassword, string salt)
        {
            byte[] saltArray = Convert.FromBase64String(salt);

            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(plainTextPassword, saltArray, WorkFactor);

            byte[] hash = rfc.GetBytes(20);

            string newHashedPassword = Convert.ToBase64String(hash);

            return (existingHashedPassword == newHashedPassword);
        }
    }
}
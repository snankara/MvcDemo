using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePassswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static void CreateEmailHash(string email, out byte[] emailHash, out byte[] emailSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                emailSalt = hmac.Key;
                emailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(email));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var comptudHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < comptudHash.Length; i++)
                {
                    if (comptudHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public static bool VerifyEmailHash(string email, byte[] emailHash, byte[] emailSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(emailSalt))
            {
                var comptudHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(email));
                for (int i = 0; i < comptudHash.Length; i++)
                {
                    if (comptudHash[i] != emailHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

    }
}

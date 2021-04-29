using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class SecurityHelper
    {
        private RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private static Random rnd = new Random();
        private const int ITERATIONS = 100;
        public byte[] GenerateLongRandomSalt()
        {
            byte[] salt = new byte[rnd.Next(10, 50)];
            rngCsp.GetBytes(salt);

            return salt;
        }

        public string createHash(string input, byte[] salt, int rn = 0)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, ITERATIONS);
            rn = rn == 0 ? rnd.Next(10, 100) : rn;
            return Convert.ToBase64String(pbkdf2.GetBytes(rn)) + "|" + rn.ToString();
        }

        public bool VerifyHash(string input, string originalHash, string salt)
        {
            string[] tabHash = originalHash.Split('|');
            int nbBytes = int.Parse(tabHash[1]);

            string newPwd = createHash(input, Convert.FromBase64String(salt), nbBytes);

            return newPwd == originalHash;
        }
    }
}

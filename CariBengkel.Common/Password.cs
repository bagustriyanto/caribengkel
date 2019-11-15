using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CariBengkel.Common {
    public class Password {
        public string Salt () {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create ()) {
                generator.GetBytes (randomBytes);
                return Convert.ToBase64String (randomBytes);
            }
        }
        public string PasswordEncrypt (string password, string salt) {
            string hashed = Convert.ToBase64String (KeyDerivation.Pbkdf2 (
                password: password,
                salt: Encoding.UTF8.GetBytes (salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }

    public class VerificationCode {
        public string Generate () {
            int size = 4;
            StringBuilder builder = new StringBuilder ();
            Random random = new Random ();
            char ch;
            for (int i = 0; i < size; i++) {
                ch = Convert.ToChar (Convert.ToInt32 (Math.Floor (26 * random.NextDouble () + 65)));
                builder.Append (ch);
            }

            return builder.ToString ().ToLower ();
        }
    }
}
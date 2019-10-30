using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CariBengkel.Common {
    public class Password {
        public string PasswordEncrypt (string password) {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create ()) {
                rng.GetBytes (salt);
            }
            string hashed = Convert.ToBase64String (KeyDerivation.Pbkdf2 (
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
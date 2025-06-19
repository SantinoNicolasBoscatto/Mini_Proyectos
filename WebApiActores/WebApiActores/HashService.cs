using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using WebApiActores.DTOs;

namespace WebApiActores
{
    public class HashService
    {
        // Crear una SAL aleatoria
        public ResultadoHashDTO Hash(string textPlain)
        {
            var sal = new byte[16];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(sal);
            }
            return Hash(textPlain, sal);
        }

        // Genera el HASH
        public ResultadoHashDTO Hash(string textPlain, byte[] sal)
        { 
            var keyDerivate = KeyDerivation.Pbkdf2(password: textPlain, salt: sal, prf: KeyDerivationPrf.HMACSHA1, 
                                            iterationCount: 10000, numBytesRequested: 32);
            var hash = Convert.ToBase64String(keyDerivate);

            return new ResultadoHashDTO { Hash = hash, Sal = sal };
        }
    }
}

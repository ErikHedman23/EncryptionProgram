using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EncryptionProgram
{
    public class GenerateRandomIVClass
    {
        public static byte[] GenerateRandomIV ()
        {
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                byte[] iv = new byte[16]; // 128 bits IV
                rngCsp.GetBytes(iv);
                return iv;
            }
        }
    }
}

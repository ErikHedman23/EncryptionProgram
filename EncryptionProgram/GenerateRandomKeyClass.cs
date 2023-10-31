using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EncryptionProgram
{
    public class GenerateRandomKeyClass
    {
         public static byte[] GenerateRandomKey()
        {

            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[16];
                rngCsp.GetBytes(key);
                return key;

            }
        }
    }
}    

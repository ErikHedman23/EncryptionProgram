using EncryptionProgram;
using System;
using System.Security.Cryptography;


Console.Write("Enter the text to encrypt: ");
string inputText = Console.ReadLine();

byte[] key = GenerateRandomKeyClass.GenerateRandomKey();

byte[] iv = GenerateRandomIVClass.GenerateRandomIV();

//byte[] key = { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
//byte[] iv = { 0xF0, 0xE1, 0xD2, 0xC3, 0xB4, 0xA5, 0x96, 0x87, 0x78, 0x69, 0x5A, 0x4B, 0x3C, 0x2D, 0x1E, 0x0F };

using (AesManaged aesAlg = new AesManaged())
{
    aesAlg.Key = key;
    aesAlg.IV = iv;

    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

    using (MemoryStream msEncrypt = new MemoryStream())
    {
        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            
            {
                swEncrypt.Write(inputText);
            }
        }
    byte[] encryptedData = msEncrypt.ToArray();
        bool userEntry = true;
        do
        {

            string encryptedText = Convert.ToBase64String(encryptedData);

            Console.WriteLine("Encrypted Text: " + encryptedText);

            byte[] cipherText = Convert.FromBase64String(encryptedText);

            Console.WriteLine("Would you like to decrypt the text?  Type 1 for 'Yes', or type 2 for 'No': ");
            int userOutput = 0;
            userEntry = int.TryParse(Console.ReadLine(), out userOutput);
            switch (userOutput)
            {
                case 1:
                    string decryptedText = DecryptionClass.DecryptText(cipherText, key, iv);
                    Console.WriteLine("Your decrypted text: " + decryptedText);
                    break;
                case 2:
                    Console.WriteLine("Goodbye...");
                    break;
                default:
                    Console.WriteLine("Invalid Entry: Please enter either 1 or 2 to continue...");
                    userEntry = false;
                    break;
            }
        } while (userEntry == false);

        

        
    }


}


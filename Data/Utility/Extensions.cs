using System.Security.Cryptography;

namespace Gadget.api.Utility
{
    public static class Extensions
    {
        public static string Encrypt(this string valueToEncrypt)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.IV = iv;
                ICryptoTransform cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
                using(MemoryStream memoryStream = new MemoryStream())
                {
                    using(CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        using(StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(valueToEncrypt);
                        }
                        array= memoryStream.ToArray();
                        
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public static string Decrypt(this string valueToDecrypt)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(valueToDecrypt);
            using( Aes aes = Aes.Create())
            {
               aes.IV = iv;
               ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
               using(MemoryStream memoryStream = new MemoryStream())
               {
                   using(CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                   {
                       using(StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                       {
                           return streamReader.ReadToEnd();
                       }
                   }
               } 
            }

        }
    
    }
}
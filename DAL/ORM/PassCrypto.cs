using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace DAL.ORM.Entity
{
    public static class PassCrypto
    {
        public static string base64Encode(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];

                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);

                string encodedData = Convert.ToBase64String(encData_byte);

                return encodedData;

            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string base64Decode(string sData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }

        }



        //public static string EncryptData(string textData, string Encryptionkey)
        //{
        //    RijndaelManaged objrij = new RijndaelManaged();
        //    //set the mode for operation of the algorithm   
        //    objrij.Mode = CipherMode.CBC;
        //    //set the padding mode used in the algorithm.   
        //    objrij.Padding = PaddingMode.PKCS7;
        //    //set the size, in bits, for the secret key.   
        //    objrij.KeySize = 0x80;
        //    //set the block size in bits for the cryptographic operation.    
        //    objrij.BlockSize = 0x80;
        //    //set the symmetric key that is used for encryption & decryption.    
        //    byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
        //    //set the initialization vector (IV) for the symmetric algorithm    
        //    byte[] EncryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        //    int len = passBytes.Length;
        //    if (len > EncryptionkeyBytes.Length)
        //    {
        //        len = EncryptionkeyBytes.Length;
        //    }
        //    Array.Copy(passBytes, EncryptionkeyBytes, len);

        //    objrij.Key = EncryptionkeyBytes;
        //    objrij.IV = EncryptionkeyBytes;

        //    //Creates symmetric AES object with the current key and initialization vector IV.    
        //    ICryptoTransform objtransform = objrij.CreateEncryptor();
        //    byte[] textDataByte = Encoding.UTF8.GetBytes(textData);
        //    //Final transform the test string.  
        //    return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        //}
        //public static string DecryptData(string EncryptedText, string Encryptionkey)
        //{
        //    RijndaelManaged objrij = new RijndaelManaged();
        //    objrij.Mode = CipherMode.CBC;
        //    objrij.Padding = PaddingMode.PKCS7;

        //    objrij.KeySize = 0x80;
        //    objrij.BlockSize = 0x80;
        //    byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
        //    byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
        //    byte[] EncryptionkeyBytes = new byte[0x10];
        //    int len = passBytes.Length;
        //    if (len > EncryptionkeyBytes.Length)
        //    {
        //        len = EncryptionkeyBytes.Length;
        //    }
        //    Array.Copy(passBytes, EncryptionkeyBytes, len);
        //    objrij.Key = EncryptionkeyBytes;
        //    objrij.IV = EncryptionkeyBytes;
        //    byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
        //    return Encoding.UTF8.GetString(TextByte);  //it will return readable string  
        //}




        //public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        //{
        //    // Check arguments.
        //    if (plainText == null || plainText.Length <= 0)
        //        throw new ArgumentNullException("plainText");
        //    if (Key == null || Key.Length <= 0)
        //        throw new ArgumentNullException("Key");
        //    if (IV == null || IV.Length <= 0)
        //        throw new ArgumentNullException("IV");
        //    byte[] encrypted;

        //    // Create an AesCryptoServiceProvider object
        //    // with the specified key and IV.
        //    using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
        //    {
        //        aesAlg.Key = Key;
        //        aesAlg.IV = IV;

        //        // Create an encryptor to perform the stream transform.
        //        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        //        // Create the streams used for encryption.
        //        using (MemoryStream msEncrypt = new MemoryStream())
        //        {
        //            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
        //                {
        //                    //Write all data to the stream.
        //                    swEncrypt.Write(plainText);
        //                }
        //                encrypted = msEncrypt.ToArray();
        //            }
        //        }
        //    }

        //    // Return the encrypted bytes from the memory stream.
        //    return encrypted;

        //}
        //public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        //{
        //    // Check arguments.
        //    if (cipherText == null || cipherText.Length <= 0)
        //        throw new ArgumentNullException("cipherText");
        //    if (Key == null || Key.Length <= 0)
        //        throw new ArgumentNullException("Key");
        //    if (IV == null || IV.Length <= 0)
        //        throw new ArgumentNullException("IV");

        //    // Declare the string used to hold
        //    // the decrypted text.
        //    string plaintext = null;

        //    // Create an AesCryptoServiceProvider object
        //    // with the specified key and IV.
        //    using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
        //    {
        //        aesAlg.Key = Key;
        //        aesAlg.IV = IV;

        //        // Create a decryptor to perform the stream transform.
        //        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        //        // Create the streams used for decryption.
        //        using (MemoryStream msDecrypt = new MemoryStream(cipherText))
        //        {
        //            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //            {
        //                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
        //                {

        //                    // Read the decrypted bytes from the decrypting stream
        //                    // and place them in a string.
        //                    plaintext = srDecrypt.ReadToEnd();
        //                }
        //            }
        //        }

        //    }

        //    return plaintext;

        //}




    }
}

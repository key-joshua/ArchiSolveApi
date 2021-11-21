using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Utilities
{
    public static class SecurityHelper
    {
        public static Byte[] _key64 = Encoding.ASCII.GetBytes("Ki73y4&j");
        public static Byte[] _iv64 = Encoding.ASCII.GetBytes("*wg%h9Sd");

        public static string GetSha256Hash(string input)
        {
            //using (var sha256 = new SHA256CryptoServiceProvider())
            using (var sha256 = SHA256.Create())
            {
                var byteValue = Encoding.UTF8.GetBytes(input);
                var byteHash = sha256.ComputeHash(byteValue);
                return Convert.ToBase64String(byteHash);
                //return BitConverter.ToString(byteHash).Replace("-", "").ToLower();
            }
        }

        public static string GetEncryptMd5(this string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var valueArray = System.Text.Encoding.ASCII.GetBytes(value);
            valueArray = md5.ComputeHash(valueArray);
            var encrypted = "";
            for (int i = 0; i < valueArray.Length; i++)
                encrypted += valueArray[i].ToString("x2").ToLower();
            return encrypted;
        }

       

        public static string DESDecrypt(string source)
        {
            try
            {
                string decryptedValue;
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                //source = source.Replace('%',' ').Trim();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(source));
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(_key64, _iv64), CryptoStreamMode.Read);
                StreamReader streamReader = new StreamReader(cryptoStream);
                decryptedValue = streamReader.ReadToEnd();
                streamReader.Close();
                cryptoStream.Close();
                memoryStream.Close();

                return decryptedValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string DESEncrypt(string source)
        {
            try
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(_key64, _iv64), CryptoStreamMode.Write);
                StreamWriter streamWriter = new StreamWriter(cryptoStream);

                streamWriter.Write(source);
                streamWriter.Flush();
                cryptoStream.FlushFinalBlock();
                memoryStream.Flush();

                string encryptedValue = Convert.ToBase64String(memoryStream.GetBuffer(), 0, Convert.ToInt32(memoryStream.Length));

                streamWriter.Close();
                cryptoStream.Close();
                memoryStream.Close();

                return encryptedValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string StringToMD5Encription(string key)
        {
            try
            {
                MD5 md5Hasher = MD5.Create();
                byte[] hashedKey = md5Hasher.ComputeHash(Encoding.Default.GetBytes(key));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashedKey.Length; i++)
                {
                    stringBuilder.Append(hashedKey[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Encrypts a clear text using specified password and salt.
        /// </summary>
        /// <param name="clearText">The text to encrypt.</param>
        /// <param name="password">The password to create key for.</param>
        /// <param name="salt">The salt to add to encrypted text to make it more secure.</param>
        public static string Encrypt(string clearText, string password, byte[] salt)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

            RijndaelManaged rijndael = new RijndaelManaged();
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

            rijndael.Key = pdb.GetBytes(rijndael.KeySize / 8);
            rijndael.IV = pdb.GetBytes(rijndael.BlockSize / 8);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, rijndael.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearBytes, 0, clearBytes.Length);

            // Before using encrypted data, we have to call
            // either CryptoStream.Close() or CryptoStream.FlushFinalBlock()
            cs.Close();
            ms.Close();

            return Convert.ToBase64String(ms.ToArray());
        }
        /// <summary>
        /// Decrypts an encrypted text using specified password and salt.
        /// </summary>
        /// <param name="cipherText">The text to decrypt.</param>
        /// <param name="password">The password used to encrypt text.</param>
        /// <param name="salt">The salt added to encrypted text.</param>
        public static string Decrypt(string cipherText, string password,
            byte[] salt)
        {

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            RijndaelManaged rijndael = new RijndaelManaged();
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

            rijndael.Key = pdb.GetBytes(rijndael.KeySize / 8);
            rijndael.IV = pdb.GetBytes(rijndael.BlockSize / 8);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, rijndael.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherBytes, 0, cipherBytes.Length);

            cs.Close();
            ms.Close();

            return Encoding.Unicode.GetString(ms.ToArray());
        }
        /// <summary>
        /// Creates a random salt to use in encryption.
        /// </summary>
        /// <param name="Length">Lenth of random salt.</param>
        public static byte[] GenerateRandomSalt(int length)
        {
            byte[] randBytes;

            if (length >= 1)
            {
                randBytes = new byte[length];
            }
            else
            {
                throw new ArgumentOutOfRangeException("lenght", "lenght cannot be less than 1.");
            }

            // Create a new RNGCryptoServiceProvider
            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

            // Fill the buffer with random bytes
            rand.GetBytes(randBytes);

            // Return
            return randBytes;
        }
    }
}

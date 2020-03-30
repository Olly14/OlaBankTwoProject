//using Newtonsoft.Json;
//using System;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Security.Cryptography;
//using System.Text;

//namespace Bank.Data.Security.Encryption
//{
//    public class AesUriParameterSecurity : IUriParameterSecurity
//    {
//        private readonly byte[] _aesKey;
//        private readonly byte[] _aesIv;


//        public AesUriParameterSecurity(IAesKeyResolver keyResolver)
//        {
//            _aesKey = keyResolver.GetKey();
//            _aesIv = keyResolver.GetIv();
//        }

//        /// <summary>
//        /// Encrypts the dynamic list of properties that form the composite key into a Base64 Encoded (URL Safe) AES Encrypted JSON
//        /// </summary>
//        /// <param name="key"></param>
//        /// <returns>Base64 Encoded JSON string</returns>
//        public string Encrypt(dynamic key)
//        {
//            string json = JsonConvert.SerializeObject(key);
//            using (Aes aes = Aes.Create())
//            {
//                aes.Key = _aesKey;
//                aes.IV = _aesIv;
//                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
//                using (MemoryStream msEncrypt = new MemoryStream())
//                {
//                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
//                    {
//                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
//                        {
//                            var sha = SHA1.Create();
//                            byte[] shaHash = sha.ComputeHash(Encoding.UTF8.GetBytes(json));
//                            var salt = shaHash.Aggregate("", (current, b) => current + b.ToString("X"));
//                            var textToEncrypt = string.Format("{0}{1}", salt, json);
//                            swEncrypt.Write(textToEncrypt);
//                        }
//                        return WebUtility.UrlEncode(Convert.ToString(msEncrypt.ToArray()));
//                    }
//                }
//            }
//        }

//        /// <summary>
//        /// Decrypts the Base64 Encoded AES Encrypted JSON String back to the Keys' Object
//        /// </summary>
//        /// <param name="compositeKey"></param>
//        /// <returns>Object</returns>
//        public T Decrypt<T>(string compositeKey)
//        {
//            //byte[] bytes
//            //Encoding.UTF8.GetBytes(compositeKey)
//            byte[] bytes = Encoding.UTF8.GetBytes(WebUtility.UrlDecode(compositeKey));

//            if (bytes == null)
//            {
//                return default(T);
//            }
//            using (Aes aes = Aes.Create())
//            {
//                aes.Key = _aesKey;
//                aes.IV = _aesIv;
//                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
//                try
//                {
//                    using (MemoryStream msDecrypt = new MemoryStream(bytes))
//                    {
//                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
//                        {
//                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
//                            {
//                                var decryptedText = srDecrypt.ReadToEnd();
//                                var json = decryptedText.Substring(decryptedText.IndexOf("{", StringComparison.Ordinal));
//                                T obj = JsonConvert.DeserializeObject<T>(json);
//                                return obj;
//                            }
//                        }
//                    }
//                }
//                catch
//                {
//                    return default(T);
//                }
//            }
//        }
//    }
//}
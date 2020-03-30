//using System;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Security.Cryptography;
//using System.Text;
//using Newtonsoft.Json;

//namespace Bank.Data.Security.Encryption
//{
//    public class RSaWithCspKey
//    {
//        private const string ContainerName = "MyContainer";
//        public void AssignNewKey()
//        {
//            CspParameters cspParameters = new CspParameters(1);
//            cspParameters.KeyContainerName = ContainerName;
//            cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;
//            cspParameters.ProviderName = "Microsoft Strong Cryptographic Provider";

//            var rsa = new RSACryptoServiceProvider(cspParameters)
//            {
//                PersistKeyInCsp = true
//            };

//        }

//        public void DeleteKeyInCsp()
//        {
//            var cspParameters = new CspParameters { KeyContainerName = ContainerName };
//            var rsa = new RSACryptoServiceProvider(cspParameters)
//            {
//                PersistKeyInCsp = false
//            };

//            rsa.Clear();
//        }

//        public byte[] EncryptData(byte[] dataToEncrypt)
//        {
//            byte[] cipherText;

//            var cspParameters = new CspParameters { KeyContainerName = ContainerName };

//            using (var rsa = new RSACryptoServiceProvider(4096, cspParameters))
//            {
//                cipherText = rsa.Encrypt(dataToEncrypt, false);
//            }

//            return cipherText;
//        }


//        public string EncryptData(string dataToEncrypt)
//        {
//            byte[] dataToEncryptToByte = Encoding.UTF8.GetBytes(dataToEncrypt);

//            byte[] cipherText;

//            var cspParameters = new CspParameters { KeyContainerName = ContainerName };

//            using (var rsa = new RSACryptoServiceProvider(4096, cspParameters))
//            {
//                cipherText = rsa.Encrypt(dataToEncryptToByte, false);
//            }

//            var cipherTextToBase64String = Convert.ToBase64String(cipherText, Base64FormattingOptions.None);

//            return cipherTextToBase64String;
//        }

//        public string EncryptData(object dataToEncrypt)
//        {
//            var dataToEncryptToByte = (byte[])(dataToEncrypt);

//            byte[] cipherText;

//            var cspParameters = new CspParameters { KeyContainerName = ContainerName };

//            using (var rsa = new RSACryptoServiceProvider(4096, cspParameters))
//            {
//                cipherText = rsa.Encrypt(dataToEncryptToByte, false);
//            }

//            var cipherTextToBase64String = Convert.ToBase64String(cipherText, Base64FormattingOptions.None);

//            return cipherTextToBase64String;
//        }

//        public byte[] DecryptData(byte[] dataToDecrypt)
//        {

//            byte[] plain;



//            var cspParameters = new CspParameters { KeyContainerName = ContainerName };

//            using (var rsa = new RSACryptoServiceProvider(4096, cspParameters))
//            {
//                plain = rsa.Decrypt(dataToDecrypt, false);
//            }

//            return plain;
//        }

//        public T DecryptData<T>(string dataToDecrypt)
//        {
//            byte[] dataToDecryptToByte = Convert.FromBase64String(dataToDecrypt);

//            byte[] plain;

//            var cspParameters = new CspParameters { KeyContainerName = ContainerName };

//            using (var rsa = new RSACryptoServiceProvider(4096, cspParameters))
//            {
//                plain = rsa.Decrypt(dataToDecryptToByte, false);
//            }
//            var cipherTextToBase64String = Convert.ToBase64String(plain, Base64FormattingOptions.None);
//            var typeT = JsonConvert.DeserializeObject<T>(cipherTextToBase64String);
//            return typeT;

//        }



//        public T DecryptData<T>(object dataToDecrypt)
//        {
//            byte[] dataToDecryptToByte = (byte[])dataToDecrypt;

//            byte[] plain;

//            var cspParameters = new CspParameters { KeyContainerName = ContainerName };

//            using (var rsa = new RSACryptoServiceProvider(4096, cspParameters))
//            {
//                plain = rsa.Decrypt(dataToDecryptToByte, false);
//            }
//            var cipherTextToBase64String = Convert.ToBase64String(plain, Base64FormattingOptions.None);
//            var typeT = JsonConvert.DeserializeObject<T>(cipherTextToBase64String);
//            return typeT;

//        }

//        byte[] ObjectToByteArray(object obj)
//        {
//            if (obj == null)
//                return null;
//            BinaryFormatter bf = new BinaryFormatter();
//            using (MemoryStream ms = new MemoryStream())
//            {
//                bf.Serialize(ms, obj);
//                return ms.ToArray();
//            }
//        }
//    }
//}

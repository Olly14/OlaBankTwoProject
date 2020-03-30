//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;

//namespace Bank.Data.Security.Encryption
//{
//    public class RSAwithRSAParameterKeyInMemory
//    {
//        private RSAParameters _publicKey;
//        private RSAParameters _privateKey;

//        public void AssignNewKey()
//        {
//            using (var rsa = new RSACryptoServiceProvider(4096))
//            {
//                rsa.PersistKeyInCsp = false;
//                _privateKey = rsa.ExportParameters(false);
//                _publicKey = rsa.ExportParameters(true);
//            }
//        }

//        public byte[] EncryptData(byte[] dataToEncrpty)
//        {
//            byte[] cipherText;

//            using (var rsa = new RSACryptoServiceProvider(4096))
//            {
//                rsa.PersistKeyInCsp = false;
//                rsa.ImportParameters(_publicKey);

//                cipherText = rsa.Encrypt(dataToEncrpty, true);
//            }

//            return cipherText;
//        }


//        public byte[] DecryptData(byte[] dataToDecrypt)
//        {
//            byte[] plain;

//            using (var rsa = new RSACryptoServiceProvider(4096))
//            {
//                rsa.PersistKeyInCsp = false;
//                rsa.ImportParameters(_privateKey);

//                plain = rsa.Decrypt(dataToDecrypt, true);
//            }

//            return plain;
//        }
//    }
//}

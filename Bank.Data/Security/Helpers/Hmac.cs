//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;
//using Bank.Data.Security.Cryptography;

//namespace Bank.Data.Security.Helpers
//{
//    public class Hmac
//    {
//        private const int KeySize = 32;


//        public static byte[] GenerateKey()
//        {
//            return RandomNumber.GenerateRandomNumber(KeySize);
//        }

//        public static byte[] ComputeHmac256(byte[] byteToBeHashed, byte[] key)
//        {
//            using (var hmac = new HMACSHA256(key))
//            {
//                return hmac.ComputeHash(key);
//            }
//        }

//        public static byte[] ComputeHmac512(byte[] byteToBeHashed, byte[] key)
//        {
//            using (var hmac = new HMACSHA512(key))
//            {
//                return hmac.ComputeHash(key);
//            }
//        }


//        public static byte[] ComputeHmac1(byte[] byteToBeHashed, byte[] key)
//        {
//            using (var hmac = new HMACSHA1(key))
//            {
//                return hmac.ComputeHash(key);
//            }
//        }

//        public static byte[] ComputeHmacMd5(byte[] byteToBeHashed, byte[] key)
//        {
//            using (var hmac = new HMACMD5(key))
//            {
//                return hmac.ComputeHash(key);
//            }
//        }
//    }
//}

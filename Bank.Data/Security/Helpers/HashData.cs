//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;

//namespace Bank.Data.Security.Helpers
//{
//    public class HashData
//    {
//        public static byte[] ComputeHashSha1(byte[] byteToBeHashed)
//        {
//            using (var sha1 = SHA1.Create())
//            {
//                return sha1.ComputeHash(byteToBeHashed);
//            }
//        }

//        public static byte[] ComputeHashSha526(byte[] byteToBeHashed)
//        {
//            using (var sha256 = SHA256.Create())
//            {a=
//                return sha256.ComputeHash(byteToBeHashed);
//            }
//        }


//        public static byte[] ComputeHashSha512(byte[] byteToBeHashed)
//        {
//            using (var sha512 = SHA512.Create())
//            {
//                return sha512.ComputeHash(byteToBeHashed);
//            }
//        }


//        public static byte[] ComputeHashMd5(byte[] byteToBeHashed)
//        {
//            using (var md5 = MD5.Create())
//            {
//                return md5.ComputeHash(byteToBeHashed);
//            }
//        }
//    }
//}

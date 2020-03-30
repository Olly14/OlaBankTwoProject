//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;
//using Bank.Data.Security.Cryptography;

//namespace Bank.Data.Security.Helpers
//{
//    public static class HashAndSalt
//    {
//        public static byte[] GenerateSalt()
//        {
//            const int saltLength = 32;

//            return RandomNumber.GenerateRandomNumber(saltLength);
//        }

//        private static byte[] CombinePasswordWithHash(byte[] first, byte[] second)
//        {
//            var combimedBytes = new byte[first.Length + second.Length];

//            Buffer.BlockCopy(first, 0, combimedBytes, 0, first.Length);
//            Buffer.BlockCopy(second, 0, combimedBytes, first.Length, second.Length);

//            return combimedBytes;
//        }

//        public static byte[] HashPasswordWithSalt(byte[] bytesToBeHashed, byte[] salt)
//        {
//            using (var sha256 = SHA256.Create())
//            {
//                return sha256.ComputeHash(CombinePasswordWithHash(bytesToBeHashed, salt));
//            }
//        }
//    }
//}

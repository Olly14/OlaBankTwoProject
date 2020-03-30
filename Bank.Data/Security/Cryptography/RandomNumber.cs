//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;

//namespace Bank.Data.Security.Cryptography
//{
//    public class RandomNumber
//    {
//        public static byte[] GenerateRandomNumber(int length)
//        {
//            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
//            {
//                var randomNumber = new byte[length];

//                randomNumberGenerator.GetBytes(randomNumber);

//                return randomNumber;
//            }
//        }
//    }
//}

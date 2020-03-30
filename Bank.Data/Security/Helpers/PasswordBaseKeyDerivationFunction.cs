//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;
//using Bank.Data.Security.Cryptography;

//namespace Bank.Data.Security.Helpers
//{
//    public class PasswordBaseKeyDerivationFunction
//    {

//        public static byte[] GenerateSalt()
//        {
//            const int saltLength = 32;

//            return RandomNumber.GenerateRandomNumber(saltLength);
//        }


//        public static byte[] HashPassword(byte[] password, byte[] salt, int rounds)
//        {
//            const int keySize = 32;

//            using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, rounds))
//            {
//                return rfc2898.GetBytes(keySize);
//            }
//        }

//        public static string HashPassword(string password)
//        {
//            const int keySize = 32;

//            const int Rounds = 3;

//            var saltByte = GenerateSalt();

//            var passwordbyte = Encoding.UTF8.GetBytes(password);

//            using (var rfc2898 = new Rfc2898DeriveBytes(passwordbyte, saltByte, Rounds))
//            {

//                return Encoding.UTF8.GetString(rfc2898.GetBytes(keySize));
//            }
//        }
//    }
//}

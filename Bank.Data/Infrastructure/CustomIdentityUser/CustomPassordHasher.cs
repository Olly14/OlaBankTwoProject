//using Bank.Data.Security.Helpers;
//using Bank.Domain;
//using Microsoft.AspNetCore.Identity;
////using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Bank.Data.Infrastructure.CustomIdentityUser
//{
//    public class CustomPassordHasher : IPasswordHasher<AppUser>
//    {
//        public string HashPassword(AppUser user, string password)
//        {
//            return PasswordBaseKeyDerivationFunction.HashPassword(password);
//        }

//        public PasswordVerificationResult VerifyHashedPassword(AppUser user, string hashedPassword, string providedPassword)
//        {
//            if (hashedPassword.Equals(providedPassword)) 
//            {
//                return PasswordVerificationResult.Success;
//            }
//            else
//            {
//                return PasswordVerificationResult.Failed;
//            }
//        }
//    }
//}

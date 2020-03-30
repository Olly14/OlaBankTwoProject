using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Utilities
{
    public class RegularExpressions
    {
        public const string CellPhoneE164 = @"^\+[1-9][0-9]{10,15}$";

        public const string CellPhone = @"^[0-9\-\s]{10,15}$";
        public const string ExtentionOrPhone = @"^[0-9\-\s]{1,15}$";
        public const string CellPhoneNumbersOnly = @"^[0-9]{10,15}$";

        public const string Telephone = @"^[0\+][\d\s\-\(\)]{10,25}$";

        public const string WebAddress = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

        public const string PostalZipCode = @"^[A-z0-9\s-]{3,16}$";

        public const string EmailAddress = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
    }
}

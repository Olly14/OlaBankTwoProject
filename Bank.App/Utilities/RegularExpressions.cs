using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Utilities
{
    public class RegularExpressions
    {


        public const string Telephone = @"^[0\+][\d\s\-\(\)]{10,25}$";

        public const string WebAddress = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

        public const string PostalZipCode = @"^[A-z0-9\s-]{3,16}$";

        public const string EmailAddress = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
    }
}

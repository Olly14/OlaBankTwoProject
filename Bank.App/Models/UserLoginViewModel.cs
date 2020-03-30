using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Models
{
    public class UserLoginViewModel
    {


        public string Id { get; set; }


        public string SubjectId { get; set; }

        public string LoginProvider { get; set; }


        public string ProviderKey { get; set; }

        public UserViewModel User { get; set; }
    }
}

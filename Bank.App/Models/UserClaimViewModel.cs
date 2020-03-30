using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Models
{
    public class UserClaimViewModel
    {

        public string Id { get; set; }



        public string SubjectId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        //Navigation property
        public UserViewModel User { get; set; }
    }
}

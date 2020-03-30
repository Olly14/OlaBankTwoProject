using System;
using Bank.App.Models.ModelValidators;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bank.App.Models
{
    public class AppUserViewModel
    {
        public AppUserViewModel()
        {
            //Roles = new List<RoleViewModel>();
            //Claims = new List<ClaimViewModel>();
        }
        public string AppUserId { get; set; }

        public string AppUserIdEncoded { get; set; }
        public string Id { get; set; }
        public string UriKey { get; set; }

        [DisplayNameAttribute("First Name")]
        public string FirstName { get; set; }
        [DisplayNameAttribute("Surname")]
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }

        [DisplayNameAttribute("First Line Of Address")]
        public string FirstLineOfAddress { get; set; }
        [DisplayNameAttribute("Second Line Of Address")]
        public string SecondLineOfAddress { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }

        [DisplayNameAttribute("Date Of Birth")]
        public string DateOfBirth { get; set; }
        public CountryViewModel Country { get; set; }

        [DisplayNameAttribute("Country")] 
        public string CountryId { get; set; }


        [DisplayNameAttribute("Country")]
        public string CountryIdValue { get; set; }

        [DisplayNameAttribute("Gender")]
        public string GenderId { get; set; }

        [DisplayNameAttribute("Gender")]
        public string GenderIdValue { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public string ModifierAppUserId { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string UiControl { get; set; }
        //Navigation
        public virtual GenderViewModel Gender { get; set; }

        public virtual ICollection<AccountViewModel> Accounts { get; set; }

        public  IList<string> Roles { get; set; }

        public  IList<string> Claims { get; set; }
    }
}



using System;

namespace Bank.App.Models
{
    public class RegistrationViewModel
    {
        public RegistrationViewModel()
        {
        }
        //internal string UriKey;

        //public Guid SubjectId { get; set; }
        public Guid AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string FirstLineOfAddress { get; set; }
        public string SecondLineOfAddress { get; set; }
        public string Town { get; set; }

        public string Postcode { get; set; }
        //public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string GenderValue { get; set; }
        public string Nationality { get; set; }
        public CountryViewModel Country { get; set; }
        public Guid CountryId { get; set; }
        public Guid GenderId { get; set; }

        public GenderViewModel Gender { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool LockoutEnabled { get; set; }

    }
}

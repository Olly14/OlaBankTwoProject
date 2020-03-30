using System;
using System.Collections.Generic;
using System.ComponentModel;



namespace Bank.App.Models
{
    //Todo: Rename encoded to urikey
    public class AccountViewModel
    {
        //private readonly RSaWithCspKey _rsaWithCspKey;
        public AccountViewModel()
        {
            AccountTransactions =
                new List<AccountTransactionViewModel>();
            NumberOfAccountsAllowed = 2;
        }

        public string AccountId { get; set; }

        public string AccUriKey { get; set; }
        public string PersonalAccountNumber { get; set; }

        [DisplayNameAttribute("Account Type")]
        public string AccountTypeName { get; set; }

        public int PinCode { get; set; }

        [DisplayNameAttribute("Current Balance")]
        public double CurrentBalance { get; set; }

        [DisplayNameAttribute("Opening Balance")]
        public double OpeningBalance { get; set; }

        [DisplayNameAttribute("Opening Date")]
        public DateTime OpeningDate { get; set; }

        [DisplayNameAttribute("Is Blocked ?")]
        public bool IsBlocked { get; set; }

        [DisplayNameAttribute("Number Of Accounts")]
        public int NumberOfAccounts { get; set; }

        [DisplayNameAttribute("Account Owner")]
        public string AccountOwner { get; set; }

        [DisplayNameAttribute("First Name")]
        public string FirstName { get; set; }

        [DisplayNameAttribute("Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }


        //[ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
        public string Id { get; set; }

        public string IdEncoded { get; set; }

        [DisplayNameAttribute("Account Type")]
        public string AccountTypeId { get; set; }

        public double Rate { get; set; }
        public string CurrencyId { get; set; }

        public AppUserViewModel AppUser { get; set; }
        public AccountTypeViewModel AccountType { get; set; }
        public CountryViewModel Country { get; set; }
        public GenderViewModel Gender { get; set; }

        public string UriKey { get; set; }

        public string UiControl { get; set; }

        public bool IsDeleted { get; set; }

        public string AppUserEncoded { get; set; }

        public int NumberOfAccountsAllowed { get; set; }

        public List<AccountTransactionViewModel> AccountTransactions { get; set; }

    }
}

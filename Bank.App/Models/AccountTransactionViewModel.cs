using Bank.App.Models.ModelValidators.AccountValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bank.App.Models
{
    
    public class AccountTransactionViewModel
    {
        [DisplayNameAttribute("Account Transaction Id")]
        public string AccountTransactionId { get; set; }

        [DisplayNameAttribute("Id")]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string AppUserId { get; set; }
        [DisplayNameAttribute("Order By Type")]
        public string OrderByTypeId { get; set; }
        [DisplayNameAttribute("Order By Type Name")]

        public string AccountTypeId { get; internal set; }
        public string OrderByTypeName { get; set; }

        [DisplayNameAttribute("Transaction Type")]
        public string TransactionTypeId { get; set; }

        [DisplayNameAttribute("Transaction Type Name")]
        public string TransactionTypeName { get; set; }

        [DisplayNameAttribute("Account To Debit")]
        public string AccountToDebit { get; set; }

        [DisplayNameAttribute("Account To Credit")]
        public string AccountToCredit { get; set; }

        [DisplayNameAttribute("Amount To Credit")]
        public double AmountToCredit { get; set; }

        [DisplayNameAttribute("Reference")]
        public string Reference { get; set; }

        [DisplayNameAttribute("Date Of Transaction")]
        public DateTime DateOfTransaction { get; set; }

        [DisplayNameAttribute("New Balance Of Debited Account")]
        public double NewBalanceOfDebitedAccount { get; set; }


        [DisplayNameAttribute("New Balance Of Credited Account")]
        public double NewBalanceOfCreditedAccount { get; set; }


        [DisplayNameAttribute("Current Balance Account To Credit")]
        public double CurrentBalanceAccountToCredit { get; set; }


        [DisplayNameAttribute("Current Balance Account To Debit")]
        public double CurrentBalanceAccountToDebit { get; set; }

        public string IdUriKey { get; set; }
        public string TxnUriKey { get; set; }
        public string AccUriKey { get; set; }
        public string TxnTypeUriKey { get; set; }
        public string AppUserUriKey { get; set; }
        public string AccountTypeIdUriKey { get; set; }
        public string UiControl { get; set; }
        //Navigation properties
        public AccountViewModel Account { get; set; }
        public TransactionTypeViewModel TransactionType { get; set; }
        public OrderByTypeViewModel OrderByType { get; set; }

        public List<AccountTypeViewModel> AccountTypesDDL => new List<AccountTypeViewModel>();
        public List<TransactionTypeViewModel> TransactionTypesDDL => new List<TransactionTypeViewModel>();
        public List<OrderByTypeViewModel> OrderByTypesDDL => new List<OrderByTypeViewModel>();

        public int NumberOfAccounts { get; set; }
    }
}

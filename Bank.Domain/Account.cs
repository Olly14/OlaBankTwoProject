using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Bank.Domain
{
    [Table("Accounts")]
    public class Account
    {
        private Account account;

        public Account()
        {
            AccountTransactions = new List<AccountTransaction>();
        }

        public Account(Account account)
        {
            this.account = account;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AccountId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PersonalAccountNumber { get; set; }


        public double Rate { get; set; }

        public double CurrentBalance { get; set; }

        public double OpeningBalance { get; set; }

        public DateTime OpeningDate { get; set; }

        public bool IsBlocked { get; set; }

        //[ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
        public string Id { get; set; }
        public string AccountTypeId { get; set; }

        
        

        public  List<AccountTransaction> AccountTransactions { get; set; }
        public string CurrencyId { get; set; }

        public bool IsDeleted { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual void CalculateRate() { }

    }
}

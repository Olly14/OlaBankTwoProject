using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.Domain
{
    [Table("AccountTransactions")]
    public class AccountTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AccountTransactionId { get; set; }
        public string AccountId { get; set; }
        //public int AppUserId { get; set; }
        public string OrderByTypeId { get; set; }
        public string AccountToDebit { get; set; }
        public string AccountToCredit { get; set; }
        public double AmountToCredit { get; set; }
        public string Reference { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public double NewBalanceOfDebitedAccount { get; set; }
        public double NewBalanceOfCreditedAccount { get; set; }
        public double CurrentBalanceAccountToCredit { get; set; }


        //Navigation properties
        public Account Account { get; set; }
        public TransactionType TransactionType { get; set; }
        public OrderByType OrderByType { get; set; }

        //public AppUser AppUser { get; set; }
    }
}

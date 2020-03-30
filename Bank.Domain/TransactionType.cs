using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.Domain
{
    [Table("TransactionTypes")]
    public class TransactionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TransactionTypeId { get; set; }
        public string Type { get; set; }


        //Navigation property
        public virtual IEnumerable<Account> Accounts { get; set; }
    }
}

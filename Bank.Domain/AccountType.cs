using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bank.Domain
{
    [Table("AccountTypes")]
    public class AccountType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AccountTypeId { get; set; }
        public string Type { get; set; }

        //Navigation property
        public virtual IEnumerable<Account> Accounts { get; set; }
    }
}

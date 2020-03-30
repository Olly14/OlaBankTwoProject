using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bank.Domain
{
    [Table("Currencies")]
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CurrencyId { get; set; }
        public string Type { get; set; }
        public string CurrencyName { get; set; }


        //Navigation property
        public IEnumerable<Account> Accounts { get; set; }
    }
}

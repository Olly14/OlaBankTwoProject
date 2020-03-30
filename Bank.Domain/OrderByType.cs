using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank.Domain
{
    [Table("OrderByTypes")]
    public class OrderByType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderByTypeId { get; set; }
        public string Type { get; set; }


        //Navigation property
        public IEnumerable<AccountTransaction> AccountTransactions { get; set; }
    }
}

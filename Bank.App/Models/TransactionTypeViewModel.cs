using System;
using System.Collections.Generic;

namespace Bank.App.Models
{
    public class TransactionTypeViewModel
    {
        public string TransactionTypeId { get; set; }
        public string Type { get; set; }


        //Navigation property
        public IEnumerable<AccountTypeViewModel> Accounts { get; set; }
    }
}



using System;
using System.Collections.Generic;

namespace Bank.App.Models
{
    public class AccountTypeViewModel
    {
        public string AccountTypeId { get; set; }
        public string Type { get; set; }
        //Navigation property
        public virtual IEnumerable<AccountViewModel> Accounts { get; set; }
    }
}

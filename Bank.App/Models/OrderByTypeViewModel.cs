using System;
using System.Collections.Generic;


namespace Bank.App.Models
{
    public class OrderByTypeViewModel
    {
        public string OrderByTypeId { get; set; }
        public string Type { get; set; }


        //Navigation property
        public IEnumerable<AccountViewModel> Accounts { get; set; }
    }
}

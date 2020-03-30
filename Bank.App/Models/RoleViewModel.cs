using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Models
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            RoleUsers = new List<string>();
        }

        public string Id { get; set; }

        public string UriKey { get; set; }
        public string Name { get; set; }

        public List<string> RoleUsers { get; set; }

        public string UIControl { get; set; }
    }
}

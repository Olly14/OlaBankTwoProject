using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Models
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string Urikey { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}

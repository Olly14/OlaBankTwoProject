using Microsoft.AspNetCore.Identity;
using System;


namespace Bank.Domain
{
    public class Role : IdentityRole
    {
        //public string Id { get; set; }
        public string Urikey { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}

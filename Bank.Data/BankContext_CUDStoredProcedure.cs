using Bank.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data
{
    public partial class BankContext : IdentityDbContext<AppUser>
    {
    }
}

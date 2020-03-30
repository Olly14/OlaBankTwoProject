using Bank.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Bank.Data
{
    public partial class BankContext : IdentityDbContext<AppUser>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<OrderByType> OrderByTypes { get; set; }
        public DbSet<CurrentAccount> CurrentAccounts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<SavingAccount> SavingAccounts { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }


        //For UI creation
        //public DbSet<Role> Roles { get; set; }
    }
}

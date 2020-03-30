using System.Threading;
using Bank.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data
{
    public partial class BankContext : IdentityDbContext<AppUser>
    {



        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEntitiesRelationship(modelBuilder);
        }

        public void MapTableNames(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }


        private void ConfigureEntitiesRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne<AppUser>(a => a.AppUser)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.Id).IsRequired();

            modelBuilder.Entity<AppUser>()
                .HasOne<Country>(a => a.Country)
                .WithMany(c => c.AppUsers)
                .HasForeignKey(a => a.CountryId);


            modelBuilder.Entity<AppUser>()
                .HasOne<Gender>(a => a.Gender)
                .WithMany(c => c.AppUsers)
                .HasForeignKey(a => a.GenderId).IsRequired();

            modelBuilder.Entity<Account>()
                .HasOne<AccountType>(a => a.AccountType)
                .WithMany(acctType => acctType.Accounts)
                .HasForeignKey(a => a.AccountTypeId).IsRequired();

            modelBuilder.Entity<Account>()
                .HasOne<Currency>(a => a.Currency)
                .WithMany(cu => cu.Accounts)
                .HasForeignKey(a => a.CurrencyId).IsRequired();

            modelBuilder.Entity<AccountTransaction>()
                .HasOne<Account>(at => at.Account)
                .WithMany(a => a.AccountTransactions)
                .HasForeignKey(a => a.AccountId).IsRequired();


            modelBuilder.Entity<AccountTransaction>()
                .HasOne<OrderByType>(at => at.OrderByType)
                .WithMany(ot => ot.AccountTransactions)
                .HasForeignKey(ot => ot.OrderByTypeId).IsRequired();

        }

        public virtual void Commit(CancellationToken cancellationToken)
        {
            base.SaveChangesAsync(cancellationToken);
        }


    }
}

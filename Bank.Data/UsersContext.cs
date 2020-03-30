using Microsoft.EntityFrameworkCore;
using System;
using Bank.Domain;

namespace Bank.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapKeysAndPrecision(modelBuilder);
            ConfigureEntitiesRelationship(modelBuilder);
        }

        private void ConfigureEntitiesRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClaim>()
                .HasOne<User>(uc => uc.User)
                .WithMany(u => u.Claims)
                .HasForeignKey(uc => uc.SubjectId).IsRequired();

            modelBuilder.Entity<UserLogin>()
                .HasOne<User>(ul => ul.User)
                .WithMany(u => u.Logins)
                .HasForeignKey(ul => ul.SubjectId).IsRequired();

            modelBuilder.Entity<User>()
                .HasMany<UserClaim>(u => u.Claims).WithOne(c => c.User);


        }


        private void MapKeysAndPrecision(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.SubjectId);
            modelBuilder.Entity<UserClaim>().HasKey(uc => uc.Id);
            modelBuilder.Entity<UserLogin>().HasKey(ul => ul.Id);

        }
        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
    }
}

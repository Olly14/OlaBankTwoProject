using Bank.Data.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Infrastructure.Persistence
{
    public class BankContextDbContextFactory: IDesignTimeDbContextFactory<BankContext> 
    {
        private readonly IConfiguration _configration;

        public BankContextDbContextFactory(IConfiguration configuretion)
        {
            _configration = configuretion;
        }
        public BankContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankContext>();
            optionsBuilder.UseSqlServer(_configration.GetConnectionString("BankDbConnectionString"), b => b.MigrationsAssembly("Bank.App"));

            return new BankContext(optionsBuilder.Options);
        }
    }
}

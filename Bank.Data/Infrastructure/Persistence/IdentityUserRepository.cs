using Bank.Data.Infrastructure.Repository;
using Bank.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Infrastructure.Persistence
{
    public class IdentityUserRepository : Repository<AppUser>, IRepository<AppUser>
    {
        public IdentityUserRepository(BankContext bankContext) : base(bankContext)
        {

        }
    }
}

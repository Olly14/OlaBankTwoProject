using Bank.Data.Infrastructure.Repository;
using Bank.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Infrastructure.Persistence.AppUserRepository
{
    public class UnitOfWorkAppUserRepo : UnitOfWorkB<AppUser>, IUnitOfWorkB<AppUser>
    {
        public UnitOfWorkAppUserRepo(BankContext bankContext) : base(bankContext)
        {

        }
    }
}

using Bank.Data.Infrastructure.Repository;
using Bank.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Infrastructure.Persistence.AccountRepository
{
    public class AccountTransactionRepository : Repository<AccountTransaction>, IRepository<AccountTransaction>
    {
        public AccountTransactionRepository(BankContext bankContext) : base(bankContext)
        {

        }
    }
}

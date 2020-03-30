using Bank.Data.Infrastructure.Repository.IAccountsRepository;
using Microsoft.EntityFrameworkCore;
using Bank.Domain;

namespace Bank.Data.Infrastructure.Persistence.AccountsRepository
{
    public class CurrentAccountRepository : Repository<CurrentAccount>, ICurrentAccountRepository
    {
        public CurrentAccountRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}

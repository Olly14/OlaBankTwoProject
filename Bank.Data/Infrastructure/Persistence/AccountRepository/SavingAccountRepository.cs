using Bank.Domain;

namespace Bank.Data.Infrastructure.Persistence.AccountsRepository
{
    public class SavingAccountRepository : Repository<Account>
    {
        public SavingAccountRepository(BankContext bankContext) : base(bankContext)
        {
            
        }
    }
}

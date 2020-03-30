using Bank.Data.Infrastructure.Repository;
using Bank.Domain;


namespace Bank.Data.Infrastructure.Persistence.AccountRepository
{
    public class UnitOfWorkAccountRepo : UnitOfWorkB<Account>, IUnitOfWorkB<Account>
    {
        public UnitOfWorkAccountRepo(BankContext bankContext) : base(bankContext)
        {

        }
    }
}

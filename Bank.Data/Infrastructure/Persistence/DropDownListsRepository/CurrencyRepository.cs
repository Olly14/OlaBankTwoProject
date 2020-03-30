using Bank.Data.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Bank.Domain;

namespace Bank.Data.Infrastructure.Persistence.DropDownListsRepository
{
    public class CurrencyRepository : DropDownListRepository<Currency>
    {
        public CurrencyRepository(BankContext bankContext) : base(bankContext)
        {

        }

    }
}

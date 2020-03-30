using Bank.Data.Infrastructure.Persistence;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Data.Infrastructure.Persistence.DropDownListsRepository
{
    public class TransactionTypeRepository : DropDownListRepository<TransactionType>, ITransactionType
    {
        public TransactionTypeRepository(BankContext bankContext) : base(bankContext)
        {

        }

        public async Task<TransactionType> FindByType(string txnType)
        {
            return await Task.Run(() => BankDbContext.TransactionTypes
                                            .Where(tt => tt.Type.Equals(txnType))
                                            .FirstOrDefault());
        }
    }
}

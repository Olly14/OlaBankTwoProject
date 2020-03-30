using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using System.Linq;
using System.Threading.Tasks;




namespace Bank.Data.Infrastructure.Persistence.DropDownListsRepository
{
    public class OrderByTypeRepository : DropDownListRepository<OrderByType>, IOrderByTypeRepository
    {
        public  OrderByTypeRepository(BankContext bankContext) : base(bankContext)
        {

        }

        public async Task<OrderByType> FindByType(string txnType)
        {
            return await Task.Run(() => BankDbContext.OrderByTypes
                                            .Where(o => o.Type.Equals(txnType))
                                            .FirstOrDefault());
        }
    }
}

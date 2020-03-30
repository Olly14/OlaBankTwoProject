using Bank.Domain;
using System.Threading.Tasks;



namespace Bank.Data.Infrastructure.Repository.IDropDownListsRepository
{
    public interface IOrderByTypeRepository : IDropDownListRepository<OrderByType>
    {
        Task<OrderByType> FindByType(string txnType);
    }
}

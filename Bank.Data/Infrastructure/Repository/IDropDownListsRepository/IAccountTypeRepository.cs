using Bank.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Data.Infrastructure.Repository.IDropDownListsRepository
{
    public interface IAccountTypeRepository : IDropDownListRepository<AccountType>
    {
        Task<IEnumerable<AccountType>> FindAllAccountTypesByAccountTypeIdAsync(string accountTypeId);
        Task<IEnumerable<AccountType>> FindAllAccountTypesLessThisAccountTypeIdAsync(string type);
    }
}

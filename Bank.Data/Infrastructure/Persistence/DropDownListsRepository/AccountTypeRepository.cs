
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Data.Infrastructure.Persistence.DropDownListsRepository
{
    public class AccountTypeRepository : DropDownListRepository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(BankContext bankContext) : base(bankContext)
        {
            
        }


        public async Task<IEnumerable<AccountType>> FindAllAccountTypesByAccountTypeIdAsync(string accountTypeId)
        {
            return await Task.Run(() => BankDbContext.AccountTypes.Where(a => a.AccountTypeId == accountTypeId).ToList());
        }
        public async Task<IEnumerable<AccountType>> FindAllAccountTypesLessThisAccountTypeIdAsync(string accountTypeId)
        {
            return await Task.Run(() => BankDbContext.AccountTypes.Where(a => !a.AccountTypeId.Equals(accountTypeId)).ToList());
        }
    }
}

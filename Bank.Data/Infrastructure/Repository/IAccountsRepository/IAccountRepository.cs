using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain;

namespace Bank.Data.Infrastructure.Repository.IAccountsRepository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> FindAccountsByUserIdAsync(string userId);
        Task<Account> FindAccountIncludeAppUserAsync(string accountId);
        Task<IEnumerable<Account>> FindNonBlockedDeleteAccountsAsync();
        Task<Account> CalculateAccountInterestAsync(Account account);
        Task<IEnumerable<Account>> FindAccountsWithAccountOwnersAndAccountTypesAsync();
        Task<Account> FindAccountsWithAccountOwnersAndAccountTypesAsync(string accountId);
        Task<IEnumerable<Account>> FindAccountsByAccountTypeAsync(string type);
        Task<IEnumerable<Account>> FindAccountWithAccountTypesAsync(string accountId);
        Task<IEnumerable<Account>> FindAccountsByAccountTypeAsync();
        Task<IEnumerable<Account>> FindAccountsByAppUserIdAsync(string appUserId);
        Task<Account> FindByAccountTypeAndAppUserIdAsync(string appuserId, string acctTypeId);
        Task<IEnumerable<Account>> FindAccountsIncludeRelatedClassesAsync();
        Task<Account> FindAccountsIncludeRelatedClassesAsync(string acccountId);
        Task<Account> FindAccountsIncludeRelatedClassesAsync(string acccountId, string accountTypeId);
    }
}

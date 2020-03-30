using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Data.Infrastructure.Persistence.AccountRepository;
using Bank.Data.Infrastructure.Repository;
using Bank.Data.Infrastructure.Repository.IAccountsRepository;
using Bank.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data.Infrastructure.Persistence.AccountsRepository
{

    
    public class AccountRepository : Repository<Account>, IAccountRepository
    {

        private readonly IAccountRepositoryCalculateInterest _accountRepositoryCalculateInterest;



        public AccountRepository(BankContext bankContext, IAccountRepositoryCalculateInterest accountRepositoryCalculateInterest) : base(bankContext)
        {
            _accountRepositoryCalculateInterest = accountRepositoryCalculateInterest;
        }



        public async Task<Account> FindAccountIncludeAppUserAsync(string accountId)
        {
            return await Task.Run(() => BankDbContext.Accounts
                .Where(a => a.AccountId == accountId && a.IsDeleted != true && a.IsBlocked != true)
                .Include(a => a.AppUser)
                .SingleOrDefault());

        }

        public async Task<IEnumerable<Account>> FindAccountsIncludeRelatedClassesAsync()
        {
            return await Task.Run(() => BankDbContext.Accounts
                                .Where(a => a.IsDeleted != true && a.IsBlocked != true)
                                .Include(a => a.AppUser)
                                .Include(a => a.AccountType)
                                .Include(a => a.Currency));
        }

        public async Task<Account> FindAccountsIncludeRelatedClassesAsync(string accountId)
        {
            return await Task.Run(() => BankDbContext.Accounts
                                .Where(a => a.AccountId.Equals(accountId) && a.IsDeleted != true && a.IsBlocked != true)
                                .Include(a => a.AppUser)
                                .Include(a => a.AccountType)
                                .Include(a => a.Currency).FirstOrDefault());
        }

        public async Task<Account> FindAccountsIncludeRelatedClassesAsync(string accountId, string accountTypeId)
        {
            return await Task.Run(() => BankDbContext.Accounts
                                .Where(a => a.AccountId.Equals(accountId) && a.AccountTypeId.Equals(accountTypeId) && a.IsDeleted != true && a.IsBlocked != true)
                                .Include(a => a.AppUser)
                                .Include(a => a.AccountType)
                                .Include(a => a.Currency).FirstOrDefaultAsync());
        }

        public async Task<Account> CalculateAccountInterestAsync(Account account)
        {
            return await _accountRepositoryCalculateInterest.CalculateInterestAsync(account);
        }

        public async Task<IEnumerable<Account>> FindAccountsWithAccountOwnersAndAccountTypesAsync()
        {
            return await Task.Run(() => BankDbContext.Accounts
                        .Where(a => a.IsDeleted != true && a.IsBlocked != true)
                        .Include(a => a.AppUser)
                        .Include(a => a.AccountType));
        }

        public async Task<IEnumerable<Account>> FindAccountWithAccountTypesAsync(string accountId)
        {
            return await Task.Run(() => BankDbContext.Accounts
                .Where(a => a.AccountId == accountId && a.IsDeleted != true && a.IsBlocked != true)
                .Include(a => a.AccountType));
        }
        public async Task<Account> FindAccountsWithAccountOwnersAndAccountTypesAsync(string accountId)
        {
            return await Task.Run(() => BankDbContext.Accounts
                        .Where(a => a.AccountId == accountId && a.IsDeleted != true && a.IsBlocked != true)
                        .Include(a => a.AppUser)
                        .Include(a => a.AccountType)
                        .FirstOrDefault());
        }

        public async Task<IEnumerable<Account>> FindAccountsByAccountTypeAsync(string type)
        {
            return await Task.Run(() => BankDbContext.Accounts
                    .Include(a => a.AccountType)
                    .Where(a => a.AccountType.Type.Equals(type) && a.IsDeleted != true && a.IsBlocked != true));
        }

        public async Task<IEnumerable<Account>> FindAccountsByAccountTypeAsync()
        {
            return await Task.Run(() => BankDbContext.Accounts
                    .Where(a => a.IsDeleted != true && a.IsBlocked != true)
                    .Include(a => a.AccountType));
        }


        public async Task<IEnumerable<Account>> FindAccountsByAppUserIdAsync(string appUserId)
        {
            return    await Task.Run(() => BankDbContext.Accounts
                    .Include(a => a.AppUser)
                    .Where(a => a.AppUser.AppUserId
                        .Equals(appUserId) && a.IsDeleted != true && a.IsBlocked != true));
        }

        public async Task<Account> FindByAccountTypeAndAppUserIdAsync(string appuserId, string acctTypeId)
        {
            //return await Task.Run(() => BankDbContext.Accounts.Include(a => a.AccountType).Where(a => a.AccountType.Type.Equals(acctTypeId)));
            return await Task.Run(() => BankDbContext.Accounts
                .Where(a => a.AppUserId
                                .Equals(appuserId) && a.AccountTypeId
                                .Equals(acctTypeId) && a.IsDeleted != true && a.IsBlocked != true)
                .ToList()
                .SingleOrDefault());
        }

        public async Task<IEnumerable<Account>> FindNonBlockedDeleteAccountsAsync()
        {
            return await Task.Run(() => BankDbContext.Accounts
                                .Where(a => a.IsDeleted != true && a.IsBlocked != true)
                                .ToList());
        }

        public async Task<IEnumerable<Account>> FindAccountsByUserIdAsync(string userId)
        {
            return await Task.Run(() => BankDbContext.Accounts
                .Include(a => a.AppUser)
                .Where(a => a.Id
                                .Equals(userId) && a.IsDeleted != true && a.IsBlocked != true));
        }
    }


}

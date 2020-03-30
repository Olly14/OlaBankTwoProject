using Bank.Data.Infrastructure.Repository;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace Bank.Data.Infrastructure.Repository
{


    public interface IUnitOfWork
    {
        IRepository<Account> AccountRepos { get;}
        IRepository<AppUser> AppUserRepos { get;}
        IRepository<AccountTransaction> AccountTransactionRepos { get;}
        IDropDownListRepository<AccountType> AccountTypeRepos { get;}
        IDropDownListRepository<Country> CountryRepos { get;}
        IDropDownListRepository<Currency> CurrencyRepos { get;}
        IDropDownListRepository<Gender> GenderRepos { get;}

        void Commit(CancellationToken cancellationToken);

        Account UpdateAccount(CancellationToken cancellationToken, Account account);
        AppUser UpdateAppUser(CancellationToken cancellationToken, AppUser appUser);
    }
}

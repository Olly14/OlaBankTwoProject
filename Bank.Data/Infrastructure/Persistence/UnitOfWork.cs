using Bank.Data.Infrastructure.Repository;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using System.Threading;


namespace Bank.Data.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private BankContext _bankContext;

        

        private IRepository<Account> _accountRepos;
        private IRepository<AppUser> _appUserRepos;
        private IRepository<AccountTransaction> _accountTransactionRepos;
        private IDropDownListRepository<AccountType> _accountTypeRepos;
        private IDropDownListRepository<Country> _countryRepos;
        private IDropDownListRepository<Currency> _currencyRepos;
        private IDropDownListRepository<Gender> _genderRepos;

        public UnitOfWork(BankContext bankContext, 
            IRepository<Account> accountRepos,
            IRepository<AppUser> appUserRepos,
            IRepository<AccountTransaction> accountTransactionRepos,
            IDropDownListRepository<AccountType> accountTypeRepos,
            IDropDownListRepository<Country> countryRepos,
            IDropDownListRepository<Currency> currencyRepos,
            IDropDownListRepository<Gender> genderRepos)
        {
            _bankContext = bankContext;
            _accountRepos = accountRepos;
            _appUserRepos = appUserRepos;
            _accountTransactionRepos = accountTransactionRepos;
            _countryRepos = countryRepos;
            _currencyRepos = currencyRepos;
            _genderRepos = genderRepos;
            _accountTypeRepos = accountTypeRepos;

        }

        public BankContext BankContext
        {
            get { return _bankContext; }
        }

        public IRepository<Account> AccountRepos { get => _accountRepos;}
        public IRepository<AppUser> AppUserRepos { get => _appUserRepos;}
        public IRepository<AccountTransaction> AccountTransactionRepos { get => _accountTransactionRepos;}
        public IDropDownListRepository<AccountType> AccountTypeRepos { get => _accountTypeRepos;}
        public IDropDownListRepository<Country> CountryRepos { get => _countryRepos;}
        public IDropDownListRepository<Currency> CurrencyRepos { get => _currencyRepos;}
        public IDropDownListRepository<Gender> GenderRepos { get => _genderRepos;}

        public void Commit(CancellationToken cancellationToken)
        {
            _bankContext.Commit(cancellationToken);
        }

        public Bank.Domain.Account UpdateAccount(CancellationToken cancellationToken, Bank.Domain.Account account) 
        {
            var newAttachedAccount = _bankContext.Accounts.Attach(account);
            newAttachedAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.Commit(cancellationToken);
            return account;
        }
        public Bank.Domain.AppUser UpdateAppUser(CancellationToken cancellationToken, Bank.Domain.AppUser appUser)
        {
            var newAttachedAccount = _bankContext.AppUsers.Attach(appUser);
            newAttachedAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.Commit(cancellationToken);
            return appUser;
        }

        public TEntity Update<TEntity>(CancellationToken cancellationToken, TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bank.Domain;

namespace Bank.Data.Infrastructure.Persistence.AccountRepository
{
    public class AccountRepositoryCalculateInterest : IAccountRepositoryCalculateInterest
    {
        private string _accountTypeName;
        private Account _account;
        private CurrentAccount _interestAddedCurrentAccount;
        private SavingAccount _interestAddedSavingAccount;

        public async Task<Account> CalculateInterestAsync(Account account)
        {
            return await Task.Run(() => CalculateInterest(account));
        }

        private Account CalculateInterest(Account account)
        {
            _account = account;
            _accountTypeName = account.AccountType.Type;
            _interestAddedCurrentAccount = new CurrentAccount();
            _interestAddedSavingAccount = new SavingAccount();
            switch (_accountTypeName)
            {
                case "Current Account":
                    _interestAddedCurrentAccount = new CurrentAccount();
                    _interestAddedCurrentAccount.CurrentBalance = account.CurrentBalance;
                    _interestAddedCurrentAccount.CalculateRate();
                    _account.CurrentBalance = _interestAddedCurrentAccount.CurrentBalance;
                    break;
                case "Saving Account":
                    _interestAddedSavingAccount = new SavingAccount();
                    _interestAddedSavingAccount.CurrentBalance = account.CurrentBalance;
                    _interestAddedSavingAccount.CalculateRate();
                    _account.CurrentBalance = _interestAddedSavingAccount.CurrentBalance;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            return _account;
        }
    }
}

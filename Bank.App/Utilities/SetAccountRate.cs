using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Bank.App.Models;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;

namespace Bank.App.Utilities
{
    public class SetAccountRate : ISetAccountRate
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        private IMapper _mapper;
        private string _typeControl = string.Empty;
        private SavingAccount _savingAccount;
        private CurrentAccount _currentAccount;
        public SetAccountRate(IAccountTypeRepository accountTypeRepository, IMapper mapper)
        {
            _accountTypeRepository = accountTypeRepository;
            _mapper = mapper;
            _savingAccount = new SavingAccount();
            _currentAccount = new CurrentAccount();
        }
        public async Task<AccountViewModel> SetRateAsync(AccountViewModel accountViewModel)
        {
            var account = _mapper.Map<Account>(accountViewModel);
            return _mapper.Map<AccountViewModel>(await Task.Run(() => SetRateForAccountAsync(account)));
        }

        private async Task<Account> SetRateForAccountAsync(Account account)
        {
            var id = account.AccountTypeId;
            _typeControl = (await _accountTypeRepository.FindAsync(id)).Type;

            switch (_typeControl)
            {
                case "Current Account":
                    account.Rate = _currentAccount.Rate;
                    break;
                case "Saving Account":
                    account.Rate = _savingAccount.Rate;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            return account;
        }
    }
}

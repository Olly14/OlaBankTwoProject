using Bank.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Domain;

namespace Bank.App.Utilities
{
    public interface IMaskIds
    {
        Task<IEnumerable<CountryViewModel>> EncodeCountryIds(IEnumerable<CountryViewModel> countries);
        Task<IEnumerable<AccountTypeViewModel>> EncodeAccountTypeIds(IEnumerable<AccountTypeViewModel> accountTypes);
        Task<IEnumerable<CurrencyViewModel>> EncodeCurrencyIds(IEnumerable<CurrencyViewModel> currencies);
        Task<IEnumerable<GenderViewModel>> EncodeGenderIds(IEnumerable<GenderViewModel> genders);
        Task<IEnumerable<OrderByTypeViewModel>> EncodeOrderByTypeIds(IEnumerable<OrderByTypeViewModel> orderByTypes);
        Task<IEnumerable<TransactionTypeViewModel>> EncodeTransactionTypeIds(IEnumerable<TransactionTypeViewModel> transactionTypes);
        Task<AccountTypeViewModel> EncodeAccountTypeId(AccountTypeViewModel accountType);
        Task<IEnumerable<AccountType>> EncodeAccountTypeIds(IEnumerable<AccountType> accountTypes);
        Task<CountryViewModel> EncodeCountryId(CountryViewModel country);
        Task<CurrencyViewModel> EncodeCurrencyId(CurrencyViewModel currency);
        Task<GenderViewModel> EncodeGenderId(GenderViewModel gender);
        Task<TransactionTypeViewModel> EncodeTransactionTypeId(TransactionTypeViewModel transactionType);
    }
}

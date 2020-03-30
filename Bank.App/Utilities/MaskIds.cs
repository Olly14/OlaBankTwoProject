using AutoMapper;
using Bank.App.Models;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.App.CustomSecurity;

namespace Bank.App.Utilities
{
    public class MaskIds : IMaskIds
    {
        private List<TransactionTypeViewModel> _transactionTypes;

        private IDropDownListRepository<TransactionType> _transactionTypeRepo;
        private IMapper _mapper;

        public async Task<AccountTypeViewModel> EncodeAccountTypeId(AccountTypeViewModel accountType)
        {

            return await Task.Run(() =>
            {
                accountType.AccountTypeId = GuidEncoder.Encode(accountType.AccountTypeId);
                return accountType;
            });
        }

        public async Task<IEnumerable<AccountTypeViewModel>> EncodeAccountTypeIds(IEnumerable<AccountTypeViewModel> accountTypes)
        {
            if (accountTypes.Count() <= 0)
            {
                return await Task.Run(() => accountTypes);
            }

            return await Task.Run(() => accountTypes.Select(at =>
            {
                at.AccountTypeId = GuidEncoder.Encode(at.AccountTypeId);
                return at;
            }));
        }

        public async Task<IEnumerable<AccountType>> EncodeAccountTypeIds(IEnumerable<AccountType> accountTypes)
        {
            if (accountTypes.Count() <= 0)
            {
                return await Task.Run(() => accountTypes);
            }

            return await Task.Run(() => accountTypes.Select(at =>
            {
                at.AccountTypeId = GuidEncoder.Encode(at.AccountTypeId);
                return at;
            }));
        }

        public async Task<IEnumerable<CountryViewModel>> EncodeCountryIds(IEnumerable<CountryViewModel> countries)
        {
            if (countries.Count() <= 0)
            {
                return await Task.Run(() => countries);
            }

            return await Task.Run(() => countries.Select(c =>
            {
                c.CountryId = GuidEncoder.Encode(c.CountryId);
                return c;
            }));
        }

        public async Task<CountryViewModel> EncodeCountryId(CountryViewModel country)
        {

            return await Task.Run(() =>
            {
                country.CountryId = GuidEncoder.Encode(country.CountryId);
                return country;
            });
        }

        public async Task<IEnumerable<CurrencyViewModel>> EncodeCurrencyIds(IEnumerable<CurrencyViewModel> currencies)
        {
            if (currencies.Count() <= 0)
            {
                return await Task.Run(() => currencies);
            }

            return await Task.Run(() => currencies.Select(c =>
            {
                c.CurrencyId = GuidEncoder.Encode(c.CurrencyId);
                return c;
            }));
        }

        public async Task<CurrencyViewModel> EncodeCurrencyId(CurrencyViewModel currency)
        {

            return await Task.Run(() =>
            {
                currency.CurrencyId = GuidEncoder.Encode(currency.CurrencyId);
                return currency;
            });
        }

        public async Task<IEnumerable<GenderViewModel>> EncodeGenderIds(IEnumerable<GenderViewModel> genders)
        {
            if (genders.Count() <= 0)
            {
                return await Task.Run(() => genders);
            }

            return await Task.Run(() => genders.Select(g =>
            {
                g.GenderId = GuidEncoder.Encode(g.GenderId);
                return g;
            }));
        }

        public async Task<GenderViewModel> EncodeGenderId(GenderViewModel gender)
        {

            return await Task.Run(() =>
            {
                gender.GenderId = GuidEncoder.Encode(gender.GenderId);
                return gender;
            });
        }

        public async Task<IEnumerable<OrderByTypeViewModel>> EncodeOrderByTypeIds(IEnumerable<OrderByTypeViewModel> orderByTypes)
        {
            if (orderByTypes.Count() <= 0)
            {
                return await Task.Run(() => orderByTypes);
            }

            return await Task.Run(() => orderByTypes.Select(obt =>
            {
                obt.OrderByTypeId = GuidEncoder.Encode(obt.OrderByTypeId);
                return obt;
            }));
        }



        public async Task<IEnumerable<TransactionTypeViewModel>> EncodeTransactionTypeIds(IEnumerable<TransactionTypeViewModel> transactionTypes)
        {
            if (transactionTypes.Count() <= 0)
            {
                return await Task.Run(() => transactionTypes);
            }

            return await Task.Run(() => transactionTypes.Select(tt =>
            {
                tt.TransactionTypeId = GuidEncoder.Encode(tt.TransactionTypeId);
                return tt;
            }));
        }

        public async Task<TransactionTypeViewModel> EncodeTransactionTypeId(TransactionTypeViewModel transactionType)
        {

            return await Task.Run(() =>
            {
                transactionType.TransactionTypeId = GuidEncoder.Encode(transactionType.TransactionTypeId);
                return transactionType;
            });
        }


    }
}

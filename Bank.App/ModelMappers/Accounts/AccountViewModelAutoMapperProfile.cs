using AutoMapper;
using Bank.App.Models;
using Bank.Domain;

namespace Bank.App.ModelMappers.Accounts
{
    public class AccountViewModelAutoMapperProfile : Profile
    {

        public AccountViewModelAutoMapperProfile()
        {
            CreateMap<Account, AccountViewModel>().ReverseMap();
            CreateMap<AccountType, AccountTypeViewModel>().ReverseMap();
            CreateMap<AccountTransactionViewModel, AccountTransactionViewModel>().ReverseMap();
            CreateMap<AccountTransaction, AccountTransactionViewModel>().ReverseMap();
           
            //CreateMap<SavingAccount, SavingAccountViewModel>().ReverseMap();

            //CreateMap<Domain.AppUser, AppUserViewModel>().ReverseMap();
        }

    }
}

using AutoMapper;
using Bank.App.Models;
using Bank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.ModelMappers.DropDownLists
{
    public class DropDownListsViewModelAutoMApperProfile : Profile
    {
        public DropDownListsViewModelAutoMApperProfile()
        {
            CreateMap<AccountType, AccountTypeViewModel>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<Currency, CurrencyViewModel>().ReverseMap();
            CreateMap<Gender, GenderViewModel>().ReverseMap();
            CreateMap<TransactionType, TransactionTypeViewModel>().ReverseMap();
            CreateMap<OrderByType, OrderByTypeViewModel>().ReverseMap();
        }
    }
}

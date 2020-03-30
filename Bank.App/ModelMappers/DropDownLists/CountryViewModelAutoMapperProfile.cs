using AutoMapper;
using Bank.App.Models;
using Bank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.ModelMappers.DropDownLists
{
    public class CountryViewModelAutoMapperProfile : Profile
    {
        public CountryViewModelAutoMapperProfile()
        {
            CreateMap<Country, CountryViewModel>().ReverseMap();
        }
    }
}

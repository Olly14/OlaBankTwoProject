using AutoMapper;
using Bank.App.Models;
using Bank.Domain;
using Microsoft.AspNetCore.Identity;

namespace Bank.App.ModelMappers.AppUsers
{
    public class AppUserViewModelAutoMapperProfile : Profile
    {
        public AppUserViewModelAutoMapperProfile()
        {
            CreateMap<AppUser, AppUserViewModel>().ReverseMap();
            CreateMap<RegistrationViewModel, AppUserViewModel>().ReverseMap();
            CreateMap<RegistrationViewModel, AppUser>().ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
        }

    }
}

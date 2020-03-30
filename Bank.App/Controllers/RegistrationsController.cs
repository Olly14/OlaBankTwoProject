using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bank.App.Models;
using Bank.Data.Infrastructure.Repository;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bank.App.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IDropDownListRepository<Country> _countryRepository;
        private readonly IDropDownListRepository<Gender> _genderRepository;
        //private readonly IDropDownListRepository<Currency> _currencyRepository;

        private readonly IUnitOfWorkB<AppUser> _unitOfWorkAppUser;
        private readonly IMapper _mapper;

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        

        public RegistrationsController(IRepository<AppUser> appUserRepository,
            IDropDownListRepository<Country> countryRepository,
            IDropDownListRepository<Gender> genderRepository,
            IUnitOfWorkB<AppUser> unitOfWorkAppUser,
            IMapper mapper,

            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _appUserRepository = appUserRepository;
            _countryRepository = countryRepository;
            _genderRepository = genderRepository;
            _unitOfWorkAppUser = unitOfWorkAppUser;
            _mapper = mapper;

            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            var newAppUserRegistration = new RegistrationViewModel();
            ViewBag.Countries = await GetCountriesAsync();
            ViewBag.Genders = await GetGendersAsync();
            return View(newAppUserRegistration);
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registration(RegistrationViewModel newAppUserRegistration)
        {
            if (ModelState.IsValid)
            {

                var newAppUser = _mapper.Map<AppUser>(newAppUserRegistration);
                newAppUser.UserName = newAppUserRegistration.Email;
                newAppUser.AppUserId = Guid.NewGuid().ToString();
                var createResult  = await _userManager.CreateAsync(newAppUser, newAppUser.Password);
                if (createResult.Succeeded)
                {
                    if (_signInManager.IsSignedIn(User) && User.IsInRole(("Bank Admin")))
                    {
                        return RedirectToAction("Index", "AppUsers");
                    }
                    await _signInManager.SignInAsync(newAppUser, false);
                    return RedirectToAction("Index", "AppUsers");
                }
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(newAppUserRegistration);
        }

        private async Task<IEnumerable<CountryViewModel>> GetCountriesAsync()
        {
            return _mapper.Map<IEnumerable<CountryViewModel>>(await _countryRepository.FindAllAsync());
        }

        private async Task<CountryViewModel> GetCountryAsync(string countryId)
        {
            return _mapper.Map<CountryViewModel>(await _countryRepository.FindAsync(countryId));
        }
        //private async Task<IEnumerable<CurrencyViewModel>> GetCurrencsAsync()
        //{
        //    return _mapper.Map<IEnumerable<CurrencyViewModel>>(await _currencyRepository.FindAllAsync());
        //}

        //private async Task<CurrencyViewModel> GetCurrencyAsync(System.Guid currencyId)
        //{
        //    return _mapper.Map<CurrencyViewModel>(await _currencyRepository.FindAsync(currencyId));
        //}
        private async Task<IEnumerable<GenderViewModel>> GetGendersAsync()
        {
            return _mapper.Map<IEnumerable<GenderViewModel>>(await _genderRepository.FindAllAsync());
        }

        private async Task<GenderViewModel> GetGenderAsync(string genderId)
        {
            return _mapper.Map<GenderViewModel>(await _genderRepository.FindAsync(genderId));
        }
    }
}
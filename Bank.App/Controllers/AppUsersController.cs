using AutoMapper;
using Bank.App.CustomSecurity;
using Bank.App.Models;
using Bank.Data.Infrastructure.Repository;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bank.App.Utilities;
using Bank.Data.Infrastructure.Repository.IAppUserRepository;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.EntityFrameworkCore;

namespace Bank.App.Controllers
{
    [Authorize]
    public class AppUsersController : Controller
    {

        private readonly IAppUserRepository _appUserRepository;
        private readonly IDropDownListRepository<Country> _countryRepository;
        private readonly IDropDownListRepository<Gender> _genderRepository;
        private readonly IDropDownListRepository<Currency> _currencyRepository;
        private readonly IMapper _mapper;
        private readonly IMaskIds _maskIds;


        private readonly IUnitOfWorkB<AppUser> _unitOfWorkAppUser;

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        private readonly bool _appUserIsHashed;

        private readonly CancellationToken _cancellationToken;

        public AppUsersController(IAppUserRepository appUserRepository,
            IDropDownListRepository<Country> countryRepository,
            IDropDownListRepository<Gender> genderRepository,
            IDropDownListRepository<Currency> currencyRepository,
            IUnitOfWorkB<AppUser> unitOfWorkAppUser,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,

            IMaskIds maskIds,
            IMapper mapper)
        {
            _cancellationToken = new CancellationToken();

            _appUserRepository = appUserRepository;
            _countryRepository = countryRepository;
            _genderRepository = genderRepository;
            _currencyRepository = currencyRepository;
            _unitOfWorkAppUser = unitOfWorkAppUser;

            _userManager = userManager;
            _signInManager = signInManager;

            _maskIds = maskIds;
            _mapper = mapper;
            _appUserIsHashed = false;
        }

        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> Index()
        {

            var users = await GetAppUserAsync();
            users = PopulateUriKeyAndAttriburteEncoded(users);
            users = await PopulateCountryIdValueAndGenderIdValue(users);
            return View(users);

        }

        public async Task<IActionResult> AppUserIndex(string id)
        {

            var users = _mapper.Map<IEnumerable<AppUserViewModel>>(
                                await _appUserRepository.FindNonBlockedDeleteAppUsersAsync(
                                        GuidEncoder.Decode(id).ToString()));
            users = PopulateUriKeyAndAttriburteEncoded(users);
            users = await PopulateCountryIdValueAndGenderIdValue(users);

            return View(users);

        }
        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> Create()
        {
            return RedirectToAction("Registration", "Registrations");
        }

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> Create(AppUserViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _appUserRepository.AddAsync(_mapper.Map<AppUser>(model));
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var decryptedId = GuidEncoder.Decode(id);
            var model = _mapper.Map<AppUserViewModel>(await _appUserRepository.FindAsync(decryptedId.ToString()));

            model.Gender = await GetGenderAsync(model.GenderId);
            model.Country = await GetCountryAsync(model.CountryId);
            model.UriKey = GuidEncoder.Encode(model.Id);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.Genders = await GetGendersAsync();
            ViewBag.Countries = await GetCountriesAsync();
            var decryptedId = GuidEncoder.Decode(id);
            var identityModel = await _userManager.FindByIdAsync(decryptedId.ToString());

            var model = _mapper.Map<AppUserViewModel>(await _appUserRepository.FindAsync(decryptedId.ToString()));
            model.Claims = (await _userManager.GetClaimsAsync(identityModel)).Select(c => c.Value).ToList();
            model.Roles = await _userManager.GetRolesAsync(identityModel);

            model.UiControl = "EditUi";
            model.UriKey = GuidEncoder.Encode(model.Id);

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(AppUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(GuidEncoder.Decode(model.Id).ToString());
            //var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User withId = {model.Id} cannot be found";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.FirstLineOfAddress = model.FirstLineOfAddress;
                    user.SecondLineOfAddress = model.SecondLineOfAddress;
                    user.Town = model.Town;
                    user.Postcode = model.Postcode;
                    user.DateOfBirth = model.DateOfBirth;
                    user.CountryId = model.CountryId;
                    user.GenderId = model.GenderId;
                    user.Email = model.Email;


                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }


            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> Delete(string id)
        {
            var decryptedId = GuidEncoder.Decode(id);
            var model = _mapper.Map<AppUserViewModel>(await _appUserRepository.FindAsync(decryptedId.ToString()));
            model.Gender = await GetGenderAsync(model.GenderId);
            model.Country = await GetCountryAsync(model.CountryId);
            model.UriKey = GuidEncoder.Encode(model.Id);


            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(AppUserViewModel model)
        {

            var toDeleteAppUser = await _appUserRepository.FindAsync(GuidEncoder.Decode(model.Id).ToString());
            toDeleteAppUser.IsDeleted = true;
            await _unitOfWorkAppUser.UpdateAsync(_cancellationToken, toDeleteAppUser);
            return RedirectToAction("Index");

            return View();
        }

        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> BlockUserApp(string id)
        {
            var decryptedId = GuidEncoder.Decode(id);
            var model = _mapper.Map<AppUserViewModel>(await _appUserRepository.FindAsync(decryptedId.ToString()));
            model.Gender = await GetGenderAsync(model.GenderId);
            model.Country = await GetCountryAsync(model.CountryId);

            return View(model);
        }

        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> UnBlockUserApp(string id)
        {
            var decryptedId = GuidEncoder.Decode(id);
            var model = _mapper.Map<AppUserViewModel>(await _appUserRepository.FindAsync(decryptedId.ToString()));
            model.Gender = await GetGenderAsync(model.GenderId);
            model.Country = await GetCountryAsync(model.CountryId);

            return View(model);
        }

        private async Task<IEnumerable<AppUserViewModel>> GetAppUserAsync()
        {
           /* var result =*/ 
            return _mapper.Map<IEnumerable<AppUserViewModel>>(await _appUserRepository.FindNonBlockedDeleteAppUsersAsync());
        }



        private IEnumerable<AppUserViewModel> PopulateUriKeyAndAttriburteEncoded(IEnumerable<AppUserViewModel> models)
        {
            models = models.Select(a =>
            {
                //a.UriKey = _dataProtector.Protect(a.AppUserId.ToString());
                a.UriKey = GuidEncoder.Encode(a.Id.ToString());
                a.AppUserIdEncoded = GuidEncoder.Encode(a.AppUserId.ToString());
                return a;
            });
            return models;
        }

        private async Task<IEnumerable<AppUserViewModel>> PopulateCountryIdValueAndGenderIdValue(IEnumerable<AppUserViewModel> models)
        {
            //models = models.Select(async a =>
            //{

            //    a.Gender = _mapper.Map<GenderViewModel>(await GetGenderAsync(a.AppUserId));
            //    return a;
            //});
            var listModels = models.ToList();
            var modelSize = listModels.Count;
            for (int i = 0; i < modelSize; i++)
            {
                listModels[i].Country = await GetCountryAsync(listModels[i].CountryId);
                listModels[i].CountryIdValue = listModels[i].Country.CountryName;
                listModels[i].Gender = await GetGenderAsync(listModels[i].GenderId);
                listModels[i].GenderIdValue = listModels[i].Gender.Type;
            }
            return models;
        }




        private async Task<IEnumerable<CountryViewModel>> GetCountriesAsync()
        {
            /*var result =*/
            return _mapper.Map<IEnumerable<CountryViewModel>>(await _countryRepository.FindAllAsync());
            //return await _maskIds.EncodeCountryIds(result);
        }

        private async Task<CountryViewModel> GetCountryAsync(string countryId)
        {
            /*var result =*/
            return _mapper.Map<CountryViewModel>(await _countryRepository.FindAsync(countryId));
            //return await _maskIds.EncodeCountryId(result);
        }
        private async Task<IEnumerable<CurrencyViewModel>> GetCurrencsAsync()
        {
            /*var result =*/
            return _mapper.Map<IEnumerable<CurrencyViewModel>>(await _currencyRepository.FindAllAsync());
            //return await _maskIds.EncodeCurrencyIds(result);
        }

        private async Task<CurrencyViewModel> GetCurrencyAsync(string currencyId)
        {
            /*var result =*/
            return _mapper.Map<CurrencyViewModel>(await _currencyRepository.FindAsync(currencyId));
            //return await _maskIds.EncodeCurrencyId(result);
        }
        private async Task<IEnumerable<GenderViewModel>> GetGendersAsync()
        {
            /*var result =*/
            return _mapper.Map<IEnumerable<GenderViewModel>>(await _genderRepository.FindAllAsync());
            //return await _maskIds.EncodeGenderIds(result);
        }

        private async Task<GenderViewModel> GetGenderAsync(string genderId)
        {
            return _mapper.Map<GenderViewModel>(await _genderRepository.FindAsync(genderId));
            //return await _maskIds.EncodeGenderId(result);
        }
    }
}
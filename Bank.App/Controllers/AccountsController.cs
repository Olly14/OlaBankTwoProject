using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bank.App.CustomSecurity;
using Bank.App.Models;
using Bank.App.Utilities;
using Bank.Data.Infrastructure.Repository;
using Bank.Data.Infrastructure.Repository.IAccountsRepository;
using Bank.Data.Infrastructure.Repository.IAppUserRepository;
using Bank.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bank.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Bank.App.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly IMaskIds _maskIds;
        private readonly IAccountRepository _accountRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IDropDownListRepository<Country> _countryRepository;
        private readonly IDropDownListRepository<Gender> _genderRepository;
        private readonly IDropDownListRepository<Currency> _currencyRepository;
        private readonly IAccountTypeRepository _accountTypeRepository;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitOfWorkB<Account> _unitOfWorkAccount;
        private readonly IMapper _mapper;
        private readonly ITransactionType _transactionTypeRepository;
        private readonly IOrderByTypeRepository _orderByTypeRepository;
        private readonly CancellationToken _cancellationToken;
        private readonly ISetAccountRate _setAccounRate;
        private readonly UserManager<AppUser> _userManager;


        public AccountsController(
            IMaskIds maskIds,
            //IRepository<Account> accountRepository,
            IAccountRepository accountRepository,
            IAppUserRepository appUserRepository,
            IDropDownListRepository<Country> countryRepository,
            IDropDownListRepository<Gender> genderRepository,
            IDropDownListRepository<Currency> currencyRepository,
            IAccountTypeRepository accountTypeRepository,
            ITransactionType transactionTypeRepository,
            IOrderByTypeRepository orderByTypeRepository,
            ISetAccountRate satAccountRate,


            UserManager<AppUser> userManager,
            IUnitOfWorkB<Account> unitOfWorkAccount,
            IMapper mapper)
        {
            _maskIds = maskIds;
            _accountRepository = accountRepository;
            _appUserRepository = appUserRepository;
            _countryRepository = countryRepository;
            _genderRepository = genderRepository;
            _currencyRepository = currencyRepository;
            _accountTypeRepository = accountTypeRepository;
            _transactionTypeRepository = transactionTypeRepository;
            _orderByTypeRepository = orderByTypeRepository;
            _userManager = userManager;
            _unitOfWorkAccount = unitOfWorkAccount;
            _cancellationToken = new CancellationToken();
            _setAccounRate = satAccountRate;
            _mapper = mapper;


        }


        [Authorize(Roles ="Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> Index()
        {
            await PopulateViewBagForDropDownLists();

            var models = await _accountRepository.FindAccountsWithAccountOwnersAndAccountTypesAsync();
            var mappedModels = _mapper.Map<IEnumerable<AccountViewModel>>(models);
            mappedModels = await PopulateOnwerNamesAsync(mappedModels);
            mappedModels = PopulateUriKeyWithId(mappedModels);
            mappedModels = await PopulateAccountTypesAsync(mappedModels);



            return View(mappedModels);
        }

        [HttpGet("Accounts/UserAccounts")]
        public async Task<IActionResult> UserAccounts(string userId)
        {
             

            var decryptedId = GuidEncoder.Decode(userId);

            var models = _mapper.Map<IEnumerable<AccountViewModel>>( await _accountRepository.FindAccountsByAppUserIdAsync(decryptedId.ToString()));

            models = await PopulateOnwerNamesAsync(models);

            models = PopulateUriKeyWithId(models);

            models = await PopulateAccountTypesAsync(models);

            return View(models);

        }


        [HttpGet("Accounts/UserAccountsByAccountId")]
        public async Task<IActionResult> UserAccountsByAccountId(string id)
        {


            var decryptedId = GuidEncoder.Decode(id);

            var acct = _mapper.Map<Account>(await _accountRepository.FindAccountIncludeAppUserAsync(decryptedId.ToString()));


            var models = _mapper.Map<IEnumerable<AccountViewModel>>(await _accountRepository.FindAccountsByUserIdAsync(acct.AppUser.Id));

            models = await PopulateOnwerNamesAsync(models);

            models = PopulateUriKeyWithId(models);

            //ViewBag.AppUserIdEncoded = GuidEncoder.Encode((models.FirstOrDefault(m => m.AppUserId != string.Empty)).AppUserId.ToString());

            return View("UserAccounts", models);

        }



        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<ActionResult<IEnumerable<AccountViewModel>>> CurrentAccounts()
        {

            var models = await GetAccountsAsync();
             var results = _mapper.Map<IEnumerable<AccountViewModel>>(await _accountRepository.FindAccountsByAccountTypeAsync("Current Account"));
            results = await PopulateOnwerNamesAsync(results);
            results = PopulateUriKeyWithId(results);
            return View(results);
        }


        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<ActionResult<IEnumerable<AccountViewModel>>> SavingAccounts()
        {

            var models = await GetAccountsAsync();
            var results = _mapper.Map<IEnumerable<AccountViewModel>>(await _accountRepository.FindAccountsByAccountTypeAsync("Saving Account"));
            results = await PopulateOnwerNamesAsync(results);
            results = PopulateUriKey(results);
            return View(results);
        }



        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public ActionResult AddAccount(string id)
        {
            return RedirectToAction("Create", new {id});
        }


        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> Create(string id)
        {
            var decryptedAppUserId = GuidEncoder.Decode(id).ToString();

            var userAccounts = await _accountRepository.FindAccountsByUserIdAsync(decryptedAppUserId);
            var accounts = userAccounts.ToList();
            var numberOfAccounts = accounts.Count();

            await PopulateForViewBagAccountTypeToOpenForUserAsync(id);

            var newAcct = new AccountViewModel()
            {
                UriKey = id,
                NumberOfAccounts = numberOfAccounts
            };
            if (accounts.Any())
            {
                newAcct.AccUriKey = GuidEncoder.Encode(accounts[0].AccountId);
            }
            newAcct.UiControl = "CreateUi";
            return View(newAcct);
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(AccountViewModel model)
        {
            CancellationToken cancellation = new CancellationToken();
            if (ModelState.IsValid)
            {
                var appUser = await _appUserRepository.FindAsync(GuidEncoder.Decode(model.UriKey).ToString());
                model.Id = appUser.Id;
                model.AppUserId = appUser.AppUserId;
                model.OpeningDate = DateTime.UtcNow;
                model.CurrentBalance = model.OpeningBalance;

                model.PersonalAccountNumber = Guid.NewGuid().ToString();
                model = await _setAccounRate.SetRateAsync(model);

                await _accountRepository.AddAsync(_mapper.Map<Account>(model));
                await _unitOfWorkAccount.CommitAsync(cancellation);
                return RedirectToAction("Index");
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var decryptedId = GuidEncoder.Decode(id);
            var model = _mapper.Map<AccountViewModel>(await _accountRepository.FindAsync(decryptedId.ToString()));
            model = await PopulateOnwerNameAsync(model);
            model = PopulateUriKey(model);
            model = await PopulateAccountTypeAsync(model);
            
            return View(model);
        }
        
        
        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")] 
        public async Task<IActionResult> Edit(string id)
        {

            var localId = id;
            var decryptedId = GuidEncoder.Decode(id);
            var model = _mapper.Map<AccountViewModel>(await _accountRepository.FindAsync(decryptedId.ToString()));
            var acctTypes = new List<AccountTypeViewModel>();
            var acctType = await GetAccountTypeAsync(model.AccountTypeId);
            acctTypes.Add(acctType);
            ViewBag.AccountTypes = acctTypes;
            model.UriKey = localId;
            model.AccUriKey = GuidEncoder.Encode(model.AccountId);
            if (model.IsBlocked)
            {
                //Todo: appropraite view
                return View();
            }

            model.UiControl = "EditUi";
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(AccountViewModel model)
        {
            CancellationToken cancellation = new CancellationToken();

            if (ModelState.IsValid)
            {
                var updateAcct = await _accountRepository.FindAsync(GuidEncoder.Decode(model.UriKey).ToString());
                //updates
                updateAcct.CurrentBalance = model.CurrentBalance;
                //updateAcct.IsBlocked = model.IsBlocked;

                var acc = await _unitOfWorkAccount.UpdateAsync(cancellation, _mapper.Map<Account>(updateAcct));

                var identityUser = await _userManager.FindByIdAsync(acc.Id);
                if (await _userManager.IsInRoleAsync(identityUser,"Bank Admin") || await _userManager.IsInRoleAsync(identityUser,"Bank Manager"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("UserAccountsByAccountId", new{id= GuidEncoder.Encode(acc.AccountId)});
                }


            }


            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> Delete(string id)
        {
            //await PopulateViewBagForDropDownLists();


            //Todo: Javascript pop up.
            var decryptedId = GuidEncoder.Decode(id);
            var model = await _accountRepository.FindAsync(decryptedId.ToString());
            if (model.IsBlocked)
            {
                //Todo: appropraite view
                return View();
            }
            model.IsDeleted = true;
            await _unitOfWorkAccount.UpdateAsync(_cancellationToken, model);
            return RedirectToAction("Index");
        }






        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> AddInterest(string id)
        {

            //Todo: To handle the operation
            var decryptedId = GuidEncoder.Decode(id);
            var model = await _accountRepository.FindAccountsIncludeRelatedClassesAsync(decryptedId.ToString());
            if (!model.IsBlocked)
            {
                //Todo: appropriate view
                model =  await _accountRepository.CalculateAccountInterestAsync(model);
                model = await _unitOfWorkAccount.UpdateAsync(_cancellationToken,_mapper.Map<Account>(model));
                return RedirectToAction("Details", new{ id= GuidEncoder.Encode(model.AccountId)});
            }

            //Appropriate view
            return RedirectToAction("Index");
        }



        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager")]
        public async Task<ActionResult<AccountViewModel>> BlockAccount(string id)
        {
            var decryptedId = GuidEncoder.Decode(id);
            var account = await _accountRepository.FindAsync(decryptedId.ToString());
            if (!account.IsBlocked)
            {
                account.IsBlocked = true;
                await _unitOfWorkAccount.UpdateAsync(_cancellationToken, account);
                return RedirectToAction("Details", new { id = id });
            }
            return RedirectToAction("Details", new { id = id });

        }


        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager")]
        public async Task<ActionResult<AccountViewModel>> UnBlockAccount(string id)
        {
            var decryptedId = GuidEncoder.Decode(id);
            var account = await _accountRepository.FindAsync(decryptedId.ToString());
            if (!account.IsBlocked)
            {
                account.IsBlocked = true;
                await _unitOfWorkAccount.UpdateAsync(_cancellationToken, account);
                return RedirectToAction("Details", new { id = id });
            }
            return RedirectToAction("Details", new { id = id });
        }






        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> CreditAccount(string id)
        {
            //needs to implement update function

            var decryptedId = GuidEncoder.Decode(id);
            var account = await _accountRepository.FindAsync(decryptedId.ToString());
           
            if (!account.IsBlocked)
            {
                ViewBag.AccountTypesLeftForfundTransfer = await _accountTypeRepository.FindAllAccountTypesByAccountTypeIdAsync(account.AccountTypeId);
                ViewBag.OrderByTypes = await GetOrderByTypesAsync();
                ViewBag.TransactionTypes = await GetTransactionTypeAsync();
                var newTransaction = new AccountTransactionViewModel() 
                { 

                    AccUriKey = GuidEncoder.Encode(account.AccountId),
                    AppUserUriKey = GuidEncoder.Encode(account.AppUserId),
                    IdUriKey = GuidEncoder.Encode(account.Id),
                    AccountTypeIdUriKey = GuidEncoder.Encode(account.AccountTypeId),
                    UiControl = "Credit"
                };

                

                return View("TransferFund", newTransaction);
            }
            //Todo: more informative view
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreditAccount(AccountTransactionViewModel model)
        {
            var cancellationToken = new CancellationToken();
            if (ModelState.IsValid)
            {
                var decryptedId = GuidEncoder.Decode(model.AccUriKey);
                //var accountTypeId = GuidEncoder.Decode(model.AccountToCredit).ToString();
                var account = await _accountRepository.FindAccountsIncludeRelatedClassesAsync(decryptedId.ToString(), model.AccountToCredit);
                account.CurrentBalance += model.AmountToCredit;

                //relect txn on debited acct
                model.AccountId = account.AccountId;
                model.AppUserId = account.AppUserId;
                model.DateOfTransaction = DateTime.UtcNow;
                model.AccountToCredit = account.AccountTypeId;
                model.CurrentBalanceAccountToCredit = account.CurrentBalance;
                account.AccountTransactions.Add(_mapper.Map<AccountTransaction>(model));

                await _unitOfWorkAccount.UpdateAsync(cancellationToken, account);

                //Todo: Update db


                var identityUser = await _userManager.FindByIdAsync(model.Id);
                if (await _userManager.IsInRoleAsync(identityUser, "Bank Admin") || await _userManager.IsInRoleAsync(identityUser, "Bank Manager"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("UserAccountsByAccountId", new { id = GuidEncoder.Encode(model.AccountId) });
                }
            }


            return View("TransferFund", model);
        }

        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> DebitAccount(string id)
        {
            //needs to implement update function

            var decryptedId = GuidEncoder.Decode(id);
            var account = await _accountRepository.FindAsync(decryptedId.ToString());

            if (!account.IsBlocked)
            {
                ViewBag.AccountTypesLeftForfundTransfer = await _accountTypeRepository.FindAllAccountTypesByAccountTypeIdAsync(account.AccountTypeId);
                ViewBag.OrderByTypes = await GetOrderByTypesAsync();
                ViewBag.TransactionTypes = await GetTransactionTypeAsync();
                var newTransaction = new AccountTransactionViewModel()
                {

                    AccUriKey = GuidEncoder.Encode(account.AccountId),
                    AppUserUriKey = GuidEncoder.Encode(account.AppUserId),
                    IdUriKey = GuidEncoder.Encode(account.Id),
                    AccountTypeIdUriKey = GuidEncoder.Encode(account.AccountTypeId),
                    UiControl = "Debit"
                };



                return View("TransferFund", newTransaction);
            }
            //Todo: more informative view
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DebitAccount(AccountTransactionViewModel model)
        {
            var cancellationToken = new CancellationToken();
            if (ModelState.IsValid)
            {
                var decryptedId = GuidEncoder.Decode(model.AccUriKey);

                var account = await _accountRepository.FindAsync(decryptedId.ToString());
                account.CurrentBalance -= model.AmountToCredit;

                //reflect txn on debited acct
                model.AccountId = account.AccountId;
                model.AppUserId = account.AppUserId;
                model.DateOfTransaction = DateTime.UtcNow;
                model.AccountToCredit = account.AccountTypeId;
                model.CurrentBalanceAccountToCredit = account.CurrentBalance;
                account.AccountTransactions.Add(_mapper.Map<AccountTransaction>(model));

                await _unitOfWorkAccount.UpdateAsync(cancellationToken, account);

                //Todo: Update db

                var identityUser = await _userManager.FindByIdAsync(model.Id);
                if (await _userManager.IsInRoleAsync(identityUser, "Bank Admin") || await _userManager.IsInRoleAsync(identityUser, "Bank Manager"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("UserAccountsByAccountId", new { id = GuidEncoder.Encode(model.AccountId) });
                }
            }


            return View("TransferFund", model);
        }


        [HttpGet]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> TransferFund(string Id)
        {
            string accTypeId;
            //Check the number of userAccounts
            var decryptedId = GuidEncoder.Decode(Id).ToString();
            var userAccount = await _accountRepository.FindAccountIncludeAppUserAsync(decryptedId);
            var userAccounts = await _accountRepository.FindAccountsByAppUserIdAsync(userAccount.AppUserId);
            var accounts = userAccounts.ToList();
            var numberOfAccounts = accounts.Count();
            ViewBag.TransactionTypes = await GetTransactionTypeAsync();
            ViewBag.OrderByTypes = await GetOrderByTypesAsync();
          
            if (numberOfAccounts < 2)
            {
                ViewBag.AccountTypesLeftForfundTransfer = await GetAccountTypesAsync();
                var newTransaction = new AccountTransactionViewModel()
                {
                    NumberOfAccounts = numberOfAccounts,
                   
                };

                newTransaction.AccUriKey = GuidEncoder.Encode(userAccount.AccountId);
                return View(newTransaction);
            }
            ViewBag.AccountTypesLeftForfundTransfer = await GetAccountTypesLeftForfundTransferAsync(userAccount.AccountTypeId);

            if (!userAccount.IsBlocked)
            {
                var newTransaction = new AccountTransactionViewModel()
                {
                    AccUriKey = GuidEncoder.Encode(userAccount.AccountId),
                    AppUserUriKey = GuidEncoder.Encode(userAccount.AppUserId),
                    IdUriKey = GuidEncoder.Encode(userAccount.Id),
                    UiControl = "Transfer"
                };
                return View(newTransaction);
            }
            //Todo: more informative view
            return View();
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Bank Admin, Bank Manager, Bank Customer Advisor")]
        public async Task<IActionResult> TransferFund(AccountTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cancellationToken = new CancellationToken();
                var accountBalance = (await _accountRepository
                                        .FindAsync(GuidEncoder.Decode(model.AccUriKey)
                                        .ToString()))
                                        .CurrentBalance;
                var acctToCreditTypeId = model.AccountToCredit;
                if (accountBalance - model.AmountToCredit >= 0  )
                {
                    var decryptedId = GuidEncoder.Decode(model.AccUriKey);
                    var account = await _accountRepository.FindAsync(decryptedId.ToString());
                    var acctViewModel = _mapper.Map<AccountViewModel>(account);
                    account.CurrentBalance -= model.AmountToCredit;

                    //account to credit
                    var acctToCredit = await _accountRepository.FindByAccountTypeAndAppUserIdAsync(account.AppUserId, acctToCreditTypeId);
                    if (acctToCredit.IsBlocked)
                    {
                        // Todo: appropraite view needed
                        return View();
                    }
                    acctToCredit.CurrentBalance += model.AmountToCredit;

                  


                    //reflect txn on debited acct
                    model.AccountId = account.AccountId;
                    model.AppUserId = account.AppUserId;
                    model.DateOfTransaction = DateTime.UtcNow;
                    model.AccountToCredit = (await _accountTypeRepository.FindAsync(acctToCreditTypeId)).Type;
                    model.AccountToDebit = (await _accountTypeRepository.FindAsync(account.AccountTypeId)).Type;
                    model.NewBalanceOfDebitedAccount = account.CurrentBalance;
                    model.CurrentBalanceAccountToCredit = acctToCredit.CurrentBalance;
                    account.AccountTransactions.Add(_mapper.Map<AccountTransaction>(model));


                    //Todo: Do i need to modify accToCrediTxn to reflect more?
                   
                    var accToCreditTxn = _mapper.Map<AccountTransactionViewModel>(model);
                    accToCreditTxn.TransactionTypeId = (await _transactionTypeRepository.FindByType("Transfer Fund Received")).TransactionTypeId;
                    accToCreditTxn.AccountId = acctToCredit.AccountId;

                    var newTxn = _mapper.Map<AccountTransaction>(accToCreditTxn);

                    acctToCredit.AccountTransactions.Add(newTxn);


                    //Todo: Update db
                    await _unitOfWorkAccount.UpdateAsync(cancellationToken, account);
                    await _unitOfWorkAccount.UpdateAsync(cancellationToken, acctToCredit);



                    var identityUser = await _userManager.FindByIdAsync(acctToCredit.Id);
                    if (await _userManager.IsInRoleAsync(identityUser, "Bank Admin") || await _userManager.IsInRoleAsync(identityUser, "Bank Manager"))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("UserAccountsByAccountId", new { id = GuidEncoder.Encode(acctToCredit.AccountId) });
                    }
                }

            }


            return View(model);
        }


        [HttpGet]
        public async Task<JsonResult> ReadAccountTypesDropDownLists()
        {
            return Json(await _accountTypeRepository.FindAllAsync()/*, System.Web.Mvc.JsonRequestBehavior.AllowGet*/);
        }

        private IEnumerable<AccountViewModel> PopulateUriKey(IEnumerable<AccountViewModel> models)
        {
            models = models.Select(a =>
            {
                //a.UriKey = _dataProtector.Protect(a.AccountId.ToString());
                a.UriKey = GuidEncoder.Encode(a.AccountId.ToString());
                return a;
            });
            return models;
        }

        //private IEnumerable<AccountViewModel> PopulateUriKeywithId(IEnumerable<AccountViewModel> models)
        //{
        //    models = models.Select(a =>
        //    {
        //        //a.UriKey = _dataProtector.Protect(a.AccountId.ToString());
        //        a.UriKey = GuidEncoder.Encode(a.Id.ToString());
        //        return a;
        //    });
        //    return models;
        //}

        private IEnumerable<AccountViewModel> PopulateUriKeyWithId(IEnumerable<AccountViewModel> models)
        {
            models = models.Select(a =>
            {
                //a.UriKey = _dataProtector.Protect(a.AccountId.ToString());
                a.UriKey = GuidEncoder.Encode(a.Id.ToString());
                a.AccUriKey = GuidEncoder.Encode(a.AccountId.ToString());
                return a;
            });
            return models;
        }

        private AccountViewModel PopulateUriKey(AccountViewModel model)
        {

            model.UriKey = GuidEncoder.Encode(model.AccountId.ToString());

            return model;
        }

        private async Task<IEnumerable<AccountViewModel>> PopulateAccountTypesAsync(IEnumerable<AccountViewModel> models)
        {
            //models = models.Select(async a =>
            //{
            //    //a.UriKey = _dataProtector.Protect(a.AccountId.ToString());
            //    a.AccountType = await GetAccountTypeAsync(a.AccountTypeId);
            //    return a;
            //});
            var listModels = models.ToList();
            var modelSize = listModels.Count;
            for (int i = 0; i < modelSize; i++)
            {
                listModels[i].AccountType = await GetAccountTypeAsync(listModels[i].AccountTypeId);
                listModels[i].AccountTypeName = listModels[i].AccountType.Type;
            }
            return models;
        }

        private async Task<AccountViewModel> PopulateAccountTypeAsync(AccountViewModel model)
        {
            model.AccountType = await GetAccountTypeAsync(model.AccountTypeId);
            model.AccountTypeName = model.AccountType.Type;

            return model;
        }


        private async Task<IEnumerable<AccountViewModel>> PopulateOnwerNamesAsync(IEnumerable<AccountViewModel> models)
        {
            //models = models.Select(async a =>
            //{
            //    //a.UriKey = _dataProtector.Protect(a.AccountId.ToString());
            //    a.AccountType = await GetAccountTypeAsync(a.AccountTypeId);
            //    return a;
            //});
            var listModels = models.ToList();
            var modelSize = listModels.Count;
            for (int i = 0; i < modelSize; i++)
            {
                var appUser = await GetAppUserAsync(listModels[i].Id);
                listModels[i].AccountOwner = appUser.FirstName + " " + appUser.LastName;

            }
            return models;
        }

        private async Task<AccountViewModel> PopulateOnwerNameAsync(AccountViewModel model)
        {

            var appUser = await GetAppUserAsync(model.Id);
            model.AccountOwner = appUser.FirstName + " " + appUser.LastName;

            return model;
        }
        private async Task<IEnumerable<AccountViewModel>> GetAccountsAsync()
        {
            var models = await _accountRepository.FindAllAsync();
            var accountModels = _mapper.Map<IEnumerable<AccountViewModel>>(models);

            var appUsers = await _appUserRepository.FindAllAsync();

            foreach (var account in accountModels)
            {
                var id = account.Id;
                var usr = appUsers.SingleOrDefault(a => a.Id.Equals(id));
                account.AccountOwner = $"{usr.FirstName}" + " " + $"{usr.LastName}";
                account.Email = usr.Email;
            }

            return accountModels;
        }

        private async Task<AccountViewModel> GetAccountAsync(string id, string type)
        {

            AccountViewModel seekAccount = new AccountViewModel();

            
            var decryptedAccountTypeId = GuidEncoder.Decode(type);

            var models = await _accountRepository.FindAllAsync();
            seekAccount = _mapper.Map<AccountViewModel>(models.
                Where(a => a.AppUserId.Equals(id) && a.AccountTypeId.Equals(decryptedAccountTypeId))
                .ToList().
                SingleOrDefault());


            return seekAccount;
        }

        private async Task PopulateViewBagForDropDownLists()
        {
            ViewBag.Countries = await GetCountriesAsync();
            ViewBag.Genders = await GetGendersAsync(); ;
            ViewBag.AccountTypes = await GetAccountTypesAsync();
            ViewBag.Currencies = await GetCurrencsAsync();
        }

        private async Task PopulateForViewBagAccountTypeToOpenForUserAsync(string userId)
        {
            //var decryptedUserId = GuidEncoder.Decode(userId).ToString();
            //var userAccts = await _accountRepository.FindAccountsByAppUserIdAsync(decryptedUserId);
            //if (userAccts == null || userAccts.Count() <= 0)
            //{
                
            //}
            ViewBag.Currencies = await GetCurrencsAsync();
            var decryptedAccountTypeId = GuidEncoder.Decode(userId);
            var user = await _appUserRepository.FindAppUserWithAccountAsync(GuidEncoder.Decode(userId).ToString());
            var accTypes = await GetAccountTypesAsync();
            var userAccounts = user.Accounts;
            if (userAccounts.Count > 0)
            {
                var AcctTypeIdsAllowed = accTypes.Select(x => x.AccountTypeId)
                    .Except(userAccounts.Select(x => x.AccountTypeId));

                ViewBag.AccountTypes = accTypes.Where(x => AcctTypeIdsAllowed.Contains(x.AccountTypeId)).ToList();
            }
            else
            {

                ViewBag.AccountTypes = await GetAccountTypesAsync();
                
            }
            


        }
        private async Task<IEnumerable<AccountType>> GetAccountTypesLeftForfundTransferAsync(string accountTypeId)
        {
            /*var result =*/
            return await _accountTypeRepository.FindAllAccountTypesLessThisAccountTypeIdAsync(accountTypeId);
            //return await _maskIds.EncodeAccountTypeIds(result);
        }


        private async Task<IEnumerable<AppUserViewModel>> GetAppUsersAsync(string appUserBaseUri)
        {
            return _mapper.Map<IEnumerable<AppUserViewModel>>(await _appUserRepository.FindAllAsync());
        }

        private async Task<AppUserViewModel> GetAppUserAsync(string id)
        {
            return _mapper.Map<AppUserViewModel>(await _appUserRepository.FindAsync(id.ToString()));
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
            /*var result = */
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
            /*var result =*/ return _mapper.Map<GenderViewModel>(await _genderRepository.FindAsync(genderId));
            //return await _maskIds.EncodeGenderId(result);
        }

        private async Task<IEnumerable<AccountTypeViewModel>> GetAccountTypesAsync()
        {
            var result = _mapper.Map<IEnumerable<AccountTypeViewModel>>(await _accountTypeRepository.FindAllAsync());
            return result;
        }

        private async Task<AccountTypeViewModel> GetAccountTypeAsync(string accountTypeId)
        {
            /*var result =*/ return _mapper.Map<AccountTypeViewModel>(await _accountTypeRepository.FindAsync(accountTypeId));
            //return await _maskIds.EncodeAccountTypeId(result);
        }

        private async Task<IEnumerable<TransactionTypeViewModel>> GetTransactionTypeAsync()
        {
            /*var result =*/ return _mapper.Map<IEnumerable<TransactionTypeViewModel>>(await _transactionTypeRepository.FindAllAsync());
            //return await _maskIds.EncodeTransactionTypeIds(result);
        }

        private async Task<IEnumerable<OrderByTypeViewModel>> GetOrderByTypesAsync()
        {
            /*var result =*/ return _mapper.Map<IEnumerable<OrderByTypeViewModel>>(await _orderByTypeRepository.FindAllAsync());
            //return await _maskIds.EncodeOrderByTypeIds(result);
        }
    }
}
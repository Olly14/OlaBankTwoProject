
using System;
using System.Collections.Generic;
using System.Linq;
using Bank.Domain;
using Microsoft.AspNetCore.Identity;

namespace Bank.Data.DatabasePopulated
{
    public static class BankContextExtentions
    {
        
        public static void EnsureSeedDataContext(this BankContext context/*, UserManager<AppUser> userManager*/)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var accounts = new List<Account>();
            var appUsers = new List<AppUser>();
            var accountTypes = new List<AccountType>();
            var currencies = new List<Currency>();
            var genders = new List<Gender>();
            var countries = new List<Country>();

            if (context.Countries.Any())
            {

            }
            else
            {
                countries = new List<Country>()
                {
                    new Country()
                    {
                        CountryCode = "44",
                        CountryName = "UK"
                    },
                    new Country()
                    {
                        CountryCode = "33",
                        CountryName = "Holland"
                    },
                    new Country()
                    {
                        CountryCode = "34",
                        CountryName = "France"
                    }
                };
                context.Countries.AddRange(countries);
                context.SaveChanges();
            }


            if (context.Genders.Any())
            {

            }
            else
            {
                genders = new List<Gender>()
                {
                    new Gender()
                    {
                        Type = "Male"
                    },
                    new Gender()
                    {
                        Type = "Female"
                    }
                };
                context.Genders.AddRange(genders);
                context.SaveChanges();
            }


            if (context.AccountTypes.Any())
            {

            }
            else
            {
                accountTypes = new List<AccountType>()
                {
                    new AccountType()
                    {
                        Type = "Current Account"
                    },
                    new AccountType()
                    {
                        Type = "Saving Account"
                    }
                };
                context.AccountTypes.AddRange(accountTypes);
                context.SaveChanges();
            }


            if (context.Currencies.Any())
            {

            }
            else
            {
                currencies = new List<Currency>()
                {
                    new Currency()
                    {
                        Type = "£",
                        CurrencyName = "Pound Sterling"
                    },
                    new Currency()
                    {
                        Type = "££",
                        CurrencyName = "Euro"
                    },
                    new Currency()
                    {
                        Type = "$",
                        CurrencyName = "Dollar"
                    },
                    new Currency()
                    {
                        Type = "N",
                        CurrencyName = "Naira"
                    }
                };
                context.Currencies.AddRange(currencies);
                context.SaveChanges();
            }

            if (context.AppUsers.Any())
            {

            }
            else
            {
                //init AppUsers






                appUsers = new List<AppUser>()
                {
                    new AppUser()
                    {
                        AppUserId =  Guid.NewGuid().ToString(),
                        FirstName = "Ola",
                        LastName = "Honest",
                        FirstLineOfAddress = "1",
                        SecondLineOfAddress = "Wheatsheaf Court",
                        Postcode = "LO1 2VE",
                        DateOfBirth = "10/10/2000",
                        CountryId = countries[0].CountryId,
                        GenderId = genders[0].GenderId,
                        Town = "Kent",
                        Email = "olahonest@fakeemail.com",
                        UserName = "olahonest@fakeemail.com",
                        Password = "@Bank2Test"
                        
                    },
                    new AppUser()
                    {
                        AppUserId =  Guid.NewGuid().ToString(),
                        FirstName = "Ayo",
                        LastName = "Honest",
                        FirstLineOfAddress = "1",
                        SecondLineOfAddress = "Main Court",
                        Postcode = "MA1 2CO",
                        DateOfBirth = "10/10/2000",
                        CountryId = countries[0].CountryId,
                        GenderId = genders[0].GenderId,
                        Town = "Kent",
                        Email = "ayohonest@fakeemail.com",
                        UserName = "ayohonest@fakeemail.com",
                        Password = "@Bank2Test"
                        
                    },

                    new AppUser()
                    {
                        AppUserId =  Guid.NewGuid().ToString(),
                        FirstName = "Carter",
                        LastName = "Honest",
                        FirstLineOfAddress = "3",
                        SecondLineOfAddress = "Love Avenue",
                        Postcode = "LO1 2VE",
                        DateOfBirth = "10/10/2000",
                        CountryId = countries[0].CountryId,
                        GenderId = genders[0].GenderId,
                        Town = "Kent",
                        Email = "kdsmith@fakeemail.com",
                        UserName = "kdsmith@fakeemail.com",
                        Password = "@Bank2Test",
                        Accounts = new List<Account>()
                        {

                        }
                    },

                    new AppUser()
                    {
                        AppUserId =  Guid.NewGuid().ToString(),
                        FirstName = "Layo",
                        LastName = "Honest",
                        FirstLineOfAddress = "1",
                        SecondLineOfAddress = "Lust Avenue",
                        Postcode = "LU1 2ST",
                        DateOfBirth = "10/10/2000",
                        CountryId = countries[0].CountryId,
                        GenderId = genders[1].GenderId,
                        Town = "Kent",
                        Email = "annafall@fakeemail.com",
                        UserName = "annafall@fakeemail.com",
                        Password = "@Bank2Test",
                        Accounts = new List<Account>()
                        {

                        }
                    }
                };
            }

            if (context.Accounts.Any())
            {

            }
            else
            {
                accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountId = Guid.NewGuid().ToString(),
                        PersonalAccountNumber = Guid.NewGuid().ToString(),
                        OpeningBalance = 1000.00,
                        CurrentBalance = 1000.00,
                        AccountTypeId = accountTypes[0].AccountTypeId,
                        CurrencyId = currencies[0].CurrencyId,
                        IsBlocked = false,
                        OpeningDate = new DateTime()
                    },
                    new Account()
                    {
                        AccountId = Guid.NewGuid().ToString(),
                        PersonalAccountNumber = Guid.NewGuid().ToString(),
                        OpeningBalance = 1000.00,
                        CurrentBalance = 1000.00,
                        AccountTypeId = accountTypes[1].AccountTypeId,
                        CurrencyId = currencies[0].CurrencyId,
                        IsBlocked = false,
                        OpeningDate = new DateTime()
                    },
                    new Account()
                    {
                        AccountId = Guid.NewGuid().ToString(),
                        PersonalAccountNumber = Guid.NewGuid().ToString(),
                        OpeningBalance = 1000.00,
                        CurrentBalance = 1000.00,
                        AccountTypeId = accountTypes[1].AccountTypeId,
                        CurrencyId = currencies[0].CurrencyId,
                        IsBlocked = false,
                        OpeningDate = new DateTime()
                    }
                };


            }


            appUsers[0].Accounts.Add(accounts[0]);
            appUsers[0].Accounts.Add(accounts[1]);
            appUsers[1].Accounts.Add(accounts[2]);

            //context.AppUsers.AddRange(appUsers);
            var userAppUserOne = appUsers[0];
            var userAppUserTwo = appUsers[1]; 
            var userAppUserThree = appUsers[2];
            userAppUserOne.PasswordHash = passwordHasher.HashPassword(userAppUserOne, userAppUserOne.Password);
            userAppUserTwo.PasswordHash = passwordHasher.HashPassword(userAppUserTwo, userAppUserTwo.Password);
            userAppUserThree.PasswordHash = passwordHasher.HashPassword(userAppUserThree, userAppUserThree.Password);

            //context.SaveChanges();

        }

    }
}

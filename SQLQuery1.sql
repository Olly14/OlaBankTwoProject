INSERT INTO [dbo].[AccountTypes](AccountTypeId, Type)
VALUES (newId(), 'Current Account');
INSERT INTO AccountTypes(AccountTypeId, Type)
VALUES (newId(), 'Saving Account');


INSERT INTO Currencies (CurrencyId, Type, CurrencyName)
VALUES (newId(), '£', 'Pound');
INSERT INTO Currencies (CurrencyId, Type, CurrencyName)
VALUES (newId(), '$', 'Dollar');
INSERT INTO Currencies (CurrencyId, Type, CurrencyName)
VALUES (newId(), '€', 'Euro');
INSERT INTO Currencies (CurrencyId, Type, CurrencyName)
VALUES (newId(), '₦', 'Naira');

INSERT INTO Genders(GenderId, Type)
VALUES (newId(), 'Female');
INSERT INTO Genders(GenderId, Type)
VALUES (newId(), 'Male');

INSERT INTO Countries(CountryId, CountryName, CountryCode)
VALUES (newId(), 'UK', '+44');
INSERT INTO Countries(CountryId, CountryName, CountryCode)
VALUES (newId(), 'France', '34');
INSERT INTO Countries(CountryId, CountryName, CountryCode)
VALUES (newId(), 'Netherlands', '+31');
INSERT INTO Countries(CountryId, CountryName, CountryCode)
VALUES (newId(), 'Italy', '+39');

--INSERT INTO TransactionTypes(TransactionTypeId, Type)
--VALUES (newId(), 'Transfer Fund');
--INSERT INTO TransactionTypes(TransactionTypeId, Type)
--VALUES (newId(), 'Credit Fund');
--INSERT INTO TransactionTypes(TransactionTypeId, Type)
--VALUES (newId(), 'Debit Fund');

INSERT INTO TransactionTypes(TransactionTypeId, Type)
VALUES (newId(), 'Transfer Fund');
INSERT INTO TransactionTypes(TransactionTypeId, Type)
VALUES (newId(), 'Credit Fund');
INSERT INTO TransactionTypes(TransactionTypeId, Type)
VALUES (newId(), 'Debit Fund');
INSERT INTO TransactionTypes(TransactionTypeId, Type)
VALUES (newId(), 'Inter Bank Transfer Fund');
INSERT INTO TransactionTypes(TransactionTypeId, Type)
VALUES (newId(), 'Transfer Fund Received');


INSERT INTO OrderByTypes(OrderByTypeId, Type)
VALUES (newId(), 'Accounts transfer');
INSERT INTO OrderByTypes(OrderByTypeId, Type)
VALUES (newId(), 'Counter Cash Withdraw');
INSERT INTO OrderByTypes(OrderByTypeId, Type)
VALUES (newId(), 'Counter Cash Deposit');
INSERT INTO OrderByTypes(OrderByTypeId, Type)
VALUES (newId(), 'Counter Cheque Deposit');
INSERT INTO OrderByTypes(OrderByTypeId, Type)
VALUES (newId(), 'Machine Withdraw');
INSERT INTO OrderByTypes(OrderByTypeId, Type)
VALUES (newId(), 'Online Banking');






--Test
INSERT INTO AspNetUsers
(Id,AppUserId, FirstName,LastName,FirstLineOfAddress,SecondLineOfAddress,Postcode, DateOfBirth,CountryId,GenderId,Town,Email,UserName,EmailConfirmed,PhoneNumberConfirmed,PhoneNumber,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,CreatedDate)
VALUES (newId(),newId(), 'Test','User','1','Wheatsheaf Court','ME16 6TY','10/10/2000','C305FD99-1B91-41DA-B2DF-CE5C4B72DF55','288B0F9A-320C-4C1A-915F-7655047C6698','Kent','olahonest@fakeemail.com','testuser@fakeemail.com',1,1,'0784848487',0,0,0,GETUTCDATE());

--Ayo
INSERT INTO AspNetUsers
(Id,AppUserId, FirstName,LastName,FirstLineOfAddress,SecondLineOfAddress,Postcode, DateOfBirth,CountryId,GenderId,Town,Email,UserName,EmailConfirmed,PhoneNumberConfirmed,PhoneNumber,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,CreatedDate)
VALUES (newId(),newId(), 'Ayo','Honest','1','Banks Court','ME20 TY','10/10/2000','D2260808-BCA3-4B12-9DBB-D51FFC7BD555','3D6499B7-A5D1-402E-A934-50C09FB6D1BF','Kent','ayohonest@fakeemail.com','ayohonest@fakeemail.com',1,1,'0787878786',0,0,0,GETUTCDATE());

--Carter
INSERT INTO AspNetUsers
(Id,AppUserId, FirstName,LastName,FirstLineOfAddress,SecondLineOfAddress,Postcode, DateOfBirth,CountryId,GenderId,Town,Email,UserName,EmailConfirmed,PhoneNumberConfirmed,PhoneNumber,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,CreatedDate)
VALUES (newId(),newId(), 'Carter','Honest','1','Main Court','ME16 6TY','10/10/2000','D2260808-BCA3-4B12-9DBB-D51FFC7BD555','3D6499B7-A5D1-402E-A934-50C09FB6D1BF','Kent','carterhonest@fakeemail.com','carterhonest@fakeemail.com',1,1,'07878878889',0,0,0,GETUTCDATE());


--John
INSERT INTO AspNetUsers
(Id,AppUserId, FirstName,LastName,FirstLineOfAddress,SecondLineOfAddress,Postcode, DateOfBirth,CountryId,GenderId,Town,Email,UserName,EmailConfirmed,PhoneNumberConfirmed,PhoneNumber,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,CreatedDate)
VALUES (newId(),newId(), 'john','Honest','1','John Court','ME16 6TY','10/10/2000','D2260808-BCA3-4B12-9DBB-D51FFC7BD555','3D6499B7-A5D1-402E-A934-50C09FB6D1BF','Kent','johnhonest@fakeemail.com','johnhonest@fakeemail.com',1,1,'0787978880',0,0,0,GETUTCDATE());

--Layo
INSERT INTO AspNetUsers
(Id,AppUserId, FirstName,LastName,FirstLineOfAddress,SecondLineOfAddress,Postcode, DateOfBirth,CountryId,GenderId,Town,Email,UserName,EmailConfirmed,PhoneNumberConfirmed,PhoneNumber,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,CreatedDate)
VALUES (newId(),newId(), 'Layo','Honest','1','Ben Court','ME16 6TY','10/10/2000','D2260808-BCA3-4B12-9DBB-D51FFC7BD555','EC824066-74DB-4BFD-9468-552A0F202B5D','Kent','layohonest@fakeemail.com','layohonest@fakeemail.com',1,1,'0787878782',0,0,0,GETUTCDATE());

--Alice
--INSERT INTO AspNetUsers
--(Id,AppUserId, FirstName,LastName,FirstLineOfAddress,SecondLineOfAddress,Postcode, DateOfBirth,CountryId,GenderId,Town,Email,UserName,EmailConfirmed,PhoneNumberConfirmed,PhoneNumber,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,CreatedDate)
--VALUES (newId(),newId(), 'Alice','Honest','1','Wheatsheaf Court','ME16 6TY','10/10/2000','D2260808-BCA3-4B12-9DBB-D51FFC7BD555','EC824066-74DB-4BFD-9468-552A0F202B5D','Kent','alicehonest@fakeemail.com','alicehonest@fakeemail.com',1,1,'0787878786',0,0,0,GETUTCDATE());

--test user current account
INSERT INTO Accounts
(AccountId,Id,AppUserId,PersonalAccountNumber,OpeningBalance,CurrentBalance,AccountTypeId,OpeningDate,IsBlocked,CurrencyId)
VALUES (newId(),'7E3BD94C-C2ED-436C-A041-70FB954783E2', 'B1E8885B-6423-4385-A2BF-E46739B649CE',NEWID(),5000,5000,'0E276A77-BE80-4289-8417-0891D343B6A5',GETUTCDATE(),0,'52863155-7893-465E-A024-200CA635DBBE');


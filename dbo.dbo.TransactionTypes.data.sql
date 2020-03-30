
USE BankDbTwo
INSERT INTO [dbo.TransactionTypes]
VALUES (newid(), 'Credit Account');
INSERT INTO [dbo.TransactionTypes]
VALUES (newid(), 'Debit Account');
INSERT INTO [dbo.TransactionTypes]
VALUES (newid(), 'Tranfer Fund');
INSERT INTO [dbo.TransactionTypes]
VALUES (newid(), 'Counter Deposit');
INSERT INTO [dbo.TransactionTypes]
VALUES (newid(), 'Counter Withdraw');
INSERT INTO [dbo.TransactionTypes]
VALUES (newid(),'Tranfer Fund Received');
INSERT INTO [dbo.TransactionTypes]
VALUES (newid(), 'Cheque Deposit');
INSERT INTO [dbo.TransactionTypes]
VALUES (newid(), 'Cheque Payed Out');
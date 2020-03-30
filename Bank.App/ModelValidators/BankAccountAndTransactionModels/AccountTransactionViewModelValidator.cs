using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.Models.ModelValidators.AccountValidators
{
    public class AccountTransactionViewModelValidator : AbstractValidator<AccountTransactionViewModel>
    {
        public AccountTransactionViewModelValidator()
        {
            When(a => a.UiControl == "Debit", () =>
            {
                RuleFor(a => a.TransactionTypeId).NotEmpty().WithMessage("'Transaction Type' is required");
                RuleFor(a => a.AccountToDebit).NotEmpty().WithMessage("'Account To Debit' is required");
                RuleFor(a => a.OrderByTypeId).NotEmpty().WithMessage("' Order By Type' is required");
                RuleFor(a => a.AmountToCredit).NotEmpty().WithMessage("'Amount To Credit' is required");
                RuleFor(a => a.Reference).NotEmpty().WithMessage("'Reference' is required");
            });


            When(a => a.UiControl == "Credit", () =>
            {
                RuleFor(a => a.TransactionTypeId).NotEmpty().WithMessage("'Transaction Type' is required");
                RuleFor(a => a.AccountToCredit).NotEmpty().WithMessage("'Account To Debit' is required");
                RuleFor(a => a.OrderByTypeId).NotEmpty().WithMessage("' Order By Type' is required");
                RuleFor(a => a.AmountToCredit).NotEmpty().WithMessage("'Amount To Credit' is required");
                RuleFor(a => a.Reference).NotEmpty().WithMessage("'Reference' is required");
            });


            When(a => a.UiControl == "Transfer", () =>
            {
                RuleFor(a => a.TransactionTypeId).NotEmpty().WithMessage("'Transaction Type' is required");
                RuleFor(a => a.AccountToCredit).NotEmpty().WithMessage("'Account To Debit' is required");
                RuleFor(a => a.OrderByTypeId).NotEmpty().WithMessage("' Order By Type' is required");
                RuleFor(a => a.AmountToCredit).NotEmpty().WithMessage("'Amount To Credit' is required");
                RuleFor(a => a.Reference).NotEmpty().WithMessage("'Reference' is required");
            });
        }
    }
}

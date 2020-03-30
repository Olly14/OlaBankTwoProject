 

using Bank.App.Models;

using FluentValidation;

namespace Bank.App.Models.ModelValidators
{
    public class AccountViewModelValidator : AbstractValidator<AccountViewModel>
    {
        public AccountViewModelValidator()
        {
            When(a => string.IsNullOrWhiteSpace(a.AccountId) &&  a.UiControl == "CreateUi", () =>
            {
                RuleFor(a => a.AccountTypeId).NotEmpty().WithMessage("'Account Type' is required");
                RuleFor(a => a.CurrencyId).NotEmpty().WithMessage("'Currency Type' is required");
                RuleFor(a => a.OpeningBalance).NotEmpty().WithMessage("The Opening Balance field is required")
                    .GreaterThanOrEqualTo(10.00).WithMessage("The minimum opening amount is 10.00");
            });



            When(a => a.UiControl == "EditUi", () =>
            {

                RuleFor(a => a.PersonalAccountNumber).NotEmpty().WithMessage("'Personal Account Number' is required");
                RuleFor(a => a.OpeningDate).NotEmpty().WithMessage("'Opening Date' is required");
                RuleFor(a => a.CurrentBalance).NotEmpty().WithMessage("'Current Balance' is required");
                RuleFor(a => a.OpeningBalance).NotEmpty().WithMessage("The Opening Balance field is required")
                    .GreaterThanOrEqualTo(10.00).WithMessage("The minimum opening amount is 10.00");
            });




            When(a => string.IsNullOrWhiteSpace(a.AccountId) && string.IsNullOrWhiteSpace(a.UiControl), () =>
            {


                RuleFor(a => a.AccountTypeId).NotEmpty().WithMessage("'Account Type' is required");
                RuleFor(a => a.CurrencyId).NotEmpty().WithMessage("'Currency Type' is required");
                RuleFor(a => a.OpeningBalance).NotEmpty().WithMessage("The Opening Balance field is required")
                    .GreaterThanOrEqualTo(10.00).WithMessage("The minimum opening amount is 10.00");
            });
            When(a => !string.IsNullOrWhiteSpace(a.AccountId) && string.IsNullOrWhiteSpace(a.UiControl), () =>
            {

                RuleFor(a => a.PersonalAccountNumber).NotEmpty();
                RuleFor(a => a.AccountTypeId).NotEmpty().WithMessage("The Account Type field is required");
                RuleFor(a => a.CurrentBalance).NotEmpty().WithMessage("The Current Balance field is required");
                RuleFor(a => a.IsBlocked).NotEmpty().WithMessage("The is Blocked field is required");
                RuleFor(a => a.OpeningBalance).NotEmpty().WithMessage("The Opening Balance field is required")
                    .GreaterThanOrEqualTo(10.00).WithMessage("The minimum opening amount is 10.00");
                RuleFor(a => a.OpeningDate).NotEmpty().WithMessage("The Opening date field is required");
                RuleFor(a => a.FirstName).NotEmpty().WithMessage("The First name field is required");
                RuleFor(a => a.LastName).NotEmpty().WithMessage("The Last name field is required");
                RuleFor(a => a.AppUserId).NotEmpty().WithMessage("The AppUser id field is required");

            });

        }
    }
}

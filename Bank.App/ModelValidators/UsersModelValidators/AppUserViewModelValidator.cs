using Bank.App.Models;
using FluentValidation;

namespace Bank.App.ModelValidators.UserModelValidators
{
    public class AppUserViewModelValidator : AbstractValidator<AppUserViewModel>
    {
        public AppUserViewModelValidator()
        {
            When(au => au.UiControl.Equals("CreateUi"), () =>
            {

            });

            When(au => au.UiControl.Equals("EditUi"), () =>
            {
                RuleFor(au => au.UserName)
                    .NotEmpty().WithMessage(" 'Username' is required")
                    .Length(3, 40).WithMessage("The firstname must be between 3 to 20 characters inclusive");
                RuleFor(au => au.FirstName)
                    .NotEmpty().WithMessage(" 'Firstname' is required")
                    .Length(3, 20).WithMessage("The firstname must be between 3 to 20 characters inclusive");
                RuleFor(au => au.LastName)
                    .NotEmpty().WithMessage("'Lastname' is required")
                    .Length(3, 20).WithMessage("'Lastname' must be between 3 to 20 characters inclusive");
                RuleFor(au => au.FirstLineOfAddress)
                    .NotEmpty().WithMessage(" 'First Line Of Address'  is required")
                    .Length(3, 20).WithMessage(" 'First Line Of Address' must be between 3 to 20 characters inclusive");
                RuleFor(au => au.SecondLineOfAddress)
                    .NotEmpty().WithMessage(" 'Second Line Of Address' is required")
                    .Length(3, 20).WithMessage(" 'Second Line Of Address' must be between 3 to 20 characters inclusive");
                RuleFor(au => au.Town)
                    .NotEmpty().WithMessage("'Town' is required")
                    .Length(3, 20).WithMessage(" 'Town' must be between 3 to 20 characters inclusive");
                RuleFor(au => au.Postcode)
                    .NotEmpty().WithMessage("The Postcode is required")
                    .Matches("^([A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]? {1,2}[0-9][ABD-HJLN-UW-Z]{2}|GIR 0AA)$").WithMessage("The Postcode must UK pattern");
                RuleFor(au => au.DateOfBirth)
                    .NotEmpty().WithMessage(" 'Date Of Birth' is required")
                    .Matches(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$").WithMessage(" 'Date Of Birth' must beof this format DD/MM/YYYY");
                RuleFor(au => au.Email)
                    .NotEmpty().WithMessage("'Email' is required")
                    .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                    .WithMessage("'Email' must be of email format such at something@domain.nameOfOrganisation");
                RuleFor(au => au.CountryId)
                    .NotEmpty().WithMessage("'Country' is required");
                RuleFor(au => au.GenderId)
                    .NotEmpty().WithMessage("'Gender' is required");
            });



            When(au => au.UiControl.Equals("RegistrationUi"), () =>
            {
                RuleFor(au => au.FirstName)
                    .NotEmpty().WithMessage(" 'Firstname' is required")
                    .Length(3, 20).WithMessage("The firstname must be between 3 to 20 characters inclusive");
                RuleFor(au => au.LastName)
                    .NotEmpty().WithMessage("'Lastname' is required")
                    .Length(3, 20).WithMessage("'Lastname' must be between 3 to 20 characters inclusive");
                RuleFor(au => au.FirstLineOfAddress)
                    .NotEmpty().WithMessage(" 'First Line Of Address'  is required")
                    .Length(3, 20).WithMessage(" 'First Line Of Address' must be between 3 to 20 characters inclusive");
                RuleFor(au => au.SecondLineOfAddress)
                    .NotEmpty().WithMessage(" 'Second Line Of Address' is required")
                    .Length(3, 20).WithMessage(" 'Second Line Of Address' must be between 3 to 20 characters inclusive");
                RuleFor(au => au.Town)
                    .NotEmpty().WithMessage("'Town' is required")
                    .Length(3, 20).WithMessage(" 'Town' must be between 3 to 20 characters inclusive");
                RuleFor(au => au.Postcode)
                    .NotEmpty().WithMessage("The Postcode is required")
                    .Matches("^([A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]? {1,2}[0-9][ABD-HJLN-UW-Z]{2}|GIR 0AA)$").WithMessage("The Postcode must UK pattern");
                RuleFor(au => au.DateOfBirth)
                    .NotEmpty().WithMessage(" 'Date Of Birth' is required")
                    .Matches(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$").WithMessage(" 'Date Of Birth' must beof this format DD/MM/YYYY");
                RuleFor(au => au.Email)
                    .NotEmpty().WithMessage("'Email' is required")
                    .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                    .WithMessage("'Email' must be of email format such at something@domain.nameOfOrganisation");
                RuleFor(au => au.CountryId)
                    .NotEmpty().WithMessage("'Country' is required");
                RuleFor(au => au.GenderId)
                    .NotEmpty().WithMessage("'Gender' is required");
            });

        }
    }
}

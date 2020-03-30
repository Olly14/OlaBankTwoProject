using Bank.App.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.App.ModelValidators.UsersModelValidators
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
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
                .NotEmpty()
                    .WithMessage(" 'Date Of Birth' is required")
                .Matches("^[\\d][\\d]\\/[01][12]\\/[\\d][\\d][\\d][\\d]$")
                    .WithMessage(" 'Date Of Birth' must be in the format 'DD/MM/YYYY'");
            //RuleFor(au => au.Email)
            //    .NotEmpty().WithMessage("'Email' is required")
            //    .Matches("^([a - zA - Z0 - 9_\\-\\.] +)@((\\[[0 - 9]{ 1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a - zA - Z0 - 9\\-]+\\.)+))([a - zA - Z]{2,4}|[0-9]{1,3})(\\]?)$")
            //    .WithMessage("'Email' must be of email format such at something@domain.nameOfOrganisation");
            //RuleFor(au => au.EmailConfirmed)
            //    .NotEmpty().WithMessage("'Email' is required")
            //    .Matches("^([a - zA - Z0 - 9_\\-\\.] +)@((\\[[0 - 9]{ 1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a - zA - Z0 - 9\\-]+\\.)+))([a - zA - Z]{2,4}|[0-9]{1,3})(\\]?)$")
            //    .WithMessage("'Email' must be of email format such at something@domain.nameOfOrganisation");
            RuleFor(au => au.CountryId)
                .NotEmpty().WithMessage("'Country' is required");
            RuleFor(au => au.GenderId)
                .NotEmpty().WithMessage("'Gender' is required");
            RuleFor(au => au.PhoneNumber)
                .NotEmpty().WithMessage("'PhoneNumber' is required")
                .Matches("^([\\+][0-9]{1,3}([ \\.\\-])?)?([\\(]{1}[0-9]{3}[\\)])?([0-9A-Z \\.\\-]{1,32})((x|ext|extension)?[0-9]{1,4}?)$").WithMessage("'PhoneNumber' must match UK phone number or any international phone number");
            RuleFor(au => au.Password).NotEmpty().WithMessage("'Password' is required")
                .Matches("^([a-zA-Z0-9@*#]{8,15})$").WithMessage("'Password' must be alphanumeric between 8 and 15 inclusive");
            RuleFor(au => au.ConfirmedPassword).NotEmpty().WithMessage("'Password' is required'")
                .Matches("^([a-zA-Z0-9@*#]{8,15})$").WithMessage("'Confirmed Password' is required'");
        }
    }
}

var registrationValidation = (function() {


    var FirstNameInputIsValid = true;
    var FirstNameLengthIsValid = true;
    var LastNameInputIsValid = true;
    var LastNameLengthIsValid = true;
    var FirstLineOfAddressInputIsValid = true;
    var FirstLineOfAddressLengthIsValid = true;
    var SecondLineOfAddressInputIsValid = true;
    var SecondLineOfAddressLengthIsValid = true;
    var TownInputIsValid = true;
    var TownLengthIsValid = true;
    var PostcodeInputIsValid = true;
    var PostcodeLengthIsValid = true;
    var DateOfBirthInputIsValid = true;
    var DateOfBirthMatchedIsValid = true;
    var CountryIdInputIsValid = true;
    var GenderIdInputIsValid = true;
    var EmailInputIsValid = true;
    var EmailMatchedIsValid = true;
    var PhoneNumberInputIsValid = true;
    var PhoneNumberMatchedIsValid = true;
    var PasswordInputIsValid = true;
    var PasswordMatchedIsValid = true;
    var ConfirmedPasswordInputIsValid = true;
    var ConfirmedPhoneNumberMatchedIsValid = true;






    var validateFirstNameInput = function() {
        if ($('#FirstNameInputId').val().length <= 0) {

            FirstNameInputIsValid = false;
            $('#FirstNameInputId').addClass("inputFieldError");
            $('#help-block-id-FirstNameId').removeClass("hidden");
        } else {
            FirstNameInputIsValid = true;
        }
    }
    var validateFirstNameLength = function () {
        if ($('#FirstNameInputId').val().length < 3 || $('#FirstNameInputId').val().length > 20) {

            FirstNameLengthIsValid = false;
            $('#FirstNameInputId').addClass("inputFieldError");
            $('#help-block-id-FirstNameId').removeClass("hidden");
        } else {
            FirstNameLengthIsValid = true;
        }
    }
    var validateLastNameInput = function () {
        if ($('#LastNameInputId').val().length <= 0) {

            LastNameInputIsValid = false;
            $('#LastNameInputId').addClass("inputFieldError");
            $('#help-block-id-LastNameId').removeClass("hidden");
        } else {
            LastNameInputIsValid = true;
        }
    }
    var validateLastNameLength = function () {
        if ($('#LastNameInputId').val().length < 3 || $('#LastNameInputId').val().length > 20) {

            FirstNameLengthIsValid = false;
            $('#help-block-id-LastNameId').removeClass("hidden");
        } else {
            LastNameLengthIsValid = true;
        }
    }
    var validateFirstLineOfAddressInput = function () {
        if ($('#FirstLineOfAddressInputId').val().length <= 0) {

            FirstLineOfAddressInputIsValid = false;
            $('#FirstLineOfAddressInputId').addClass("inputFieldError");
            $('#help-block-id-FirstLineOfAddressId').removeClass("hidden");
        } else {
            FirstLineOfAddressInputIsValid = true;
        }
    }
    var validateFirstLineOfAddressLength = function () {
        if ($('#FirstLineOfAddressInputId').val().length < 3 || $('#FirstLineOfAddressInputId').val().length > 20) {

            FirstLineOfAddressLengthIsValid = false;
            $('#FirstLineOfAddressInputId').addClass("inputFieldError");
            $('#help-block-id-FirstLineOfAddressId').removeClass("hidden");
        } else {
            FirstLineOfAddressLengthIsValid = true;
        }
    }
    var validateSecondLineOfAddressInput = function () {
        if ($('#SecondLineOfAddressInputId').val().length <= 0) {

            SecondLineOfAddressInputIsValid = false;
            $('#SecondLineOfAddressInputId').addClass("inputFieldError");
            $('#help-block-id-SecondLineOfAddressId').removeClass("hidden");
        } else {
            SecondLineOfAddressInputIsValid = true;
        }
    }
    var validateSecondLineOfAddressLength = function () {
        if ($('#FirstLineOfAddressInputId').val().length < 3 || $('#SecondLineOfAddressInputId').val().length > 20) {

            SecondLineOfAddressLengthIsValid = false;
            $('#SecondLineOfAddressInputId').addClass("inputFieldError");
            $('#help-block-id-SecondLineOfAddressId').removeClass("hidden");
        } else {
            SecondLineOfAddressLengthIsValid = true;
        }
    }
    var validateTownInput = function () {
        if ($('#TownInputId').val().length <= 0) {

            TownInputIsValid = false;
            $('#TownInputId').addClass("inputFieldError");
            $('#help-block-id-TownId').removeClass("hidden");
        } else {
            TownInputIsValid = true;
        }
    }
    var validateTownLength = function () {
        if ($('#TownInputId').val().length < 3 || $('#TownInputId').val().length > 20) {

            TownLengthIsValid = false;
            $('#TownInputId').addClass("inputFieldError");
            $('#help-block-id-TownId').removeClass("hidden");
        } else {
            TownLengthIsValid = true;
        }
    }
    var validatePostcodeInput = function () {
        if ($('#PostcodeInputId').val().length <= 0) {

            TownInputIsValid = false;
            $('#PostcodeInputId').addClass("inputFieldError");
            $('#help-block-id-PostcodeId').removeClass("hidden");
        } else {
            PostcodeInputIsValid = true;
        }
    }
    var validatePostcodeMatched = function () {
        if ($('#TownInputId').val().length < 3 || $('#PostcodeInputId').val().length > 20) {

            PostcodeLengthIsValid = false;
            $('#PostcodeInputId').addClass("inputFieldError");
            $('#help-block-id-PostcodeId').removeClass("hidden");
        } else {
            PostcodeLengthIsValid = true;
        }
    }
    var validateDateOfBirthInput = function () {
        if ($('#DateOfBirthInputId').val().length <= 0) {

            DateOfBirthInputIsValid = false;
            $('#DateOfBirthInputId').addClass("inputFieldError");
            $('#help-block-id-DateOfBirthId').removeClass("hidden");
        } else {
            DateOfBirthInputIsValid = true;
        }
    }
    var validateDateOfBirthMatches = function () {
        var requiredPattern = new RegExp("^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$");
        var isAMatch = requiredPattern.test($('#DateOfBirthInputId'));
        if (!isAMatch) {

            DateOfBirthMatchedIsValid = false;
            $('#DateOfBirthInputId').addClass("inputFieldError");
            $('#help-block-id-DateOfBirthId').removeClass("hidden");
        } else {
            DateOfBirthMatchedIsValid = true;
        }
    }
    var validateCountryIdInput = function () {
        if ($('#CountryIdInputId').val().length <= 0) {

            CountryIdInputIsValid = false;
            $('#CountryIdInputId').addClass("inputFieldError");
            $('#help-block-id-CountryId').removeClass("hidden");
        } else {
            CountryIdInputIsValid = true;
        }
    }
    var validateGenderIdInput = function () {
        if ($('#GenderIdInputId').val().length <= 0) {

            GenderIdInputIsValid = false;
            $('#GenderIdInputId').addClass("inputFieldError");
            $('#help-block-id-GenderId').removeClass("hidden");
        } else {
            GenderIdInputIsValid = true;
        }
    }
    var validateEmailInput = function () {
        if ($('#EmailInputId').val().length <= 0) {

            EmailInputIsValid = false;
            $('#EmailInputId').addClass("inputFieldError");
            $('#help-block-id-EmailId').removeClass("hidden");
        } else {
            EmailInputIsValid = true;
        }
    }
    var validateEmailMatched = function () {
        var requiredPattern = new RegExp("^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        var isAMatch = requiredPattern.test($('#EmailInputId'));
        if (!isAMatch) {

            EmailMatchedIsValid = false;
            $('#EmailInputId').addClass("inputFieldError");
            $('#help-block-id-DateOfBirthId').removeClass("hidden");
        } else {
            EmailMatchedIsValid = true;
        }
    }
    var validatePhoneNumberInput = function () {
        if ($('#PhoneNumberInputId').val().length <= 0) {

            PhoneNumberInputIsValid = false;
            $('#PhoneNumberInputId').addClass("inputFieldError");
            $('#help-block-id-PhoneNumberId').removeClass("hidden");
        } else {
            PhoneNumberInputIsValid = true;
        }
    }
    var validatePhoneNumberMatches = function () {
        var requiredPattern = new RegExp("^[0\+][\d\s\-\(\)]{10,25}$");
        var isAMatch = requiredPattern.test($('#PhoneNumberInputId'));
        if (!isAMatch) {

            PhoneNumberMatchedIsValid = false;
            $('#PhoneNumberInputId').addClass("inputFieldError");
            $('#help-block-id-PhoneNumberId').removeClass("hidden");
        } else {
            PhoneNumberMatchedIsValid = true;
        }
    }
    var validatePasswordInput = function () {
        if ($('#PasswordInputId').val().length <= 0) {

            PasswordInputIsValid = false;
            $('#PasswordInputId').addClass("inputFieldError");
            $('#help-block-id-PasswordId').removeClass("hidden");
        } else {
            PasswordInputIsValid = true;
        }
    }
    var validatePasswordMatches = function () {
        var requiredPattern = new RegExp("^([a-zA-Z0-9@*#]{8,20})$");
        var isAMatch = requiredPattern.test($('#PasswordInputId'));
        if (!isAMatch) {

            PasswordMatchedIsValid = false;
            $('#PasswordInputId').addClass("inputFieldError");
            $('#help-block-id-PasswordId').removeClass("hidden");
        } else {
            PasswordMatchedIsValid = true;
        }
    }
    var validateConfirmedPasswordInput = function () {
        if ($('#PhoneNumberInputId').val().length <= 0) {

            ConfirmedPasswordInputIsValid = false;
            $('#ConfirmedPasswordInputId').addClass("inputFieldError");
            $('#help-block-id-ConfirmedPasswordId').removeClass("hidden");
        } else {
            ConfirmedPasswordInputIsValid = true;
        }
    }
    var validateConfirmedPasswordMatches = function () {
        var requiredPattern = new RegExp("^([a-zA-Z0-9@*#]{8,15})$");
        var isAMatch = requiredPattern.test($('#ConfirmedPasswordInputId'));
        if (!isAMatch) {

            PasswordMatchedIsValid = false;
            $('#ConfirmedPasswordInputId').addClass("inputFieldError");
            $('#help-block-id-ConfirmedPasswordId').removeClass("hidden");
        } else {
            ConfirmedPasswordMatchedIsValid = true;
        }
    }

    var resetFirstNameInputRequiredError = function () {
        $('#FirstNameInputId').removeClass("inputFieldError");
        $('#help-block-id-FirstNameId').addClass('hidden');
        $('.idHelpBlockErrorMsgInRed').addClass('hidden');
    }
    var resetFirstNameInputLengthRequiredError = function () {
        $('#FirstNameInputId').removeClass("inputFieldError");
        $('#help-block-id-FirstNameId').addClass("hidden");
    }
    var resetLastNameInputRequiredError = function() {
        $('#LastNameInputId').removeClass("inputFieldError");
        $('#help-block-id-LastNameId').addClass("hidden");
    }
    var resetLastNameInputLengthRequiredError = function () {
        $('#LastNameInputId').removeClass("inputFieldError");
        $('#help-block-id-LastNameId').addClass("hidden");
    }
    var resetFirstLineOfAddressInputRequiredError = function () {
        $('#FirstLineOfAddressInputId').removeClass("inputFieldError");
        $('#help-block-id-FirstLineOfAddressId').addClass("hidden");
    }
    var resetFirstLineOfAddressInputLengthRequiredError = function () {
        $('#FirstLineOfAddressInputId').removeClass("inputFieldError");
        $('#help-block-id-FirstLineOfAddressId').addClass("hidden");
    }
    var resetSecondLineOfAddressInputRequiredError = function () {
        $('#SecondLineOfAddressInputId').removeClass("inputFieldError");
        $('#help-block-id-SecondLineOfAddressId').addClass("hidden");
    }
    var resetSecondLineOfAddressInputLengthRequiredError = function () {
        $('#SecondLineOfAddressInputId').removeClass("inputFieldError");
        $('#help-block-id-SecondLineOfAddressId').addClass("hidden");
    }
    var resetTownInputRequiredError = function () {
        $('#TownInputId').removeClass("inputFieldError");
        $('#help-block-id-TownId').addClass("hidden");
    }
    var resetTownInputLengthRequiredError = function () {
        $('#TownInputId').removeClass("inputFieldError");
        $('#help-block-id-TownId').addClass("hidden");
    }
    var resetPostcodeInputRequiredError = function () {
        $('#PostcodeInputId').removeClass("inputFieldError");
        $('#help-block-id-PostcodeId').addClass("hidden");
    }
    var resetPostcodeInputMatchedRequiredError = function () {
        $('#PostcodeInputId').removeClass("inputFieldError");
        $('#help-block-id-PostcodeId').addClass("hidden");
    }
    var resetDateOfBirthInputRequiredError = function () {
        $('#DateOfBirthInputId').removeClass("inputFieldError");
        $('#help-block-id-DateOfBirthId').addClass("hidden");
    }
    var resetDateOfBirthInputMatchedRequiredError = function () {
        $('#DateOfBirthInputId').removeClass("inputFieldError");
        $('#help-block-id-DateOfBirthId').addClass("hidden");
    }
    var resetCountryIdInputRequiredError = function () {
        $('#CountryIdInputId').removeClass("inputFieldError");
        $('#help-block-id-CountryId').addClass("hidden");
    }
    var resetGenderIdInputRequiredError = function () {
        $('#GenderIdInputId').removeClass("inputFieldError");
        $('#help-block-id-GenderId').addClass("hidden");
    }
    var resetEmailInputRequiredError = function () {
        $('#EmailInputId').removeClass("inputFieldError");
        $('#help-block-id-EmailId').addClass("hidden");
    }
    var resetEmailInputMatchedRequiredError = function () {
        $('#EmailInputId').removeClass("inputFieldError");
        $('#help-block-id-EmailId').addClass("hidden");
    }
    var resetPhoneNumberInputRequiredError = function () {
        $('#PhoneNumberInputId').removeClass("inputFieldError");
        $('#help-block-id-PhoneNumberId').addClass("hidden");
    }
    var resetPhoneNumberInputMatchedRequiredError = function () {
        $('#PhoneNumberInputId').removeClass("inputFieldError");
        $('#help-block-id-PhoneNumberId').addClass("hidden");
    }
    var resetPasswordInputRequiredError = function () {
        $('#PasswordInputId').removeClass("inputFieldError");
        $('#help-block-id-PasswordId').addClass("hidden");
    }
    var resetConfirmedPasswordInputRequiredError = function () {
        $('#ConfirmedPasswordInputId').removeClass("inputFieldError");
        $('#help-block-id-ConfirmedPasswordId').addClass("hidden");
    }
    var resetPasswordInputMatchedRequiredError = function () {
        $('#PasswordInputId').removeClass("inputFieldError");
        $('#help-block-id-PasswordId').addClass("hidden");
    }
    var resetConfirmedPasswordInputMatchedRequiredError = function () {
        $('#ConfirmedPasswordInputId').removeClass("inputFieldError");
        $('#help-block-id-ConfirmedPasswordId').addClass("hidden");
    }

    var onFirstNameInputFocusKeyPressedAndBackspace = function (event) {
        var firstNameInput = $('.FirstNameInput');
        var firstNameInputBackgroundColour = firstNameInput.css('backgroung-color');

        firstNameInput.focus(function () {

            if ((firstNameInputBackgroundColour === 'rgb(238,238,238)') ||
                (firstNameInputBackgroundColour === 'rgb(255,238,238)')) {
                firstNameInput.css("background", '#FFFFFF');
            }
            resetFirstNameInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((firstNameInputBackgroundColour === 'rgb(238,238,238)') ||
                    (firstNameInputBackgroundColour === 'rgb(255,238,238)')) {
                    firstNameInput.css("background", '#FFFFFF');
                }
                resetTransactionTypeIdInputRequiredError();
            }

        });;
    }
    var onLastNameInputFocusKeyPressedAndBackspace = function (event) {
        var lastNameInput = $('.LastNameInput');
        var lastNameInputBackgroundColour = lastNameInput.css('backgroung-color');

        lastNameInput.focus(function () {

            if ((lastNameInputBackgroundColour === 'rgb(238,238,238)') ||
                (lastNameInputBackgroundColour === 'rgb(255,238,238)')) {
                lastNameInput.css("background", '#FFFFFF');
            }
            resetLastNameInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((lastNameInputBackgroundColour === 'rgb(238,238,238)') ||
                    (lastNameInputBackgroundColour === 'rgb(255,238,238)')) {
                    firstNameInput.css("background", '#FFFFFF');
                }
                resetLastNameInputRequiredError();
            }

        });;
    }
    var onFirstLineOfAddressInputFocusKeyPressedAndBackspace = function (event) {
        var firstLineOfAddressInput = $('.FirstLineOfAddressInput');
        var firstLineOfAddressInputBackgroundColour = firstLineOfAddressInput.css('backgroung-color');

        firstLineOfAddressInput.focus(function () {

            if ((firstLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                (firstLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                lastNameInput.css("background", '#FFFFFF');
            }
            resetFirstLineOfAddressInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((firstLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                    (firstLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                    firstLineOfAddressInput.css("background", '#FFFFFF');
                }
                resetFirstLineOfAddressInputRequiredError();
            }

        });;
    }
    var onSecondLineOfAddressInputFocusKeyPressedAndBackspace = function (event) {
        var secondLineOfAddressInput = $('.SecondLineOfAddressInput');
        var secondLineOfAddressInputBackgroundColour = secondLineOfAddressInput.css('backgroung-color');

        secondLineOfAddressInput.focus(function () {

            if ((secondLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                (secondLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                secondLineOfAddressInput.css("background", '#FFFFFF');
            }
            resetSecondLineOfAddressInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((secondLineOfAddressInputBackgroundColour === 'rgb(238,238,238)') ||
                    (secondLineOfAddressInputBackgroundColour === 'rgb(255,238,238)')) {
                    secondLineOfAddressInput.css("background", '#FFFFFF');
                }
                resetSecondLineOfAddressInputRequiredError();
            }

        });;
    }
    var onTownInputFocusKeyPressedAndBackspace = function (event) {
        var townInput = $('.TownInput');
        var townInputBackgroundColour = townInput.css('backgroung-color');

        townInput.focus(function () {

            if ((townInputBackgroundColour === 'rgb(238,238,238)') ||
                (townInputBackgroundColour === 'rgb(255,238,238)')) {
                townInput.css("background", '#FFFFFF');
            }
            resetTownInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((townInputBackgroundColour === 'rgb(238,238,238)') ||
                    (townInputBackgroundColour === 'rgb(255,238,238)')) {
                    townInput.css("background", '#FFFFFF');
                }
                resetTownInputRequiredError();
            }

        });;
    }
    var onPostcodeInputFocusKeyPressedAndBackspace = function (event) {
        var postcodeInput = $('.PostcodeInput');
        var postcodeInputBackgroundColour = postcodeInput.css('backgroung-color');

        postcodeInput.focus(function () {

            if ((postcodeInputBackgroundColour === 'rgb(238,238,238)') ||
                (postcodeInputBackgroundColour === 'rgb(255,238,238)')) {
                postcodeInput.css("background", '#FFFFFF');
            }
            resetPostcodeInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((postcodeInputBackgroundColour === 'rgb(238,238,238)') ||
                    (postcodeInputBackgroundColour === 'rgb(255,238,238)')) {
                    postcodeInput.css("background", '#FFFFFF');
                }
                resetPostcodeInputRequiredError();
            }

        });;
    }
    var onDateOfBirthInputFocusKeyPressedAndBackspace = function (event) {
        var DateOfBirthInput = $('.DateOfBirthInput');
        var DateOfBirthInputBackgroundColour = DateOfBirthInput.css('backgroung-color');

        DateOfBirthInput.focus(function () {

            if ((DateOfBirthInputBackgroundColour === 'rgb(238,238,238)') ||
                (DateOfBirthInputBackgroundColour === 'rgb(255,238,238)')) {
                DateOfBirthInput.css("background", '#FFFFFF');
            }
            resetDateOfBirthInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((DateOfBirthInputBackgroundColour === 'rgb(238,238,238)') ||
                    (DateOfBirthInputBackgroundColour === 'rgb(255,238,238)')) {
                    DateOfBirthInput.css("background", '#FFFFFF');
                }
                resetDateOfBirthInputRequiredError();
            }

        });;
    }
    var onCountryIdInputFocusKeyPressedAndBackspace = function (event) {
        var countryIdInput = $('.CountryIdInput');
        var countryIdInputBackgroundColour = countryIdInput.css('backgroung-color');

        countryIdInput.focus(function () {

            if ((countryIdInputBackgroundColour === 'rgb(238,238,238)') ||
                (countryIdInputBackgroundColour === 'rgb(255,238,238)')) {
                countryIdInput.css("background", '#FFFFFF');
            }
            resetCountryIdInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((countryIdInputBackgroundColour === 'rgb(238,238,238)') ||
                    (countryIdInputBackgroundColour === 'rgb(255,238,238)')) {
                    countryIdInput.css("background", '#FFFFFF');
                }
                resetCountryIdInputRequiredError();
            }

        });;
    }
    var onGenderIdInputFocusKeyPressedAndBackspace = function (event) {
        var genderIdInput = $('.GenderIdInput');
        var genderIdInputBackgroundColour = genderIdInput.css('backgroung-color');

        genderIdInput.focus(function () {

            if ((genderIdInputBackgroundColour === 'rgb(238,238,238)') ||
                (genderIdInputBackgroundColour === 'rgb(255,238,238)')) {
                genderIdInput.css("background", '#FFFFFF');
            }
            resetGenderIdInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((genderIdInputBackgroundColour === 'rgb(238,238,238)') ||
                    (genderIdInputBackgroundColour === 'rgb(255,238,238)')) {
                    genderIdInput.css("background", '#FFFFFF');
                }
                resetGenderIdInputRequiredError();
            }

        });
    }
    var onEmailInputFocusKeyPressedAndBackspace = function (event) {
        var emailInput = $('.EmailInput');
        var emailIdInputBackgroundColour = emailInput.css('backgroung-color');

        emailInput.focus(function () {

            if ((emailIdInputBackgroundColour === 'rgb(238,238,238)') ||
                (emailIdInputBackgroundColour === 'rgb(255,238,238)')) {
                emailInput.css("background", '#FFFFFF');
            }
            resetEmailInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((emailIdInputBackgroundColour === 'rgb(238,238,238)') ||
                    (emailIdInputBackgroundColour === 'rgb(255,238,238)')) {
                    emailInput.css("background", '#FFFFFF');
                }
                resetEmailInputRequiredError();
            }

        });;
    }
    var onPhoneNumberInputFocusKeyPressedAndBackspace = function (event) {
        var phoneNumberInput = $('.PhoneNumberInput');
        var phoneNumberInputBackgroundColour = phoneNumberInput.css('backgroung-color');

        phoneNumberInput.focus(function () {

            if ((phoneNumberInputBackgroundColour === 'rgb(238,238,238)') ||
                (phoneNumberInputBackgroundColour === 'rgb(255,238,238)')) {
                phoneNumberInput.css("background", '#FFFFFF');
            }
            resetPhoneNumberInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((phoneNumberInputBackgroundColour === 'rgb(238,238,238)') ||
                    (phoneNumberInputBackgroundColour === 'rgb(255,238,238)')) {
                    phoneNumberInput.css("background", '#FFFFFF');
                }
                resetPhoneNumberInputRequiredError();
            }

        });;
    }
    var onPasswordInputFocusKeyPressedAndBackspace = function (event) {
        var passwordInput = $('.PasswordInput');
        var passwordInputBackgroundColour = passwordInput.css('backgroung-color');

        passwordInput.focus(function () {

            if ((passwordInputBackgroundColour === 'rgb(238,238,238)') ||
                (passwordInputBackgroundColour === 'rgb(255,238,238)')) {
                passwordInput.css("background", '#FFFFFF');
            }
            resetPasswordInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((passwordInputBackgroundColour === 'rgb(238,238,238)') ||
                    (passwordInputBackgroundColour === 'rgb(255,238,238)')) {
                    passwordInput.css("background", '#FFFFFF');
                }
                resetPasswordInputMatchedRequiredError();
            }

        });;
    }
    var onConfirmedPasswordInputFocusKeyPressedAndBackspace = function (event) {
        var confirmedPasswordInput = $('.ConfirmedPasswordInput');
        var confirmedPasswordInputBackgroundColour = confirmedPasswordInput.css('backgroung-color');

        confirmedPasswordInput.focus(function () {

            if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                (confirmedPasswordInputBackgroundColour === 'rgb(255,238,238)')) {
                confirmedPasswordInput.css("background", '#FFFFFF');
            }
            resetConfirmedPasswordInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((confirmedPasswordInputBackgroundColour === 'rgb(238,238,238)') ||
                    (confirmedPasswordInputBackgroundColour === 'rgb(255,238,238)')) {
                    confirmedPasswordInput.css("background", '#FFFFFF');
                }
                resetConfirmedPasswordInputMatchedRequiredError();
            }

        });;
    }

    var init = function () {

        $('#registrationBtnId').click(function(e) {

            e.preventDefault();

            validateFirstNameInput();
            validateFirstNameLength();
            validateLastNameInput();
            validateLastNameLength();
            validateFirstLineOfAddressInput();
            validateFirstLineOfAddressLength();
            validateSecondLineOfAddressLength();
            validateTownLength();
            validateTownInput();
            validatePostcodeInput();
            validatePostcodeMatched();
            validateDateOfBirthInput()
            validateDateOfBirthMatches();
            validateCountryIdInput();
            validateGenderIdInput();
            validateEmailInput();
            validateEmailMatched();
            validatePhoneNumberInput();
            validatePhoneNumberMatches();
            validatePasswordInput();
            validatePasswordMatches();
            validateConfirmedPasswordInput();
            validateConfirmedPasswordMatches();

            var submitControl = FirstNameInputIsValid &&
                FirstNameLengthIsValid &&
                LastNameInputIsValid &&
                LastNameLengthIsValid &&
                FirstLineOfAddressInputIsValid &&
                FirstLineOfAddressLengthIsValid &&
                SecondLineOfAddressInputIsValid &&
                SecondLineOfAddressLengthIsValid &&
                TownInputIsValid &&
                TownLengthIsValid &&
                PostcodeInputIsValid &&
                PostcodeLengthIsValid &&
                GenderIdInputIsValid &&
                DateOfBirthInputIsValid &&
                DateOfBirthMatchedIsValid &&
                GenderIdInputIsValid &&
                CountryIdInputIsValid &&
                EmailInputIsValid &&
                EmailMatchedIsValid &&
                PhoneNumberInputIsValid &&
                PhoneNumberMatchedIsValid &&
                PasswordInputIsValid &&
                PasswordMatchedIsValid &&
                ConfirmedPasswordInputIsValid &&
                ConfirmedPhoneNumberMatchedIsValid;
                

            if (submitControl) {
                $('.registrationForm').submit();
            }
        });
        resetFirstNameInputRequiredError();
        resetFirstNameInputLengthRequiredError();
        resetLastNameInputRequiredError();
        resetLastNameInputLengthRequiredError();
        resetFirstLineOfAddressInputRequiredError();
        resetFirstLineOfAddressInputLengthRequiredError();
        resetSecondLineOfAddressInputRequiredError();
        resetSecondLineOfAddressInputLengthRequiredError();
        resetTownInputRequiredError();
        resetTownInputLengthRequiredError();
        resetPostcodeInputRequiredError();
        resetPostcodeInputMatchedRequiredError();
        resetDateOfBirthInputRequiredError();
        resetDateOfBirthInputMatchedRequiredError();
        resetCountryIdInputRequiredError();
        resetGenderIdInputRequiredError();
        resetEmailInputRequiredError();
        resetEmailInputMatchedRequiredError();
        resetPhoneNumberInputRequiredError();
        resetPhoneNumberInputMatchedRequiredError();
        resetPasswordInputRequiredError();
        resetConfirmedPasswordInputRequiredError();
        resetPasswordInputMatchedRequiredError();
        resetConfirmedPasswordInputMatchedRequiredError();


        $('.FirstNameInput').on("keypress", registrationValidation.onFirstNameInputFocusKeyPressedAndBackspace);
        $('.LastNameInput').on("keypress", registrationValidation.onLastNameInputFocusKeyPressedAndBackspace);
        $('.FirstLineOfAddressNameInput').on("keypress", registrationValidation.onFirstLineOfAddressLastNameInputFocusKeyPressedAndBackspace);
        $('.SecondLineOfAddressNameInput').on("keypress", registrationValidation.onSecondLineOfAddressLastNameInputFocusKeyPressedAndBackspace);
        $('.TownInput').on("keypress", registrationValidation.onTownInputFocusKeyPressedAndBackspace);
        $('.PostcodeInput').on("keypress", registrationValidation.onPostcodeInputFocusKeyPressedAndBackspace);
        $('.DateOfBirthInput').on("keypress", registrationValidation.onDateOfBirthInputFocusKeyPressedAndBackspace);
        $('.CountryIdInput').on("keypress", registrationValidation.onCountryIdInputFocusKeyPressedAndBackspace);
        $('.GenderIdInput').on("keypress", registrationValidation.onGenderIdInputFocusKeyPressedAndBackspace);
        $('.EmailInput').on("keypress", registrationValidation.onEmailInputFocusKeyPressedAndBackspace);
        $('.PhoneNumberInput').on("keypress", registrationValidation.onPhoneNumberInputFocusKeyPressedAndBackspace);
        $('.PasswordInput').on("keypress", registrationValidation.onPasswordInputFocusKeyPressedAndBackspace);
        $('.ConfirmedPasswordInput').on("keypress", registrationValidation.onConfirmedPasswordInputFocusKeyPressedAndBackspace);
    }


    return {
        init: init,
        validateFirstNameInput: validateFirstNameInput,
        validateFirstNameLength: validateFirstNameLength,
        validateLastNameInput: validateLastNameInput,
        validateLastNameLength: validateLastNameLength,
        validateFirstLineOfAddressInput: validateFirstLineOfAddressInput,
        validateFirstLineOfAddressLength: validateFirstLineOfAddressLength,
        validateSecondLineOfAddressLength: validateSecondLineOfAddressLength,
        validateSecondLineOfAddressInput: validateSecondLineOfAddressInput,
        validateTownLength: validateTownLength,
        validateTownInput: validateTownInput,
        validatePostcodeInput: validatePostcodeInput,
        validatePostcodeLength: validatePostcodeMatched,
        validateDateOfBirthInput: validateDateOfBirthInput,
        validateDateOfBirthMatches: validateDateOfBirthMatches,
        validateCountryIdInput: validateCountryIdInput,
        validateGenderIdInput: validateGenderIdInput,
        validateEmailInput: validateEmailInput,
        validateEmailMatched: validateEmailMatched,
        validatePhoneNumberInput: validatePhoneNumberInput,
        validatePhoneNumberMatches: validatePhoneNumberMatches,
        validatePasswordInput: validatePasswordInput,
        validatePasswordMatches: validatePasswordMatches,
        validateConfirmedPasswordInput: validateConfirmedPasswordInput,
        validateConfirmedPasswordMatches: validateConfirmedPasswordMatches,

        resetFirstNameInputRequiredError: resetFirstNameInputRequiredError,
        resetFirstNameInputLengthRequiredError: resetFirstNameInputLengthRequiredError,
        resetLastNameInputRequiredError: resetLastNameInputRequiredError,
        resetLastNameInputLengthRequiredError: resetLastNameInputLengthRequiredError,
        resetFirstLineOfAddressInputRequiredError: resetFirstLineOfAddressInputRequiredError,
        resetFirstLineOfAddressInputLengthRequiredError: resetFirstLineOfAddressInputLengthRequiredError,
        resetSecondLineOfAddressInputRequiredError: resetSecondLineOfAddressInputRequiredError,
        resetSecondLineOfAddressInputLengthRequiredError: resetSecondLineOfAddressInputLengthRequiredError,
        resetTownInputRequiredError: resetTownInputRequiredError,
        resetTownInputLengthRequiredError: resetTownInputLengthRequiredError,
        resetPostcodeInputRequiredError: resetPostcodeInputRequiredError,
        resetPostcodeInputMatchedRequiredError: resetPostcodeInputMatchedRequiredError,
        resetDateOfBirthInputRequiredError: resetDateOfBirthInputRequiredError,
        resetDateOfBirthInputMatchedRequiredError: resetDateOfBirthInputMatchedRequiredError,
        resetCountryIdInputRequiredError: resetCountryIdInputRequiredError,
        resetGenderIdInputRequiredError: resetGenderIdInputRequiredError,
        resetEmailInputRequiredError: resetEmailInputRequiredError,
        resetEmailInputMatchedRequiredError: resetEmailInputMatchedRequiredError,
        resetPhoneNumberInputRequiredError: resetPhoneNumberInputRequiredError,
        resetPhoneNumberInputMatchedRequiredError: resetPhoneNumberInputMatchedRequiredError,
        resetPasswordInputMatchedRequiredError: resetPasswordInputMatchedRequiredError,
        resetConfirmedPasswordInputMatchedRequiredError: resetConfirmedPasswordInputMatchedRequiredError,


        onFirstNameInputFocusKeyPressedAndBackspace: onFirstNameInputFocusKeyPressedAndBackspace,
        onLastNameInputFocusKeyPressedAndBackspace: onLastNameInputFocusKeyPressedAndBackspace,
        onFirstLineOfAddressInputFocusKeyPressedAndBackspace: onFirstLineOfAddressInputFocusKeyPressedAndBackspace,
        onSecondLineOfAddressInputFocusKeyPressedAndBackspace: onSecondLineOfAddressInputFocusKeyPressedAndBackspace,
        onTownInputFocusKeyPressedAndBackspace: onTownInputFocusKeyPressedAndBackspace,
        onPostcodeInputFocusKeyPressedAndBackspace: onPostcodeInputFocusKeyPressedAndBackspace,
        onDateOfBirthInputFocusKeyPressedAndBackspace: onDateOfBirthInputFocusKeyPressedAndBackspace,
        onCountryIdInputFocusKeyPressedAndBackspace: onCountryIdInputFocusKeyPressedAndBackspace,
        onGenderIdInputFocusKeyPressedAndBackspace: onGenderIdInputFocusKeyPressedAndBackspace,
        onEmailInputFocusKeyPressedAndBackspace: onEmailInputFocusKeyPressedAndBackspace,
        onPhoneNumberInputFocusKeyPressedAndBackspace: onPhoneNumberInputFocusKeyPressedAndBackspace,
        resetPasswordInputRequiredError: resetPasswordInputRequiredError,
        onPasswordInputFocusKeyPressedAndBackspace: onPasswordInputFocusKeyPressedAndBackspace,
        onConfirmedPasswordInputFocusKeyPressedAndBackspace: onConfirmedPasswordInputFocusKeyPressedAndBackspace
}
})();
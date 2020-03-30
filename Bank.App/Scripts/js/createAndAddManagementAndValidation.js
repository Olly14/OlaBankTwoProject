var createAndAddManagementAndValidation = (function() {

    var accountTypeIdInputIsValid = true;
    var OpeningBalanceInputIsValid = true;
    var currencyIdInputIsValid = true;

    var UiCreateControl = function () {

        if ($('#NumberOfAccounts').val() >= $('#NumberOfAccountsAllowed').val()) {

            $('#maximumAccountAcquiredId').removeClass("hidden");
            $('#maximumAccountNotAcquiredId').addClass("hidden");

        } else {

            $('#maximumAccountNotAcquiredId').removeClass("hidden");
            $('#maximumAccountAcquiredId').addClass("hidden");
        }
    }

    var validateAccountTypeIdInput = function() {
        if ($('#AccountTypeIdInputId').val().length <= 0) {

            accountTypeIdInputIsValid = false;
            $('#help-block-id-AccountTypeInputId').removeClass("hidden");
            $('#AccountTypeIdInputId').addClass("inputFieldError");
        } else {
            accountTypeIdInputIsValid = true;
        }
    }
    var validateOpeningBalanceIdInput = function () {
        if ($('#OpeningBalanceInputId').val().length <= 0) {

            OpeningBalanceInputIsValid = false;
            $('#help-block-id-OpeningBalanceId').removeClass("hidden");
            $('#OpeningBalanceInputId').addClass("inputFieldError");
        } else {
            OpeningBalanceInputIsValid = true;
        }
    }
    var validateOpeningBalanceIdInputGreaterThanTenPound = function () {
        if ($('#OpeningBalanceInputId').val() <= 9) {

            OpeningBalanceInputIsValid = false;
            $('#help-block-id-OpeningBalanceId').removeClass("hidden");
            $('#OpeningBalanceInputId').addClass("inputFieldError");
        } else {
            OpeningBalanceInputIsValid = true;
        }
    }
    var validateCountryIdInput = function () {
        if ($('#CurrencyIdInputId').val().length <= 0) {

            currencyIdInputIsValid = false;
            $('#help-block-id-CurrencyId').removeClass("hidden");
            $('#CurrencyIdInputId').addClass("inputFieldError");
        } else {
            currencyIdInputIsValid = true;
        }
    }

    var resetAccountTypeIdInputRequiredError = function () {
        $('#AccountTypeIdInputId').removeClass("inputFieldError");
        $('#help-block-id-AccountTypeId').addClass("hidden");
    };
    var resetOpeningBalanceInputRequiredError = function () {
        $('#OpeningBalanceInputId').removeClass("inputFieldError");
        $('#help-block-id-OpeningBalanceId').addClass("hidden");
    };
    var resetOpeningBalanceGreaterThanTenInputRequiredError = function () {
        $('#OpeningBalanceInputId').removeClass("inputFieldError");
        $('#help-block-id-OpeningBalanceId').addClass("hidden");
    };
    var resetCountryTypeIdInputRequiredError = function () {
        $('#CountryTypeIdInput').removeClass("inputFieldError");
        $('#help-block-id-CountryTypeId').addClass("hidden");
    };


    var onAccountTypeInputFocusKeyPressedAndBackspace = function (event) {
        var accountTypeInput = $('#AccountTypeIdInputId');
        var accountTypeInputBackgroundColour = accountTypeInput.css('backgroung-color');

        accountTypeInput.focus(function () {

            if ((accountTypeInputBackgroundColour === 'rgb(238,238,238)') ||
                (accountTypeInputBackgroundColour === 'rgb(255,238,238)')) {
                accountTypeInput.css("background", '#FFFFFF');
            }
            resetAccountTypeIdInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((accountTypeInputBackgroundColour === 'rgb(238,238,238)') ||
                    (accountTypeInputBackgroundColour === 'rgb(255,238,238)')) {
                    accountTypeInput.css("background", '#FFFFFF');
                }
                resetAccountTypeIdInputRequiredError();
            }

        });;
    }

    var onOpeningBalanceInputFocusKeyPressedAndBackspace = function (event) {
        var openingBalanceInput = $('#OpeningBalanceInputId');
        var openingBalanceInputBackgroundColour = openingBalanceInput.css('backgroung-color');

        openingBalanceInput.focus(function () {

            if ((openingBalanceInputBackgroundColour === 'rgb(238,238,238)') ||
                (openingBalanceInputBackgroundColour === 'rgb(255,238,238)')) {
                openingBalanceInput.css("background", '#FFFFFF');
            }
            resetOpeningBalanceInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((openingBalanceInputBackgroundColour === 'rgb(238,238,238)') ||
                    (openingBalanceInputBackgroundColour === 'rgb(255,238,238)')) {
                    openingBalanceInput.css("background", '#FFFFFF');
                }
                resetOpeningBalanceInputRequiredError();
            }

        });;
    }

    var onOpeningBalanceGreaterThanTenInputFocusKeyPressedAndBackspace = function (event) {
        var openingBalanceInput = $('#OpeningBalanceInputId');
        var openingBalanceInputBackgroundColour = openingBalanceInput.css('backgroung-color');

        openingBalanceInput.focus(function () {

            if ((openingBalanceInputBackgroundColour === 'rgb(238,238,238)') ||
                (openingBalanceInputBackgroundColour === 'rgb(255,238,238)')) {
                openingBalanceInput.css("background", '#FFFFFF');
            }
            resetOpeningBalanceGreaterThanTenInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((openingBalanceInputBackgroundColour === 'rgb(238,238,238)') ||
                    (openingBalanceInputBackgroundColour === 'rgb(255,238,238)')) {
                    openingBalanceInput.css("background", '#FFFFFF');
                }
                resetOpeningBalanceGreaterThanTenInputRequiredError();
            }

        });
    }

    var onCountryIdInputFocusKeyPressedAndBackspace = function (event) {
        var countryIdInput = $('#CurrencyIdInputId');
        var countryIdInputBackgroundColour = countryIdInput.css('backgroung-color');

        countryIdInput.focus(function () {

            if ((countryIdInputBackgroundColour === 'rgb(238,238,238)') ||
                (countryIdInputBackgroundColour === 'rgb(255,238,238)')) {
                countryIdInput.css("background", '#FFFFFF');
            }
            resetCountryTypeIdInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((countryIdInputBackgroundColour === 'rgb(238,238,238)') ||
                    (countryIdInputBackgroundColour === 'rgb(255,238,238)')) {
                    countryIdInput.css("background", '#FFFFFF');
                }
                resetCountryTypeIdInputRequiredError();
            }

        });;
    }

    var init = function() {

        UiCreateControl();

        $('#submitBtnId').click(function(e) {

            e.preventDefault();
            validateAccountTypeIdInput();
            validateOpeningBalanceIdInput();
            validateOpeningBalanceIdInputGreaterThanTenPound();
            validateCountryIdInput();

            var submitControl = accountTypeIdInputIsValid && OpeningBalanceInputIsValid && currencyIdInputIsValid;
            if (submitControl) {
                
                $('.CreateForm').submit();
            }


            $('#submitBtnId').on("keypress",
                createAndAddManagementAndValidation.onAccountTypeInputFocusKeyPressedAndBackspace());
            $('#submitBtnId').on("keypress",
                createAndAddManagementAndValidation.onOpeningBalanceInputFocusKeyPressedAndBackspace());
            $('#submitBtnId').on("keypress",
                createAndAddManagementAndValidation.onOpeningBalanceGreaterThanTenInputFocusKeyPressedAndBackspace());
            $('#submitBtnId').on("keypress",
                createAndAddManagementAndValidation.onCountryIdInputFocusKeyPressedAndBackspace());

        });
    }


    return {
        init: init,

        UiCreateControl: UiCreateControl,

        validateAccountTypeIdInput: validateAccountTypeIdInput,
        validateOpeningBalanceIdInput: validateOpeningBalanceIdInput,
        validateOpeningBalanceIdInputGreaterThanTenPound: validateOpeningBalanceIdInputGreaterThanTenPound,
        validateCountryIdInput: validateCountryIdInput,

        resetAccountTypeIdInputRequiredError: resetAccountTypeIdInputRequiredError,
        resetOpeningBalanceInputRequiredError: resetOpeningBalanceInputRequiredError,
        resetOpeningBalanceGreaterThanTenInputRequiredError: resetOpeningBalanceGreaterThanTenInputRequiredError,
        resetCountryTypeIdInputRequiredError: resetCountryTypeIdInputRequiredError,

        onAccountTypeInputFocusKeyPressedAndBackspace: onAccountTypeInputFocusKeyPressedAndBackspace,
        onOpeningBalanceInputFocusKeyPressedAndBackspace: onOpeningBalanceInputFocusKeyPressedAndBackspace,
        onOpeningBalanceGreaterThanTenInputFocusKeyPressedAndBackspace: onOpeningBalanceGreaterThanTenInputFocusKeyPressedAndBackspace,
        onCountryIdInputFocusKeyPressedAndBackspace: onCountryIdInputFocusKeyPressedAndBackspace

    }


    

})();
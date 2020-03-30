var accountTransactionViewModelUIManagementAndValidation = (function () {

    var onlyOneAccountUI = function () {

        if ($('#NumberOfAccounts').val() === "1") {

            $('#onlyOneAccountId').removeClass("hidden");
            $('#MoreThanOneAccountId').addClass("hidden");
        } else {
            $('#onlyOneAccountId').addClass("hidden");
            $('#MoreThanOneAccountId').removeClass("hidden");
        }
    }

    var creditAndDebitTransactionUI = function () {
        if ($('#UiControl').val() === "Debit") {
            //Transfer UI
            $('#header2Id').text("Debit Transaction");
            $('#header4Id').text("Debit Account with Fund");

            $('#AccountToCreditLabelId').addClass("hidden");
            $('#AccountToCreditInputId').addClass("hidden");

            $('#AccountToDebitLabelId').removeClass("hidden");
            $('#AccountToDebitInputId').removeClass("hidden");

        } else if ($('#UiControl').val() === "Credit") {

            //Credit UI
            $('#header2Id').text("Credit Transaction");
            $('#header4Id').text("Credit Account with Fund");
            $('#AccountToDebitLabelId').addClass("hidden");
            $('#AccountToDebitInputId').addClass("hidden");

            $('#AccountToCreditLabelId').removeClass("hidden");
            $('#AccountToCreditInputId').removeClass("hidden");
        }
        else if ($('#UiControl').val() === "Transfer") {
            //Debit UI
            $('#AccountToDebitLabelId').addClass("hidden");
            $('#AccountToDebitInputId').addClass("hidden");

            $('#AccountToCreditLabelId').removeClass("hidden");
            $('#AccountToCreditInputId').removeClass("hidden");
        } 
    }



    var transactionTypeIdInputIsValid = true;
    var accountToCreditInputIsValid = true;
    var accountToDebitInputIsValid = true;
    var orderByTypeIdInputIsValid = true;
    var amountToCreditInputIsValid = true;
    var referenceInputIsValid = true;

    var validateTransactionTypeId = function () {
        if ($('#TransactionTypeIdInputId').val() === "") {
            transactionTypeIdInputIsValid = false;
            $('#TransactionTypeIdInputId').addClass("inputFieldError");
            $('#help-block-id-TransactionTypeIdInputId').removeClass("hidden");
        } else {
            transactionTypeIdInputIsValid = true;
        }

    }
    var validateOrderByTypeIdInput = function () {
        if ($('#OrderByTypeIdInputId').val() === "") {
            OrderByTypeIdInputIsValid = false;
            $('#OrderByTypeIdInputId').addClass("inputFieldError");
            $('#help-block-id-OrderByTypeIdInputId').removeClass("hidden");
        } else {
            OrderByTypeIdInputIsValid = true;
        }

    }
    var validateAccountToCreditInput = function () {
        if ($('#UiControl').val() === "Credit" || $('#UiControl').val() === "Transfer") {

            if ($('#AccountToCreditInputId').val() === "") {

                AccountToCreditInputIsValid = false;
                $('#AccountToCreditInputId').addClass("inputFieldError");
                $('#help-block-id-AccountToCreditInputId').removeClass("hidden");
            } else {
                AccountToCreditInputIsValid = true;
            }

        }
    }

    var validateAccountToDebitInput = function () {
        if ($('#UiControl').val() === "Debit") {

            if ($('#AccountToDebitInputId').val() === "") {

                AccountToDebitInputIsValid = false;
                $('#AccountToDebitInputId').addClass("inputFieldError");
                $('#help-block-id-AccountToDebitInputId').removeClass("hidden");
            } else {
                AccountToDebitInputIsValid = true;
            }

        }
    }

    var validateAmountToCreditInput = function () {
        if ($('#AmountToCreditInputId').val() <= 0) {
            AmountToCreditInputIsValid = false;
            $('#AmountToCreditInputId').addClass("inputFieldError");
            $('#help-block-id-AmountToCreditInputId').removeClass("hidden");
        } else {
            AmountToCreditInputIsValid = true;
        }

    }


    var validateAmountToCreditInputLesThanTen = function () {

        if ($('#AmountToCreditInputId').val() > 1) {

            if ($('#AmountToCreditInputId').val() <= 9) {
                AmountToCreditInputIsValid = false;
                $('#AmountToCreditInputId').addClass("inputFieldError");
                $('#help-block-id-LessThanTenAmountToCreditInputId').removeClass("hidden");
            } else {
                AmountToCreditInputIsValid = true;
            }
        } else {
            AmountToCreditInputIsValid = true;
        }


    }
    var validateReferenceInput = function () {
        if ($('#ReferenceInputId').val() === "") {
            ReferenceInputIsValid = false;
            $('#ReferenceInputId').addClass("inputFieldError");
            $('#help-block-id-ReferenceInputId').removeClass("hidden");
        } else {
            ReferenceInputIsValid = true;
        }

    }




    var resetTransactionTypeIdInputRequiredError = function () {
        $('#TransactionTypeIdInputId').removeClass("inputFieldError");
        $('#help-block-id-TransactionTypeIdInputId').addClass("hidden");
    };
    var resetOrderByTypeIdInputRequiredError = function () {
        $('#OrderByTypeIdInputId').removeClass("inputFieldError");
        $('#help-block-id-OrderByTypeIdInputId').addClass("hidden");
    };
    var resetAccountToCreditInputRequiredError = function () {
        $('#AccountToCreditInputId').removeClass("inputFieldError");
        $('#help-block-id-AccountToCreditInputId').addClass("hidden");
    };
    var resetAccountToDebitInputRequiredError = function () {
        $('#AccountToDebitInputId').removeClass("inputFieldError");
        $('#help-block-id-AccountToDebitInputId').addClass("hidden");
    };
    var resetAccountToDebitInputRequiredError = function () {
        $('#AccountToDebitInputId').removeClass("inputFieldError");
        $('#help-block-id-AmountToCreditInputId').addClass("hidden");
    };
    var resetAmountToCreditInputRequiredError = function () {
        $('#AmountToCreditInputId').removeClass("inputFieldError");
        $('#help-block-id-AmountToCreditInputId').addClass("hidden");
        $('#help-block-id-LessThanTenAmountToCreditInputId').addClass("hidden");
        $('.help-block-hidden-text-danger-idHelpBlockErrorMsgInRed').addClass("hidden");
    };
    var resetReferenceInputRequiredError = function () {
        $('#ReferenceInputId').removeClass("inputFieldError");
        $('#help-block-id-ReferenceInputId').addClass("hidden");
    };



    var onTransactionTypeIdInputFocusKeyPressedAndBackspace = function (event) {
        var transactionTypeIdInput = $('#TransactionTypeIdInputId');
        var transactionTypeIdInputBackgroundColour = transactionTypeIdInput.css('backgroung-color');

        transactionTypeIdInput.focus(function () {

            if ((transactionTypeIdInputBackgroundColour === 'rgb(238,238,238)') ||
                (transactionTypeIdInputBackgroundColour === 'rgb(255,238,238)')) {
                transactionTypeIdInput.css("background", '#FFFFFF');
            }
            resetTransactionTypeIdInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((transactionTypeIdInputBackgroundColour === 'rgb(238,238,238)') ||
                    (transactionTypeIdInputBackgroundColour === 'rgb(255,238,238)')) {
                    transactionTypeIdInput.css("background", '#FFFFFF');
                }
                resetTransactionTypeIdInputRequiredError();
            }

        });;
    }


    var onOrderByTypeIdInputFocusKeyPressedAndBackspace = function (event) {
        var orderByTypeIdInput = $('#OrderByTypeIdInputId');
        var orderByTypeIdInputBackgroundColour = orderByTypeIdInput.css('backgroung-color');

        orderByTypeIdInput.focus(function () {

            if ((orderByTypeIdInputBackgroundColour === 'rgb(238,238,238)') ||
                (orderByTypeIdInputBackgroundColour === 'rgb(255,238,238)')) {
                orderByTypeIdInput.css("background", '#FFFFFF');
            }
            resetOrderByTypeIdInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((orderByTypeIdInputBackgroundColour === 'rgb(238,238,238)') ||
                    (orderByTypeIdInputBackgroundColour === 'rgb(255,238,238)')) {
                    orderByTypeIdInput.css("background", '#FFFFFF');
                }
                resetOrderByTypeIdInputRequiredError();
            }

        });;
    }

    var onAccountToCreditInputFocusKeyPressedAndBackspace = function (event) {
        var accountToCreditInput = $('#AccountToCreditInputId');
        var accountToCreditInputBackgroundColour = accountToCreditInput.css('backgroung-color');

        accountToCreditInput.focus(function () {

            if ((accountToCreditInputBackgroundColour === 'rgb(238,238,238)') ||
                (accountToCreditInputBackgroundColour === 'rgb(255,238,238)')) {
                accountToCreditInput.css("background", '#FFFFFF');
            }
            resetAccountToCreditInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((accountToCreditInputBackgroundColour === 'rgb(238,238,238)') ||
                    (accountToCreditInputBackgroundColour === 'rgb(255,238,238)')) {
                    accountToCreditInput.css("background", '#FFFFFF');
                }
                resetAccountToCreditInputRequiredError();
            }

        });;
    }

    var onAccountToDebitInputFocusKeyPressedAndBackspace = function (event) {
        var accountToDebitInput = $('#AccountToDebitInputId');
        var accountToDebitInputBackgroundColour = AccountToDebitInput.css('backgroung-color');

        accountToDebitInput.focus(function () {

            if ((accountToDebitInputBackgroundColour == 'rgb(238,238,238)') ||
                (accountToDebitInputBackgroundColour == 'rgb(255,238,238)')) {
                accountToDebitInput.css("background", '#FFFFFF');
            }
            resetAccountToDebitInputRequiredError();

        }).on('keydown', function (e) {
            if (e.keyCode == 8) {
                if ((accountToDebitInputBackgroundColour == 'rgb(238,238,238)') ||
                    (accountToDebitInputBackgroundColour == 'rgb(255,238,238)')) {
                    accountToDebitInput.css("background", '#FFFFFF');
                }
                resetAccountToDebitInputRequiredError();
            }

        });;
    }

var onAmountToCreditInputFocusKeyPressedAndBackspace = function (event) {
    var amountToCreditInput = $('#AmountToCreditInputId');
    var amountToCreditInputBackgroundColour = amountToCreditInput.css('backgroung-color');

    amountToCreditInput.keypress(function () {

        if ((amountToCreditInputBackgroundColour === 'rgb(238,238,238)') ||
            (amountToCreditInputBackgroundColour === 'rgb(255,238,238)')) {
            amountToCreditInput.css("background", '#FFFFFF');
        }
        resetAmountToCreditInputRequiredError();

    }).on('keydown', function (e) {
        if (e.keyCode == 8) {
            if ((amountToCreditInputBackgroundColour === 'rgb(238,238,238)') ||
                (amountToCreditInputBackgroundColour === 'rgb(255,238,238)')) {
                amountToCreditInput.css("background", '#FFFFFF');
            }
            resetAmountToCreditInputRequiredError();
        }

    });;
}

var onReferenceInputFocusKeyPressedAndBackspace = function (event) {
    var referenceInput = $('#ReferenceInputId');
    var referenceInputBackgroundColour = referenceInput.css('backgroung-color');

    referenceInput.keypress(function () {

        if ((referenceInputBackgroundColour === 'rgb(238,238,238)') ||
            (referenceInputBackgroundColour === 'rgb(255,238,238)')) {
            referenceInput.css("background", '#FFFFFF');
        }
        resetReferenceInputRequiredError();

    }).on('keydown', function (e) {
        if (e.keyCode == 8) {
            if ((referenceInputBackgroundColour === 'rgb(238,238,238)') ||
                (referenceInputBackgroundColour === 'rgb(255,238,238)')) {
                referenceInput.css("background", '#FFFFFF');
            }
            resetReferenceInputRequiredError();
        }

    });;
}


    var init = function () {

        onlyOneAccountUI();

        creditAndDebitTransactionUI();


        $('#creditDebitTransferBtnId').click(function (e) {

            e.preventDefault();

            validateTransactionTypeId();
            validateOrderByTypeIdInput();
            validateAccountToCreditInput();
            validateAccountToDebitInput();
            validateAmountToCreditInput();
            validateAmountToCreditInputLesThanTen();
            validateReferenceInput();
            var buttonControl = transactionTypeIdInputIsValid && accountToCreditInputIsValid &&
                accountToDebitInputIsValid && orderByTypeIdInputIsValid && amountToCreditInputIsValid &&
                referenceInputIsValid;

            if (buttonControl) {
                $('.TransactionForm').submit();
            }
        });


        $('#TransactionTypeIdInputId').on("keypress",
            accountTransactionViewModelUIManagementAndValidation.onTransactionTypeIdInputFocusKeyPressedAndBackspace());

        $('#OrderByTypeIdInputId').on("keypress",
            accountTransactionViewModelUIManagementAndValidation.onOrderByTypeIdInputFocusKeyPressedAndBackspace());


        $('#AccountToCreditInputId').on("keypress",
            accountTransactionViewModelUIManagementAndValidation.onAccountToCreditInputFocusKeyPressedAndBackspace());

        $('#AccountToDebitInputId').on("keypress",
            accountTransactionViewModelUIManagementAndValidation.onAccountToDebitInputFocusKeyPressedAndBackspace());

        $('#AmountToCreditInputId').on("keypress",
            accountTransactionViewModelUIManagementAndValidation.onAmountToCreditInputFocusKeyPressedAndBackspace());

        $('#ReferenceInputId').on("keypress",
            accountTransactionViewModelUIManagementAndValidation.onReferenceInputFocusKeyPressedAndBackspace());

    }

    return {
        init: init,
        creditAndDebitTransactionUI: creditAndDebitTransactionUI,
        validateTransactionTypeId: validateTransactionTypeId,
        validateAccountToCreditInput: validateAccountToCreditInput,
        validateAccountToDebitInput: validateAccountToDebitInput,
        validateAmountToCreditInputLesThanTen: validateAmountToCreditInputLesThanTen,
        validateOrderByTypeIdInput: validateOrderByTypeIdInput,
        validateAmountToCreditInput: validateAmountToCreditInput,
        validateReferenceInput: validateReferenceInput,



        onTransactionTypeIdInputFocusKeyPressedAndBackspace: onTransactionTypeIdInputFocusKeyPressedAndBackspace,
        onOrderByTypeIdInputFocusKeyPressedAndBackspace: onOrderByTypeIdInputFocusKeyPressedAndBackspace,
        onAccountToCreditInputFocusKeyPressedAndBackspace: onAccountToCreditInputFocusKeyPressedAndBackspace,
        onAccountToDebitInputFocusKeyPressedAndBackspace: onAccountToDebitInputFocusKeyPressedAndBackspace,
        onAmountToCreditInputFocusKeyPressedAndBackspace: onAmountToCreditInputFocusKeyPressedAndBackspace,
        onReferenceInputFocusKeyPressedAndBackspace: onReferenceInputFocusKeyPressedAndBackspace,

        resetTransactionTypeIdInputRequiredError: resetTransactionTypeIdInputRequiredError,
        resetOrderByTypeIdInputRequiredError: resetOrderByTypeIdInputRequiredError,
        resetAccountToCreditInputRequiredError: resetAccountToCreditInputRequiredError,
        resetAccountToDebitInputRequiredError: resetAccountToDebitInputRequiredError,
        resetAmountToCreditInputRequiredError: resetAmountToCreditInputRequiredError,
        resetReferenceInputRequiredError: resetReferenceInputRequiredError,

        onlyOneAccountUI: onlyOneAccountUI

        

    }


})();
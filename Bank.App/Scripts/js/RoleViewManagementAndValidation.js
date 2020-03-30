var roleViewManagementAndValidation = (function () {




    var init = function () {

        if ($('.idTextBox').val().length > 0) {

            $('.idLabel').removeClass("hidden")
            $('.idTextBox').removeClass("hidden");
            $('.idTextBox').prop("disabled", true);
            $('.roleUsersLabel').removeClass("hidden");
            $('.UserRolesTextBox').removeClass("hidden");
            $('.roleNameLabel').removeClass("hidden");
            $('.roleNameTextBox').removeClass("hidden");
            $('#createEditRoleBtnId').prop("value", "Update");
        } else {

            $('.idLabel').addClass("hidden")
            $('.idTextBox').addClass("hidden");
            $('.idTextBox').prop("disabled", true);
            $('.roleUsersLabel').removeClass("hidden");
            $('.UserRolesTextBox').removeClass("hidden");
            $('.roleNameLabel').removeClass("hidden");
            $('.roleNameTextBox').removeClass("hidden");
            $('#createEditRoleBtnId').prop("value", "Create");

        }
    }


    return {
        init: init
    }

})();
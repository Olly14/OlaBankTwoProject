var crudAccountManagementAndValidationModel = (function() {

    var editUI = function () {
        if (true) {
            $('#PersonalAccountNumberInputId').prop("disbaled", true);
            $('#OpeningBalanceInputId').prop("disbaled", true);
            $('#OpeningDateInputId').prop("disbaled", true);
        }



    }




    //var confirmDelete = function(message) {
    //    $('<div></div>').appendTo('body')
    //        .html('<div><h6>' + message + '?</h6></div>')
    //        .dialog({
    //            modal: true,
    //            title: 'Delete message',
    //            zIndex: 10000,
    //            autoOpen: true,
    //            width: 'auto',
    //            resizable: false,
    //            buttons: {
    //                Yes: function () {
    //                    // $(obj).removeAttr('onclick');                                
    //                    // $(obj).parents('.Parent').remove();

    //                    $('body').append('<h1>Confirm Dialog Result: <i>Yes</i></h1>');
    //                    var uri = '/Accounts/Delete?id=' + $('#UriKey');
    //                    window.location.replace(uri);

    //                },
    //                No: function () {
    //                    $('body').append('<h1>Confirm Dialog Result: <i>No</i></h1>');

    //                    $(this).dialog("close");
    //                }
    //            },
    //            close: function (event, ui) {
    //                $(this).remove();
    //            }
    //        });
    //};












    var init = function () {
        //$('#deleteBtnId').on("click", confirmDelete("Are you sure you want to delete this"));
        editUI();
        //confirmDelete();
    }


    return {
        init: init,
        editUI: editUI
        //confirmDelete: confirmDelete
}
})();
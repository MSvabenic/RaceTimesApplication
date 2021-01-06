$(document).ready(function () {
    var token = $('[name="__RequestVerificationToken"]').val();
    $("#dialog").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            Ok: function () {
                var deleteUrl = $("#dialog").data('deleteUrl');
                var approveUrl = $("#dialog").data('approveUrl');
                var postUrl = deleteUrl != undefined ? deleteUrl : approveUrl;

                $.post(postUrl, { __RequestVerificationToken: token})
                    .done(function () {
                        setTimeout(window.location.reload.bind(window.location), 300);
                    })
                    .fail(function () {
                        alert("Error has occured. Please try again!");
                    })
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        }
    });

    $(".deleteItem").click(function () {
        var deleteUrl = $(this);
        $("#dialog")
            .html("<p>Are you sure you want to remove the time?</p>")
            .data('deleteUrl', deleteUrl[0].href)
            .dialog("open");
        return false;
    });

    $(".approveItem").click(function () {
        var approveUrl = $(this);
        $("#dialog")
            .html("<p>Are you sure you want to approve the time?</p>")
            .data('approveUrl', approveUrl[0].href)
            .dialog("open");
        return false;
    });
});
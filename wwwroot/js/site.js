// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#dialog").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            Ok: function () {
                var deleteUrl = $("#dialog").data('deleteUrl');
                var approveUrl = $("#dialog").data('approveUrl');
                var postUrl = deleteUrl != undefined ? deleteUrl : approveUrl;

                $.post(postUrl)
                    .done(function () {
                        setTimeout(window.location.reload.bind(window.location), 300);
                    })
                    .fail(function () {
                        alert("error");
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
            .html("<p>Are you sure you want to reject the time?</p>")
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
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    $("#btn_AddToCart").on('click', function () {
        var Pro_id = $(this).data("id");
        var quantity = $('#Detail_Quantity').val();
        console.log(quantity)
        $.get('/Orders/AddProductToCart?Pro_id=' + Pro_id + '&Quantity=' + quantity, function (data) {
            if ($("#lblCartCount").val() != null) {
                $("#lblCartCount").text(parseInt($("#lblCartCount").text()) + parseInt(quantity));

            } else {
                $("#CountCart").append('<span class=\'badge badge-warning\' id=\'lblCartCount\' disabled=\"true\">' + parseInt(quantity) + ' <\/span >');
            }

        });
    });

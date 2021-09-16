// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#layout_search_input").on('keyup', function (e) {
    var keyword = ConvertKeyword($(this).val());
    console.log(keyword);
    $.get('/Products/Search?keyword=' + keyword, function (data) {
        console.log("Keyword: " + data);
        if (data == null) {
            $("#myUL").remove();
        } else {
            $("#myUL").remove();
            console.log(data);
            var html = '<ul id="myUL">';
            $.each(data, function (index, value) {
                console.log(value);
                html += '<li><a href="/Products/Detail/' + value.pro_Id + '">' + value.pro_Name + '</a></li>';
            });
            html += '</ul>';
            $(".layout_search_div").append(html);
        }
    });

});
function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}
function ConvertKeyword(string) {
    var stringArray = string.split(" ");
    var convertedstring = '';
    for (var i = 0; i < stringArray.length; i++) {
        convertedstring += capitalizeFirstLetter(stringArray[i])+' ';
    }
    return convertedstring;
}


function partialLoad(url, sendType, htmlElement, positionType, data)
{
    $.ajax({
        url: url,
        data: data,
        cache: false,
        async: false,
        type: sendType,
        success: function (html) {
            if(positionType == "append")
                $("#"+htmlElement).append(html);
            else if (positionType == "html")
                $("#" + htmlElement).html(html);
        }
    });
    return false;
}

function ajaxJSONAction(url, sendType, data, id, isAsync) {
    $.ajax({
        url: url,
        data: '{' + data + '}',
        async: isAsync,
        cache: false,
        contentType: "application/json; charset=utf-8",
        type: sendType,
        success: function (result) {
            if (result == 'true') {
                document.getElementById('' + id + '').checked = true;
            }
            else if (result == 'false') {
                document.getElementById('' + id + '').checked = false;
            }
            else {
                $("#" + id).val(result);
            }
            return true;
        }, error: function (xhr) {
            return false;
        }
    });
}
    
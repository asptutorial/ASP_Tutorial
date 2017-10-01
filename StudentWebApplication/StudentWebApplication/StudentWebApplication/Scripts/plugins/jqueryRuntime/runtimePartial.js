// laedt Views in partial Views
function partialLoad(url, sendType, htmlElement, positionType, data)
{
    console.log("Das kommt also an: " + url + " " + data);
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
                console.log(url + " " + data);
            }
    });
        return false;
}

// fuehrt Aktionen asynchron auf dem Controller aus
function ajaxAction(url, sendType, data) {
    console.log("Das kommt also an: " + url + " " + data);
    $.ajax({
        url: url,
        data: data,
        async: false,
        cache: false,
        contentType: "application/json; charset=utf-8",
        type: sendType,
        success: function (result) {
            return true;
        },
        error: function (xhr) {
            //console.log(xhr.responseText);
            return false;
        }
    });
}

function ajaxJSONAction(url, sendType, data, id, isAsync) {
    $.ajax({
        url: url,
        data: '{'+ data +'}',
        async: isAsync,
        cache: false,
        contentType: "application/json; charset=utf-8",
        type: sendType,
        success: function (result) {
            if (result == 'true') {
                document.getElementById(''+id+'').checked = true;
            }
            else if (result == 'false') {
                document.getElementById(''+id+'').checked = false;
            }
            else {
                $("#" + id).val(result);
            }
            return true;
        }, error: function (xhr) {
            return false;
    }
    });
    return false;
}


// fuehrt Aktionen asynchron auf dem Controller aus und laedt Patial View im Anschluss
function ajaxActionAndView(url, sendType, data, urlView, sendTypeView, htmlElementView, positionTypeView, dataView) {
    console.log("Das kommt also an: " + url + " " + data);
    $.ajax({
        url: url,
        data: data,
        cache: false,
        type: sendType,
        success: function () {
            partialLoad(urlView, sendTypeView, htmlElementView, positionTypeView, dataView);
        }
    });
    return false;
}


// verarbeitet das asynchrone Absenden von Forms
function ajaxSubmit(btnClicked) {
    var $form = $(btnClicked).parents('form');

    $.ajax({
        async: false,
        type: "POST",
        url: $form.attr('action'),
        data: $form.serialize(),
        error: function (xhr, status, error) {
            //do something about the error
        },
        success: function (response) {
            return response;
        }
    });
}

// verarbeitet das asynchrone Absenden von Forms
function ajaxSubmitWithFiles(btnClicked) {
    var $form = $(btnClicked).parents('form');
    var formData = new FormData($($form)[0]);

    $.ajax({
        async: false,
        type: "POST",
        url: $form.attr('action'),
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        error: function (xhr, status, error) {
            //do something about the error
        },
        success: function (response) {
            return response;
        }
    });
}

// verarbeitet das asynchrone Absenden von Forms
function ajaxSubmitJSONActionToOptionControl(btnClicked, id) {
    var $form = $(btnClicked).parents('form');

    $.ajax({
        async: false,
        type: "POST",
        url: $form.attr('action'),
        data: $form.serialize(),
        error: function (xhr, status, error) {
            //do something about the error
        },
        success: function (response) {
            $("#" + id + " " + "option[value=" + "'" + response + "'" + "]").prop("selected", true);
            return response;
        }
    });
}

// verarbeitet das asynchrone Absenden von Forms
function ajaxSendFormToAction(form, url) {
    var $form = $(form);

    $.ajax({
        type: "POST",
        url: url,
        data: $form.serialize(),
        error: function (xhr, status, error) {
            //do something about the error
        },
        success: function (response) {
        }
    });

    return false;// if it's a link to prevent post
}


// verarbeitet das asynchrone Absenden von Forms mit anschliessendem View load
function ajaxSubmitAndView(btnClicked, urlView, sendTypeView, htmlElementView, positionTypeView, dataView) {
    var $form = $(btnClicked).parents('form');

    $.ajax({
        type: "POST",
        url: $form.attr('action'),
        data: $form.serialize(),
        error: function (xhr, status, error) {
            //do something about the error
        },
        success: function (response) {
            partialLoad(urlView, sendTypeView, htmlElementView, positionTypeView, dataView);
        }
    });

    return false;// if it's a link to prevent post
}
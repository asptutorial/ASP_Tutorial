// @Author: Nadimo Staszak
// Mit diesem JavaScrip-Framework wird die Arbeit mit Partial-Classes via Ajax stark vereinfacht.


// laedt Views in partial Views
function partialLoad(url, sendType, htmlElement, positionType, data)
{
    console.log("Das kommt also an: " + url + " " + data);
    $.ajax({
            url: url,
            data: data,
            cache: false,
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

// bereinigt den Bereich einer partial View
function partialClear(htmlElement) {
    $("#" + htmlElement).html("");
    return false;
}


// fuehrt Aktionen asynchron auf dem Controller aus
function ajaxAction(url, sendType, data) {
    console.log("Das kommt also an: " + url + " " + data);
    $.ajax({
        url: url,
        data: data,
        cache: false,
        type: sendType,
        success: function () {

        }
    });
    return false;
}

function ajaxJSONAction(url, sendType, data) {
    $.ajax({
        type: sendType,
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (data) {
            return data;
        }, failure: function (errMsg) {
            console.debug(errMsg);
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
        type: "POST",
        url: $form.attr('action'),
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
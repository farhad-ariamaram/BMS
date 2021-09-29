
function clearDate(v, t) {
    $("#" + v).val("");
    $("#" + t).val("");
}

$('.remove-enter1').on("input", function () {
    var value = $(this).val();
    if (value.indexOf('\n') != -1) {
        $(this).val(value.replace(/\n/g, " <br> "));
    }
    var currentLength = $(this).val().length;
    $('.remove-enter11').children('span').html(currentLength + "/4000");
});

$('.remove-enter2').on("input", function () {
    var value = $(this).val();
    if (value.indexOf('\n') != -1) {
        $(this).val(value.replace(/\n/g, " <br> "));
    }
    var currentLength = $(this).val().length;
    $('.remove-enter12').children('span').html(currentLength + "/4000");
});

$("#openDes").on("click", function () {
    $(".completeDes").toggleClass("d-none");
    $(".hostDes").toggleClass("d-none");
});

$("#openWeb").on("click", function () {
    $(".completeWeb").toggleClass("d-none");
    $(".hostWeb").toggleClass("d-none");
});

function quitBox() {
    if (navigator.userAgent.indexOf("Firefox") != -1 || navigator.userAgent.indexOf("Chrome") != -1) {
        open(location, '_self').close();
        window.location.href = "about:blank";
        window.close();
    } else {
        window.opener = null;
        window.open("", "_self");
        window.close();
        open(location, '_self').close();
    }
}

function checkMonthDay(month, day) {
    var month2 = parseInt(month);
    switch (month2) {
        case 1:
            if (day < 1 || day > 31) {
                return false;
            }
            break;
        case 2:
            if (day < 1 || day > 31) {
                return false;
            }
            break;
        case 3:
            if (day < 1 || day > 31) {
                return false;
            }
            break;
        case 4:
            if (day < 1 || day > 31) {
                return false;
            }
            break;
        case 5:
            if (day < 1 || day > 31) {
                return false;
            }
            break;
        case 6:
            if (day < 1 || day > 31) {
                return false;
            }
            break;
        case 7:
            if (day < 1 || day > 30) {
                return false;
            }
            break;
        case 8:
            if (day < 1 || day > 30) {
                return false;
            }
            break;
        case 9:
            if (day < 1 || day > 30) {
                return false;
            }
            break;
        case 10:
            if (day < 1 || day > 30) {
                return false;
            }
            break;
        case 11:
            if (day < 1 || day > 30) {
                return false;
            }
            break;
        case 12:
            if (day < 1 || day > 29) {
                return false;
            }
            break;
        default:
            return false;
            break;
    }

    return true;
}
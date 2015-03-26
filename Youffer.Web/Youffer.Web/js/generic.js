/*Generic functions and global variables*/
var companyId = "";
function GetFormData(obj) {
    if (obj != undefined && obj != null) {
        var id = $(obj).data("wishlistid");
        if (id != undefined && id != null) {
            var Details = $(obj).parents("#Detail_" + id);
            if (Details.length == 0 || Details == undefined) {
                Details = $(obj).parents(".Detail_" + id);
            }
            var clientId = id;
            var wishListId = id;
            var companyId = $(Details).data('companyid');
            var firstName = $(Details).data('firstname');
            var facebookImageUrl = $(Details).data('imageurl');
            var interest = $(Details).data("interest");
            var age = $(Details).data("age");
            age = age != undefined ? age : 0;
            var model = {
                CompanyId: companyId, WishListId: wishListId, PurchasedInterest: interest, Client: { ClientId: clientId, FirstName: firstName, ImageUrl: facebookImageUrl, Age: age }
            }
            return model;
        }
    }
}


function showLoader(message) {
    console.log("show loader start");
    if (message != undefined && message != null) {
        popAlert("Loading", "<div id='divAjaxLoader' style='text-align: center;'><img src='/img/loader.gif' alt='Loading...' /><br>" + message + "</div>");
    }
    else {
        popAlert("Loading", "<div id='divAjaxLoader' style='text-align: center;'><img src='/img/loader.gif' alt='Loading...' /><br><div>");
    }

    $(".dlgpanel").css("position", "fixed");
    $(".Cs_close_icon").hide();
}


function hideLoader() {
    console.log("hide loader start");
    var loader = $("#popalert #popmessage #divAjaxLoader");
    if (loader.length > 0) {
        closePopAlert();
    }

    $(".Cs_close_icon").show();
}


//  Pop Alert and Confirm 
var overlayHTML = '<div class="none overlay"><img src="/img/loader.gif" /></div>';
(function ($) {
    $.fn.vAlign = function (winHeight) {
        return this.each(function () {
            var h = $(this).height(); //gives height of calling div i.e. 
            var wh = $(window).height(); // $(window).height() gives height of window i.e. viewable height of document 799
            if (winHeight > 0) {
                wh = winHeight;
            }
            var t = wh / 2 - h / 2;  // t=top 221.5

            if (t < 0) {
                t = 10;
            }
            $(this).css("top", t + "px");
            $(this).css("overflow", "auto");
            $(this).css("max-height", wh - 60);
            $(this).css("position", "absolute");
        });
    };
})(jQuery);

(function ($) {
    $.fn.hAlign = function () {
        return this.each(function () {
            var ow = $(this).outerWidth(); ///400
            var ml = (ow) / 2; ///200
            $(this).css("margin-left", "-" + ml + "px");
            $(this).css("left", "50%");
            $(this).css("position", "absolute");
        });
    };
})(jQuery);

$.fn.scrollTo = function (target, options, callback) {
    if (typeof options == 'function' && arguments.length == 2) { callback = options; options = target; }
    var settings = $.extend({
        scrollTarget: target,
        offsetTop: 50,
        duration: 500,
        easing: 'swing'
    }, options);
    return this.each(function () {
        var scrollPane = $(this);
        var scrollTarget = (typeof settings.scrollTarget == "number") ? settings.scrollTarget : $(settings.scrollTarget);
        var scrollY = (typeof scrollTarget == "number") ? scrollTarget : scrollTarget.offset().top + scrollPane.scrollTop() - parseInt(settings.offsetTop);
        scrollPane.animate({ scrollTop: scrollY }, parseInt(settings.duration), settings.easing, function () {
            if (typeof callback == 'function') { callback.call(this); }
        });
    });
}

var onPopAlertClose = undefined;
function popAlert(t, m, onCloseCallback) {
    $("body").css("overflow", "hidden");
    if (t == 'Event Deleted') {
        var ivlId = setInterval(function () { closePopAlert(); }, 3000);
        setTimeout(function () { clearInterval(ivlId); }, 5000);
    }
    onPopAlertClose = onCloseCallback;
    $("#poptitle").html(t);
    $("#popmessage").html(m);
    $("#popalert").vAlign().hAlign().fadeIn('fast');
    showDlgMask(true);
    $("#popalert").vAlign();
    $(".Cs_close_icon").show();
}

function closePopAlert() {
    showDlgMask(false);
    $("#popalert").hide();
    $("#poptitle").html("");
    $("#popmessage").html("");
    $('body').css('overflow', 'auto');
    if (fnOnDlgConfirmOk != undefined) {
        fnOnDlgConfirmOk();
        fnOnDlgConfirmOk = undefined;
    }

    if (onPopAlertClose != undefined) {
        try {
            eval(onPopAlertClose);
        } catch (e) {
        }
    }
}

var fnOnDlgConfirmOk;
var fnOnDlgConfirmYes;
var fnOnDlgConfirmNo = closeConfirmDlg;
function popConfirm(t, m, onReady) {
    $("#confirmTitle").html(t);
    $("#confirmMessage").html(m);
    $("#dlgconfirm .hideAlert,  #dlgconfirm .closeConfirmDlg, #dlgconfirm .okAlert").show();
    $("#dlgconfirm .okAlert").text("Yes").css("float", "right");
    $("#dlgconfirm .hideAlert").css('display', 'block');
    $('#privacyConfirm').css('display', 'none');
    $('.CnfrmPopBtns').css('margin-top', '0');
    showDlgMask(true);
    $("#dlgconfirm").vAlign().hAlign().fadeIn('fast');
    if (onReady != undefined && typeof (onReady) == 'function') {
        onReady();
    }
}

function closeConfirmDlg() {
    showDlgMask(false);
    $(".okAlert").text("Yes");
    $(".hideAlert").text("No");
    $("#dlgconfirm").hide();
}

function showDlgMask(v) {
    if (v) {
        $("#dlgblock").show();
    } else {
        if ($(".dlgpanel:visible").size() <= 1) {
            $("#dlgblock").hide();
        }
    }
    SetZindexForMask(v);
}

function SetZindexForMask(v) {
    var zIndex;
    if (v) {
        zIndex = $(".dlgpanel:visible:first").css("z-index");
    } else {
        zIndex = $(".dlgpanel:visible:last").css("z-index");
    }
    if (zIndex > 999999) {
        zIndex = 999999;
    }
    else if (zIndex == undefined) {
        zIndex = 8999;
    }
    else {
        zIndex = zIndex - 1;
    }

}
//  Pop Alert and Confirm end

// Device preview start
function closeDevicePreview() {
    showDlgMask(false);
    $("#previewAlert").hide();
    $("#previewTitle").html("");
    $("iframe#previewIframe").contents().find("body").html("");
}


function DevicePreview(t, m, onCloseCallback) {
    if (t == 'Event Deleted') {
        var ivlId = setInterval(function () { closePopAlert(); }, 3000);
        setTimeout(function () { clearInterval(ivlId); }, 5000);
    }
    $('iframe#previewIframe').contents().find('body').bind("click", "a", function (event) {
        event.preventDefault();
    });

    onPopAlertClose = onCloseCallback;
    $("#previewTitle").html(t);
    $("iframe#previewIframe").contents().find("body").html(m)
    $("#previewAlert").vAlign().hAlign().fadeIn('fast');
    showDlgMask(true);
    $("#previewAlert").vAlign();

}

// Device preview end

$(function () {
    setTimezoneCookie();
});

// set time zone cookie
function setTimezoneCookie() {

    var timezoneCookie = "timezoneoffset";

    if (!readCookie(timezoneCookie)) {
        createCookie(timezoneCookie, new Date().getTimezoneOffset());
    }
    else {

        var storedOffset = parseInt(readCookie(timezoneCookie));
        var currentOffset = new Date().getTimezoneOffset();

        if (storedOffset !== currentOffset) {
            createCookie(timezoneCookie, new Date().getTimezoneOffset());
            location.reload();
        }
    }
}


function createCookie(name, value, fixedName, days) {
    fixedName = fixedName == undefined ? "" : fixedName;
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    }
    name = fixedName + name;
    document.cookie = name + "=" + value + expires + ";path=/;";
}

function readCookie(name) {
    var nameEq = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEq) == 0) return c.substring(nameEq.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", "", -1);
}
// parse has code as query string for example : http://localhost:88/home#p1=v1&p2=v2
function ParseHasCodeAsQueryString() {
    if (window.location.hash.indexOf("#") === 0) {
        return parseQueryString(window.location.hash.substr(1));
    } else {
        return {};
    }
};


function parseQueryString(queryString) {
    var data = {},
        pairs, pair, separatorIndex, escapedKey, escapedValue, key, value;

    if (queryString === null) {
        return data;
    }

    pairs = queryString.split("&");

    for (var i = 0; i < pairs.length; i++) {
        pair = pairs[i];
        separatorIndex = pair.indexOf("=");

        if (separatorIndex === -1) {
            escapedKey = pair;
            escapedValue = null;
        } else {
            escapedKey = pair.substr(0, separatorIndex);
            escapedValue = pair.substr(separatorIndex + 1);
        }

        key = decodeURIComponent(escapedKey);
        value = decodeURIComponent(escapedValue);

        data[key] = value;
    }

    return data;
}


// get all country.
function GetAllCountry(callBackFunction) {
    $.InitAjaxPostMethod(apiHelper.allCountry, "", BindAllCountry, false);
}

//Bind All Country in ddlCountry dropdown.
function BindAllCountry(data) {
    var options = "";
    for (var i = 0; i < data.length; i++) {
        options += "<option value='" + data[i].CountryName + "'>" + data[i].CountryName + "</option>";
    }

    $("#ddlCountry").append(options);
}

function GetStates(countryName, controlId) {
    var data = { countryName: JSON.stringify(countryName) };
    $.InitAjaxMethod(apiHelper.getStates, data, BindStates.bind(null, controlId), false);
}

function BindStates(controlId, data) {
    if ($("#" + controlId).length > 0) {
        var options = "";
        var allStates = data.states;
        $("#" + controlId).html("");
        $("#" + controlId).append("<option value=''>All States</option>");
        for (var i = 0; i < allStates.length; i++) {
            options += "<option value='" + allStates[i].StateName + "'>" + allStates[i].StateName + "</option>";
        }
        $("#" + controlId).append(options);
    }
}
/* end generic functions*/

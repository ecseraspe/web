//var companyId = "";
////  Pop Alert and Confirm 
//var overlayHTML = '<div class="none overlay"><img src="/img/loader.gif" /></div>';
//(function ($) {
//    $.fn.vAlign = function (winHeight) {
//        return this.each(function () {
//            var h = $(this).height(); //gives height of calling div i.e. 
//            var wh = $(window).height(); // $(window).height() gives height of window i.e. viewable height of document 799
//            if (winHeight > 0) {
//                wh = winHeight;
//            }
//            var t = wh / 2 - h / 2;  // t=top 221.5

//            if (t < 0) {
//                t = 10;
//            }
//            $(this).css("top", t + "px");
//            $(this).css("overflow", "auto");
//            $(this).css("max-height", wh - 60);
//            $(this).css("position", "absolute");
//        });
//    };
//})(jQuery);

//(function ($) {
//    $.fn.hAlign = function () {
//        return this.each(function () {
//            var ow = $(this).outerWidth(); ///400
//            var ml = (ow) / 2; ///200
//            $(this).css("margin-left", "-" + ml + "px");
//            $(this).css("left", "50%");
//            $(this).css("position", "absolute");
//        });
//    };
//})(jQuery);

//$.fn.scrollTo = function (target, options, callback) {
//    if (typeof options == 'function' && arguments.length == 2) { callback = options; options = target; }
//    var settings = $.extend({
//        scrollTarget: target,
//        offsetTop: 50,
//        duration: 500,
//        easing: 'swing'
//    }, options);
//    return this.each(function () {
//        var scrollPane = $(this);
//        var scrollTarget = (typeof settings.scrollTarget == "number") ? settings.scrollTarget : $(settings.scrollTarget);
//        var scrollY = (typeof scrollTarget == "number") ? scrollTarget : scrollTarget.offset().top + scrollPane.scrollTop() - parseInt(settings.offsetTop);
//        scrollPane.animate({ scrollTop: scrollY }, parseInt(settings.duration), settings.easing, function () {
//            if (typeof callback == 'function') { callback.call(this); }
//        });
//    });
//}

//var onPopAlertClose = undefined;
//function popAlert(t, m, onCloseCallback) {
//    $("body").css("overflow", "hidden");
//    if (t == 'Event Deleted') {
//        var ivlId = setInterval(function () { closePopAlert(); }, 3000);
//        setTimeout(function () { clearInterval(ivlId); }, 5000);
//    }
//    onPopAlertClose = onCloseCallback;
//    $("#poptitle").html(t);
//    $("#popmessage").html(m);
//    $("#popalert").vAlign().hAlign().fadeIn('fast');
//    showDlgMask(true);
//    $("#popalert").vAlign();
//    $(".Cs_close_icon").show();
//}

//function closePopAlert() {
//    showDlgMask(false);
//    $("#popalert").hide();
//    $("#poptitle").html("");
//    $("#popmessage").html("");
//    $('body').css('overflow', 'auto');
//    if (fnOnDlgConfirmOk != undefined) {
//        fnOnDlgConfirmOk();
//        fnOnDlgConfirmOk = undefined;
//    }

//    if (onPopAlertClose != undefined) {
//        try {
//            eval(onPopAlertClose);
//        } catch (e) {
//        }
//    }
//}

//var fnOnDlgConfirmOk;
//var fnOnDlgConfirmYes;
//var fnOnDlgConfirmNo = closeConfirmDlg;
//function popConfirm(t, m, onReady) {
//    $("#confirmTitle").html(t);
//    $("#confirmMessage").html(m);
//    $("#dlgconfirm .hideAlert,  #dlgconfirm .closeConfirmDlg, #dlgconfirm .okAlert").show();
//    $("#dlgconfirm .okAlert").text("Yes").css("float", "right");
//    $("#dlgconfirm .hideAlert").css('display', 'block');
//    $('#privacyConfirm').css('display', 'none');
//    $('.CnfrmPopBtns').css('margin-top', '0');
//    showDlgMask(true);
//    $("#dlgconfirm").vAlign().hAlign().fadeIn('fast');
//    if (onReady != undefined && typeof (onReady) == 'function') {
//        onReady();
//    }
//}

//function closeConfirmDlg() {
//    showDlgMask(false);
//    $(".okAlert").text("Yes");
//    $(".hideAlert").text("No");
//    $("#dlgconfirm").hide();
//}

//function showDlgMask(v) {
//    if (v) {
//        $("#dlgblock").show();
//    } else {
//        if ($(".dlgpanel:visible").size() <= 1) {
//            $("#dlgblock").hide();
//        }
//    }
//    SetZindexForMask(v);
//}

//function SetZindexForMask(v) {
//    var zIndex;
//    if (v) {
//        zIndex = $(".dlgpanel:visible:first").css("z-index");
//    } else {
//        zIndex = $(".dlgpanel:visible:last").css("z-index");
//    }
//    if (zIndex > 999999) {
//        zIndex = 999999;
//    }
//    else if (zIndex == undefined) {
//        zIndex = 8999;
//    }
//    else {
//        zIndex = zIndex - 1;
//    }
//    $("#dlgblock").css("z-index", 9900);

//}
////  Pop Alert and Confirm end

//// Device preview start
//function closeDevicePreview() {
//    showDlgMask(false);
//    $("#previewAlert").hide();
//    $("#previewTitle").html("");
//    $("iframe#previewIframe").contents().find("body").html("");
//}


//function DevicePreview(t, m, onCloseCallback) {
//    if (t == 'Event Deleted') {
//        var ivlId = setInterval(function () { closePopAlert(); }, 3000);
//        setTimeout(function () { clearInterval(ivlId); }, 5000);
//    }
//    onPopAlertClose = onCloseCallback;
//    $("#previewTitle").html(t);
//    $("iframe#previewIframe").contents().find("body").html(m)
//    $("#previewAlert").vAlign().hAlign().fadeIn('fast');
//    showDlgMask(true);
//    $("#previewAlert").vAlign();
//}

//// Device preview end

//$(function () {
//    setTimezoneCookie();
//});

//// set time zone cookie
//function setTimezoneCookie() {

//    var timezoneCookie = "timezoneoffset";

//    if (!readCookie(timezoneCookie)) {
//        createCookie(timezoneCookie, new Date().getTimezoneOffset());
//    }
//    else {

//        var storedOffset = parseInt(readCookie(timezoneCookie));
//        var currentOffset = new Date().getTimezoneOffset();

//        if (storedOffset !== currentOffset) {
//            createCookie(timezoneCookie, new Date().getTimezoneOffset());
//            location.reload();
//        }
//    }
//}


//function createCookie(name, value, fixedName, days) {
//    fixedName = fixedName == undefined ? "" : fixedName;
//    var expires = "";
//    if (days) {
//        var date = new Date();
//        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
//        expires = "; expires=" + date.toGMTString();
//    }
//    name = fixedName + name;
//    document.cookie = name + "=" + value + expires + ";path=/;";
//}

//function readCookie(name) {
//    var nameEq = name + "=";
//    var ca = document.cookie.split(';');
//    for (var i = 0; i < ca.length; i++) {
//        var c = ca[i];
//        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
//        if (c.indexOf(nameEq) == 0) return c.substring(nameEq.length, c.length);
//    }
//    return null;
//}

//function eraseCookie(name) {
//    createCookie(name, "", "", -1);
//}
//// parse has code as query string for example : http://localhost:88/home#p1=v1&p2=v2
//function ParseHasCodeAsQueryString() {
//    if (window.location.hash.indexOf("#") === 0) {
//        return parseQueryString(window.location.hash.substr(1));
//    } else {
//        return {};
//    }
//};


//function parseQueryString(queryString) {
//    var data = {},
//        pairs, pair, separatorIndex, escapedKey, escapedValue, key, value;

//    if (queryString === null) {
//        return data;
//    }

//    pairs = queryString.split("&");

//    for (var i = 0; i < pairs.length; i++) {
//        pair = pairs[i];
//        separatorIndex = pair.indexOf("=");

//        if (separatorIndex === -1) {
//            escapedKey = pair;
//            escapedValue = null;
//        } else {
//            escapedKey = pair.substr(0, separatorIndex);
//            escapedValue = pair.substr(separatorIndex + 1);
//        }

//        key = decodeURIComponent(escapedKey);
//        value = decodeURIComponent(escapedValue);

//        data[key] = value;
//    }

//    return data;
//}



// public variables 
var allBusinessTypesAutoComplete = [];

// show client profile popup end

function youfferblackscreen(condition) {
    if ($("#divBlockYoufferScreen")) { if (condition) { $("#divBlockYoufferScreen").show(); } else { $("#divBlockYoufferScreen").hide(); } }
}

//Get all business types 
function GetAllbusinessType(controlId) {
    $.ajax({
        url: '/Common/GetAllBusinessTypes',
        type: 'POST'
    }).done(function (data) {
        $.map(data, function (val, i) { allBusinessTypesAutoComplete.push(val.BusinessType); })
        if ($("." + controlId).length > 0) {
            var options = "";
            for (var i = 0; i < data.length; i++) {
                options += "<option value='" + data[i].BusinessType + "'>" + data[i].BusinessType + "</option>";
            }
            $("." + controlId).append(options);
            $("." + controlId).trigger("chosen:updated");
        }
    });
}

// get all subinterest related to given main interest
function GetAllSubInterest(mainInterest, callBackFunction) {
    $.ajax({
        url: '/Common/GetAllSubInterest',
        type: 'POST',
        data: { interest: mainInterest }
    }).done(function (data) {
        if (data.AuthError) {
            handleAjaxError(data);
            return;
        }
        callBackFunction(data);
    });
}

// Autocomplete of business types 
function bindAllbusinessType(controlId) {
    if ($("#" + controlId).length > 0) {
        GetAllbusinessType(controlId);
        $("#" + controlId).autocomplete({
            autoFocus: true,
            selectFirst: true,
            source: allBusinessTypesAutoComplete
        });
    }
    else if ($("." + controlId).length > 0) {
        GetAllbusinessType(controlId);
        //$("." + controlId).autocomplete({
        //    autoFocus: true,
        //    selectFirst: true,
        //    source: allBusinessTypesAutoComplete
        //});
    }
}


// fill age in drop down list
function GetAge(commaSepratedControlIds) {
    var allCtrls = commaSepratedControlIds.split(",");
    if (allCtrls.length > 0) {
        var data = [];
        for (var i = 18; i < 101; i++) {
            data.push(i);
        }
        if (data.length > 0) {
            $.map(allCtrls, function (ctrl, index) {
                $.map(data, function (val, i) { $("#" + ctrl).append(new Option(val, val)); });
            });
        }
    }
}
var interest = "";
function buyclient(wishListId) {
    if (wishListId != undefined && wishListId.length > 0 && interest && interest.length > 0) {
        $.ajax({
            url: '/Client/BuyClient',
            type: 'POST',
            data: { wishListId: wishListId, interest: interest }
        }).done(function (res) {
            if (res.AuthError) {
                handleAjaxError(res);
                return;
            }
            if (res) {
                closeConfirmDlg();
            }
            else {
                // ?????
            }
        });
    }
}

// show payment confirmation popup on row click of payment client search page.
function ShowPaymentConfirmation(ctrl) {
    // get payment details
    var wishListId = $(ctrl).data("id");
    var image = $('#divProfileWithReview #clientImage').attr("src");
    var name = $('#divProfileWithReview #clientName').html().trim();
    var age = $('#divProfileWithReview #clientAge').html().trim();
    var ranking = $('#divProfileWithReview #clientRanking').html().trim();

    // place data on confirmation popup
    $("#divPaymentConfirmation #payConfirmWishListId").val(wishListId);
    $("#divPaymentConfirmation #payConfirmImage").attr("src", image);
    $("#divPaymentConfirmation #payConfirmName").html(name);
    $("#divPaymentConfirmation #payConfirmAge").html(age);
    $("#divPaymentConfirmation #payConfirmRanking").html(ranking);


    $("#divPaymentConfirmation").show();
    popConfirm("Payment Confirmation", $("#divPaymentConfirmation").html());
    closePopAlert();
    fnOnDlgConfirmYes = function () {
        buyclient(wishListId);
    }
}

// show purchase confirmation popup
function ShowPurchaseConfirmationPopup(clientId, clientInterest) {
    if (clientId != undefined) {
        interest = clientInterest;
        $.ajax({
            url: '/Client/PurchaseConfirmationDetail',
            data: { clientId: clientId },
            type: 'POST'
        }).done(function (data) {
            if (data.AuthError) {
                handleAjaxError(data);
                return;
            }
            popConfirm("Payment Confirmation", data);
            fnOnDlgConfirmYes = function () {
                if ($("#payConfirmWishListId").val() != undefined) {
                    buyclient($("#payConfirmWishListId").val());
                }
            }
        });
    }
}

// get client profile and review list for searchClient page row click.
////function GetclientProfileAndReview(wishListId, clientInterest, isPurchased) {
////    if (wishListId && clientInterest != undefined) {
////        if (clientInterest.length > 0) {
////            interest = clientInterest;
////            isPurchased = (isPurchased != undefined && isPurchased != null) ? isPurchased : false;
////            $.ajax({
////                url: '/Client/GetClientProfileAndReview',
////                type: 'POST',
////                beforeSend: function () { showLoader(); },
////                complete: function () { hideLoader(); },
////                data: { wishListId: wishListId, interest: interest, isPurchased: isPurchased },
////            }).done(function (data) {
////                if (data.AuthError) {
////                    handleAjaxError(data);
////                    return;
////                }
////                closePopAlert();
////                popAlert('Client Profile', data);
////                $(".Cs_close_icon").show();
////            });
////        }
////    }
////}

//// show Note popup
//function ShowNoteHistory(obj) {
//    var heading = "Note";
//    var url = '/Lead/Note';
//    GetWishListData(heading, url, obj);
//}
//// show Note popup end

// show Note Form popup
function ShowNoteForm(obj) {
    var heading = "New Note";
    var url = '/Lead/NewNote';
    var wishListId = $(obj).data("wishlistid");
    var companyId = $(obj).data("companyid");
    $.ajax({
        url: url,
        data: { wishListId: wishListId, companyId: companyId },
        type: 'Get',
    }).done(function (data) {
        if (data.AuthError) {
            handleAjaxError(data);
            return;
        }
        popAlert(heading, data);
    });
}
// show Note Form popup end

// show review form popup and Message Form popup
////function ShowReviewForm(obj) {
////    var heading = "Review Client";
////    var url = "/Lead/ReviewClient";
////    var model = GetFormData(obj);
////    GetForm(model, url, heading);
////}

// submit review form with rating 5 by clicking on "Mark as purchased " on ReviewClient page.
//function MarkAsPurchased(obj) {
//    var id = $(obj).data("wishlistid");
//    if (id != undefined && id != null) {
//        var wishList = GetFormData(obj);
//        var url = "/Lead/MarkAsPurchased";
//        if (wishList != null && wishList != undefined) {
//            if (wishList.WishListId.length > 0 && wishList.PurchasedInterest != undefined) {
//                $.ajax({
//                    url: url,
//                    data: { model: JSON.stringify(wishList) },
//                    type: 'Get'
//                }).done(function (data) {
//                    if (data.AuthError) {
//                        handleAjaxError(data);
//                        return;
//                    }
//                    else if (data.error) {
//                        popConfirm("", data.error);
//                        console.log(data.error);
//                        return;
//                    }
//                    else if (data.result) {

//                    }
//                    popConfirm("", data);
//                    $(".CnfrmPopBtns").hide();
//                });
//            }
//        }
//    }
//}


////function GetFormData(obj) {
////    if (obj != undefined && obj != null) {
////        var id = $(obj).data("wishlistid");
////        if (id != undefined && id != null) {
////            var Details = $(obj).parents("#Detail_" + id);
////            if (Details.length == 0 || Details == undefined) {
////                Details = $(obj).parents(".Detail_" + id);
////            }
////            var clientId = id;
////            var wishListId = id;
////            var companyId = $(Details).data('companyid');
////            var firstName = $(Details).data('firstname');
////            var facebookImageUrl = $(Details).data('imageurl');
////            var interest = $(Details).data("interest");
////            var age = $(Details).data("age");
////            age = age != undefined ? age : 0;
////            var model = { CompanyId: companyId, WishListId: wishListId, PurchasedInterest: interest, Client: { ClientId: clientId, FirstName: firstName, ImageUrl: facebookImageUrl, Age: age } }
////            return model;
////        }
////    }
////}

// Note this function has removed if your functionality breaks due to this then use $.InitAjaxMethod same as in businessLogic.js
//function GetForm(model, url, heading) {
//    $.ajax({
//        url: url,
//        data: { model: JSON.stringify(model) },
//        type: 'Get',
//        beforeSend: function () { showLoader(); },
//        complete: function () { hideLoader(); },
//    }).done(function (data) {
//        if (data.AuthError) {
//            handleAjaxError(data);
//            return;
//        }
//        else if (data.error) {
//            console.log(data.error);
//            return;
//        }
//        popAlert("", data);
//    });
//}
// show review form popup and Message Form popup end

// show client Note History and client Message history
////function GetData(wishListId, url, heading) {
////    $.ajax({
////        url: url,
////        data: { wishListId: wishListId },
////        type: 'Get',
////        beforeSend: function () { showLoader(); },
////        complete: function () { hideLoader(); },
////    }).done(function (data) {
////        if (data.AuthError) {
////            handleAjaxError(data);
////            return;
////        }
////        else if (data.error) {
////            console.log(data.error);
////            return;
////        }
////        popAlert(heading, data);
////    });
////}

// Get data to delete client
////function DeleteClient(obj) {
////    if (obj != undefined && obj != null) {
////        var id = $(obj).data("wishlistid");
////        if (id != undefined && id != null) {
////            var Details = $(obj).parents("#Detail_" + id);
////            if (Details.length == 0 || Details == undefined) {
////                Details = $(obj).parents(".Detail_" + id);
////            }
////            var wishListId = id;
////            var interest = $(Details).data("interest");
////            if (wishListId.length > 0 && interest != undefined) {
////                popConfirm("Delete Client", " Are you sure you want to delete this client?");
////                $(".closeConfirmDlg").css("display", "none");
////                fnOnDlgConfirmYes = function () {
////                    ConfirmDelete(wishListId, interest);
////                }
////            }
////        }
////    }
////}
// Get data to delete client end

// Confirm to delete client
////function ConfirmDelete(wishListId, interest) {
////    closeConfirmDlg();
////    var heading = "Client Deleted";
////    var url = '/Lead/DeleteClient';
////    ConfirmedDeleteClient(wishListId, interest, url, heading);
////}
// Confirm to delete client end

// Delete client
////function ConfirmedDeleteClient(wishListId, interest, url, heading) {
////    $.ajax({
////        url: url,
////        data: { wishListId: wishListId, interest: interest },
////        type: 'Get',
////        beforeSend: function () { showLoader(); },
////        complete: function () { hideLoader(); },
////    }).done(function (res) {
////        if (res.AuthError) {
////            handleAjaxError(res);
////            return;
////        }
////        else if (res.error) {
////            popAlert("Error", "<div style='text-align: center;'>Some error occured. Please try again.</div>");
////            return;
////        }
////        if (res.result) {
////            $(".Detail_" + wishListId).hide();
////            $("#popmessage").html("<div style='text-align: center;'>Client Deleted Successfully</div>");
////            // popAlert("Client Deleted", "<div style='text-align: center;'>Client Deleted Successfully</div>");
////            $(".Cs_close_icon").hide();
////            $('#popalert').fadeOut("20000", function () {
////                closePopAlert();
////            });
////        }
////        else {
////            $("#popmessage").html("<div style='text-align: center;'>Some error occured. Please try again.</div>");
////            // popAlert("Error", "<div style='text-align: center;'>Some error occured. Please try again.</div>");
////        }
////    });
////}
// Delete client end

// connect with facebook
function ConnectWithFacebook() {
    var url = "http://212.117.213.11:88/api/Account/ExternalLogin?role=3&provider=Facebook&response_type=token&client_id=compWeb&redirect_uri=http://localhost:49458/Account/ExternalLogin"
    //var url = "http://192.168.103.77:88/api/Account/ExternalLogin?role=3&provider=Facebook&response_type=token&client_id=compWeb&redirect_uri=http://localhost49458/Account/ExternalLogin"
    popupCenter(url, "Authenticate Account", 900, 500);
    //window.open(url, "Authenticate Account", "location=0,status=0,width=600,height=750");
}

function popupCenter(url, title, w, h) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2);
    return window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}

//function allMessageRowClick(obj) {
//    if (!($(obj).hasClass("deleteMessage"))) {
//        ShowMessageHistory($(obj).parent("tr"));
//    }
//}

// delete Message
function DeleteMessage(messageId) {
    if (messageId > 0 && messageId != undefined) {
        $.ajax({
            url: '/Client/DeleteMessage',
            data: {
                messageId: messageId
            },
            type: 'POST',
        }).done(function (res) {
            if (res.AuthError) {
                handleAjaxError(res);
                return;
            }
            if (res == true) {
                $("#tblAllMessages tr[data-id=" + messageId + "]").remove();
                popAlert("Confirmation", "Message deleted successfully.");
                $(".Cs_close_icon").hide();
                $('#popalert').delay(3000).fadeOut("slow", function () {
                    closePopAlert();
                });
            } else {
                popAlert("Confirmation", "Some error occured. Please try again.");
            }
        });
    }
}

//// Get more messages on scroll down of allMessage page. and sorting.
//var moreAllMessageLastPageId = 2;
//var moreAllMessageRequestIsBusy = false;
//var moreAllMessageSortBy = 2; // table header index.
//var moreAllMessageSortDirection = 2; // 1 for Asc, 2 for Desc
//var moreAllMessageRefill = false;
//function GetMoreAllMessage(sortByColumn, sortDirection, callBackFunction, isRefill) {
//    var sortByColumnName = "";
//    var sortDirectionType = "desc";
//    if (!moreAllMessageRequestIsBusy) {
//        moreAllMessageRequestIsBusy = true;
//        moreAllMessageSortBy = sortByColumn < 0 ? moreAllMessageSortBy : sortByColumn;
//        // set sortByColumnName Note : There is only sorting on CreatedOn and Name and SortByColumnName="" for CreatedOn
//        sortByColumnName = sortByColumn == 0 ? "Name" : "";
//        moreAllMessageSortDirection = sortDirection < 0 ? moreAllMessageSortDirection : sortDirection;
//        // set sortDirectionType.
//        sortDirectionType = sortDirection == 1 ? "asc" : "desc";
//        moreAllMessageRefill = (isRefill != undefined && isRefill) ? isRefill : false;
//        moreAllMessageLastPageId = (isRefill != undefined && isRefill) ? 1 : moreAllMessageLastPageId;
//        var records = 100;
//        $.ajax({
//            url: '/Client/AllMessages',
//            type: 'GET',
//            data: { lastPageId: moreAllMessageLastPageId, numberOfRecords: records, sortBy: sortByColumnName, direction: sortDirectionType, }
//        }).done(function (data) {
//            if (data.AuthError) {
//                handleAjaxError(data);
//                return;
//            }
//            if (data != 0) {
//                moreAllMessageLastPageId++;
//            }

//            moreAllMessageRequestIsBusy = false;
//            callBackFunction(data);
//        });
//    }
//}

function BindAllMessage(data) {
    moreAllMessageRequestIsBusy = false;
    if (data != 0) {
        if (moreAllMessageRefill) {
            moreAllMessageLastPageId = 2;
            $("#tblAllMessages tbody").html(data);
        }
        else {
            moreAllMessageLastPageId++;
            $("#tblAllMessages tbody").append(data);
        }
    }
}

function AllMessageRemoveThread(threadId) {
    var row = $("#tblAllMessages tr[data-id='" + threadId + "']");
    if (row.length > 0) {
        row.remove();
    }
}

// show message conversation window.
////function ShowMessageHistory(obj) {
////    var heading = "Message History";
////    var url = '/Lead/MessageHistory';
////    GetWishListData(heading, url, obj);
////}

////function GetWishListData(heading, url, obj) {
////    var wishListId = $(obj).data("wishlistid");
////    $.ajax({
////        url: url,
////        data: { wishListId: wishListId },
////        type: 'Get',
////        beforeSend: function () { showLoader(); }
////    }).done(function (data) {
////        hideLoader();
////        if (data.AuthError) {
////            handleAjaxError(data);
////            return;
////        }
////        popAlert(heading, data);
////    });
////}

//// show new message window.
//function ShowNewMessageWindow(obj, IsgetDataFromHiddenFields) {
//    var model = {};
//    if (IsgetDataFromHiddenFields == 1) {
//        model = GetNewMessageDataFromHiddenFields();
//    }
//    else {
//        model = GetFormData(obj);
//    }

//    NewMessageWindow(model);
//}

// Send ajax call for new message window.
//function NewMessageWindow(model) {
//    var heading = "Quick Message";
//    var url = '/Lead/Message';
//    GetForm(model, url, heading);
//}



//function GetNewMessageDataFromHiddenFields(wishListId) {
//    var clientId = $("#divNewMessageHiddenData #hClientId").val();
//    if (wishListId == undefined) {
//        wishListId = $("#divNewMessageHiddenData #hWishListId").val();
//    }
//    var firstName = $("#divNewMessageHiddenData #hFirstName").val();
//    var facebookImageUrl = $("#divNewMessageHiddenData #hImage").val();
//    var model = { WishListId: wishListId, Client: { ClientId: clientId, FirstName: firstName, ImageUrl: facebookImageUrl } }
//    return model;
//}

// Show bulk Message Window
////function ShowBulkMessagePopUp() {
////    var model = { WishListId: 0, Client: { ClientId: 0, FirstName: '', FacebookImageUrl: '' }, Message: { IsBulkMessage: true } }
////    var url = '/Lead/Message';
////    GetForm(model, url, "Send Mass Email");
////}

//// get message conversation on scroll down
//var moreMessageLastPageId = 2;
//var moreMessageRequestIsBusy = false;
//function GetMoreMessageConversation(wishListId, callBackFunction) {
//    var NumberOfRecords = 100;
//    if (!moreMessageRequestIsBusy) {
//        moreMessageRequestIsBusy = true;
//        $.ajax({
//            url: '/Lead/GetMoreMessageHistory',
//            type: 'POST',
//            data: {
//                wishListId: wishListId, lastPageId: moreMessageLastPageId, NumberOfRecords: NumberOfRecords
//            }
//        }).done(function (data) {
//            if (data.AuthError) {
//                handleAjaxError(data);
//                return;
//            }
//            if (data.length > 0) {
//                moreMessageLastPageId++;
//            }
//            moreMessageRequestIsBusy = false;
//            callBackFunction(data);
//        });
//    }
//}

//// Bind message conversation data messageHistory popup.
//function BindMessageConversationData(data) {
//    if (data != 0) {
//        $("#divMessageHistory").find(".clearfix").before(data);
//        updateScroll('divMessageHistory');
//    }
//}

//function BindOldMessages(data) {
//    if (data != 0) {
//        $("#divMessageHistory").prepend(data);
//    }
//}


// clear instant message box and append new message in history.
function ClearInstantMessageBox(data) {
    if (data.AuthError) {
        handleAjaxError(data);
        return;
    }

    if (data != undefined && data != 0) {
        $("#divMessageHistory").find(".clearfix").before(data);
        updateScroll("divMessageHistory");
        $("#txtInstantMessage").val("");
    }
}

// read html file and return it's content to callbackfunction on client side.
function ReadHtmlFileOnBrowser(opt_startByte, opt_stopByte, callBackFunction) {
    if (window.File && window.FileReader && window.FileList && window.Blob) {
        var files = document.getElementById('fileHtml').files;
        if (!files.length) {
            //alert('Please select a file!');
            return;
        }
        if (!/.*\.(htm)|(html)$/.test(files[0].name.toLowerCase())) {
            var errormsg = "Please upload only html files. Supported file formats are .htm and .html."
            callBackFunction(null, null, errormsg);
            return;
        }

        var file = files[0];
        var fileName = files[0].name;
        var start = parseInt(opt_startByte) || 0;
        //var stop = parseInt(opt_stopByte) || file.size - 1;
        var stop = file.size - 1;

        var reader = new FileReader();

        // If we use onloadend, we need to check the readyState.
        reader.onloadend = function (evt) {
            if (evt.target.readyState == FileReader.DONE) { // DONE == 2
                var chars = new Uint8Array(evt.target.result);
                var CHUNK_SIZE = 0x8000;
                var index = 0;
                var length = chars.length;
                var result = '';
                var slice;
                while (index < length) {
                    slice = chars.subarray(index, Math.min(index + CHUNK_SIZE, length));
                    result += String.fromCharCode.apply(null, slice);
                    index += CHUNK_SIZE;
                }
                callBackFunction(result, fileName);
            }
        };

        var blob = file.slice(start, stop + 1);
        reader.readAsArrayBuffer(blob);
    }
    else {
        alert('Your browser does not support html 5');
    }
}

// send fake call report.
////function FakeCallReport(wishListId, rowId) {
////    popConfirm("Fake Call Report", "<div style='text-align: center'>Are you sure you want to report this client?</div>");
////    $(".closeConfirmDlg").css("display", "none");
////    fnOnDlgConfirmYes = function () {
////        closeConfirmDlg();
////        //popAlert("Loading", "<div style='text-align: center;'><img src='/img/loader.gif' alt='Loading...' /><br>Reporting Fake call...</div>");
////        $(".dlgpanel").css("position", "fixed");
////        $(".Cs_close_icon").hide();
////        $.ajax({
////            url: '/Client/ReportUser',
////            type: 'POST',
////            beforeSend: function () { showLoader("Reporting Fake call...") },
////            complete: hideLoader(),
////            data: {
////                wishListId: wishListId
////            }
////        }).done(function (data) {
////            if (data.AuthError) {
////                handleAjaxError(data);
////                return;
////            }
////            else if (data.error) {
////                //alert("Fake call did not submit !");
////                popAlert("", "<div style='text-align: center'>Some error occured. Please try again</div>");
////                return;
////            }
////            if (data != undefined && data != null) {
////                if (data == true) {
////                    var row = $("." + rowId);  // reported on bug 188
////                    if (row != undefined && row != null) {
////                        row.remove();
////                    }
////                    popAlert("Fake Call report submitted successfully");
////                    //$("#popmessage").html("<div style='text-align: center'>Fake Call report submitted successfully</div>");
////                    //$(".Cs_close_icon").hide();
////                    $('#popalert').fadeOut("20000", function () {
////                        closePopAlert();
////                    });
////                }
////                else {
////                    $("#popmessage").html("<div style='text-align: center'>Some error occured. Please try again</div>");
////                }
////            }

////            $(".Cs_close_icon").show();
////        });
////    }
////}

// get more data for Review Client on sorting and scrolling 
var moreReviewClientLastPageId = 2;
var moreReviewClientRequestIsBusy = false;
var moreReviewClientSortBy = 0; // table header index.
var moreReviewClientSortDirection = 1; // 1 for Asc, 2 for Desc
var moreReviewClientRefill = false;
function GetMoreReviewClient(sortByColumn, sortDirection, callBackFunction, isRefill) {
    if (!moreReviewClientRequestIsBusy) {
        moreReviewClientRequestIsBusy = true;
        moreReviewClientSortBy = sortByColumn < 0 ? moreReviewClientSortBy : sortByColumn;
        moreReviewClientSortDirection = sortDirection < 0 ? moreReviewClientSortDirection : sortDirection;
        moreReviewClientRefill = (isRefill != undefined && isRefill) ? isRefill : false;
        moreReviewClientLastPageId = (isRefill != undefined && isRefill) ? 1 : moreReviewClientLastPageId;
        var records = 100;
        $.ajax({
            url: '/Client/ReviewClient',
            type: 'GET',
            data: {
                lastPageId: moreReviewClientLastPageId, numberOfRecords: records, sortBy: moreReviewClientSortBy, direction: moreReviewClientSortDirection
            },
        }).done(function (data) {
            if (data.AuthError) {
                handleAjaxError(data);
                return;
            }
            moreReviewClientRequestIsBusy = false;
            moreReviewClientLastPageId++;
            callBackFunction(data);
        });
    }
}



var moreMyClientLastPageId = 2;
var moreMyClientRequestIsBusy = false;
var moreMyClientSortBy = 0; // table header index.
var moreMyClientSortDirection = 1; // 1 for Asc, 2 for Desc
var moreMyClientRefill = false;
var moreMyClientSearchBy = "";
// get more clients on  scroll down and sorting.
function GetMoreMyClient(sortByColumn, sortDirection, callBackFunction, isRefill, IsPagindWithSearch) {
    if (!moreMyClientRequestIsBusy) {
        moreMyClientRequestIsBusy = true;
        if (!IsPagindWithSearch) {
            moreMyClientSortBy = sortByColumn < 0 ? moreMyClientSortBy : sortByColumn;
            moreMyClientSortDirection = sortDirection < 0 ? moreMyClientSortDirection : sortDirection;
            moreMyClientRefill = (isRefill != undefined && isRefill) ? isRefill : false;
            moreMyClientLastPageId = (isRefill != undefined && isRefill) ? 1 : moreMyClientLastPageId;
            var records = 100;
            $.ajax({
                url: '/Lead/MyClients',
                type: 'GET',
                data: {
                    lastPageId: moreMyClientLastPageId, numberOfRecords: records, sortBy: moreMyClientSortBy, direction: moreMyClientSortDirection
                }
            }).done(function (data) {
                if (data.AuthError) {
                    handleAjaxError(data);
                    return;
                }
                moreMyClientRequestIsBusy = false;
                moreMyClientLastPageId++;
                callBackFunction(data);
            });
        }
        else {
            GetMoreClientForMyClientSearch(sortByColumn, sortDirection, callBackFunction, isRefill, 100);
        }
    }
}

function GetMoreClientForMyClientSearch(sortByColumn, sortDirection, callBackFunction, isRefill, records) {
    $.ajax({
        url: '/Lead/SearchClientForMyclientPage',
        type: 'POST',
        data: {
            lastPageId: moreMyClientLastPageId, numberOfRecords: records, sortBy: moreMyClientSortBy, direction: moreMyClientSortDirection, searchBy: moreMyClientSearchBy
        }
    }).done(function (res) {
        if (res.AuthError) {
            handleAjaxError(res);
            return;
        }
        moreMyClientRequestIsBusy = false;
        if (res.responseText.length > 0) {
            moreMyClientLastPageId++;
            callBackFunction(res.responseText);
        }
    });
}



var moreNoteHistoryLastPageId = 2;
var moreNoteHistoryRequestIsBusy = false;
var moreNoteHistorySortBy = 0; // table header index.
var moreNoteHistorySortDirection = 1; // 1 for Asc, 2 for Desc
var moreNoteHistoryRefill = false;
function GetMoreNoteHistory(wishListId, sortByColumn, sortDirection, callBackFunction, isRefill) {
    if (!moreNoteHistoryRequestIsBusy) {
        moreNoteHistoryRequestIsBusy = true;
        moreNoteHistorySortBy = sortByColumn < 0 ? moreNoteHistorySortBy : sortByColumn;
        moreNoteHistorySortDirection = sortDirection < 0 ? moreNoteHistorySortDirection : sortDirection;
        moreNoteHistoryRefill = (isRefill != undefined && isRefill) ? isRefill : false;
        moreNoteHistoryLastPageId = (isRefill != undefined && isRefill) ? 1 : moreNoteHistoryLastPageId;
        var records = 100;
        $.ajax({
            url: '/Lead/Note',
            type: 'GET',
            data: {
                wishListId: wishListId, lastPageId: moreNoteHistoryLastPageId, numberOfRecords: records, sortBy: moreNoteHistorySortBy, direction: moreNoteHistorySortDirection, isGetMoreData: true
            }
        }).done(function (data) {
            if (data.AuthError) {
                handleAjaxError(data);
                return;
            }
            moreNoteHistoryRequestIsBusy = false;
            moreNoteHistoryLastPageId++;
            callBackFunction(data);
        });
    }
}

// show complete Registration popup.
function ShowCompleteRegistration() {
    $.ajax({
        url: '/Client/CompleteRegister/',
        type: 'GET'
    }).done(function (data) {
        if (data.AuthError) {
            handleAjaxError(data);
            return;
        }
        popAlert("Complete registration detail", data);
    });
}


////var moreHomePageClientLastPageId = 2; // Assume 
////var moreHomePageClientRequestIsBusy = false;
////var moreHomePageClientSortBy = 0; // table header index.
////var moreHomePageClientSortDirection = 1; // 1 for Asc, 2 for Desc
////var moreHomePageClientRefill = false;
////function GetMoreHomePageClient(searchText, isRefill, callBackFunction) {
////    if (!moreHomePageClientRequestIsBusy) {
////        moreHomePageClientRequestIsBusy = true;
////        moreHomePageClientRefill = (isRefill != undefined && isRefill) ? isRefill : false;
////        moreHomePageClientLastPageId = (isRefill != undefined && isRefill) ? 1 : moreHomePageClientLastPageId;
////        var records = 8;
////        $.ajax({
////            url: '/Home/SearchHomePageClients',
////            type: 'GET',
////            onBegin: showLoader(),
////            data: {
////                searchText: searchText, lastPageId: moreHomePageClientLastPageId, numberOfRecords: records
////            }
////        }).done(function (data) {
////            closePopAlert();
////            $(".Cs_close_icon").show();
////            moreHomePageClientRequestIsBusy = false;
////            if (data != undefined && data != null && data.trim().length > 0) {
////                moreHomePageClientLastPageId++;
////                $("#divHomePageclient").append(data);
////            }
////            else {
////                $("#divLoadMoreClient").hide();
////                var view = "<div class='row'></div><div class='row'><h4 class='section-heading text-center'>No more results to show</h4></div>";
////                $("#divHomePageclient").append(view);
////            }
////            // callBackFunction(data);
////        });
////    }
////}

////GetDashboardClient
//var moreDashboardClientLastPageId = 2; // Assume 
//var moreDashboardClientRequestIsBusy = false;
//function GetMoreDashboardClient(records, callBackFunction) {
//    if (!moreDashboardClientRequestIsBusy) {
//        moreDashboardClientRequestIsBusy = true;
//        $.ajax({
//            url: '/Admin/GetDashboardClient',
//            type: 'GET',
//            beforeSend: showLoader(),
//            data: {
//                lastPageId: moreDashboardClientLastPageId, numberOfRecords: records
//            }
//        }).done(function (data) {
//            hideLoader();
//            if (data.AuthError) {
//                handleAjaxError(data);
//                return;
//            }
//            else if (data.error) {
//                console.log(err.responseText);
//                return;
//            }
//            moreDashboardClientRequestIsBusy = false;
//            if (data != undefined && data != null && data != 0) {
//                moreDashboardClientLastPageId++;
//            }

//            callBackFunction(data);
//        });
//    }
//}

////function showLoader(message) {
////    console.log("show loader start");
////    if (message != undefined && message != null) {
////        popAlert("Loading", "<div id='divAjaxLoader' style='text-align: center;'><img src='/img/loader.gif' alt='Loading...' /><br>" + message + "</div>");
////    }
////    else {
////        popAlert("Loading", "<div id='divAjaxLoader' style='text-align: center;'><img src='/img/loader.gif' alt='Loading...' /><br> Loading...<div>");
////    }

////    $(".dlgpanel").css("position", "fixed");
////    $(".Cs_close_icon").hide();
////}


////function hideLoader() {
////    console.log("hide loader start");
////    var loader = $("#popalert #popmessage #divAjaxLoader");
////    if (loader.length > 0) {
////        closePopAlert();
////    }

////    $(".Cs_close_icon").show();
////}

//// bind homepage client on ajax call of "show more" button click
////function BindHomePageClient(data) {
////    if (moreHomePageClientRefill) {
////        $("#divHomePageclient").html(data);
////    }
////    else {
////        $("#divHomePageclient").append(data);
////    }
////}


// Show complete registration popup.
function ShowCompleteRegistration() {
    $.ajax({
        url: '/Client/CompleteRegister/',
        type: 'GET'
    }).done(function (data) {
        if (data.AuthError) {
            handleAjaxError(data);
            return;
        }
        popAlert("Complete registration detail", data);
    });
}

// validate image file extension

function ValidateImageFileExtension(filename) {
    var extension = filename.replace(/^.*\./, '');
    if (extension == filename) {
        extension = '';
    } else {
        // if there is an extension, we convert to lower case
        // (N.B. this conversion will not effect the value of the extension
        // on the file upload.)
        extension = extension.toLowerCase();
    }

    switch (extension) {
        case 'jpg':
        case 'jpeg':
        case 'png':
        case 'gif':
            return true;
            break;
            // uncomment the next line to allow the form to submitted in this case:
            //          break;

        default:
            // Cancel the form submission
            return false;
            break;
    }
}

// upload company image, function required FormData() of javascript 
function UploadCompanyImage(data) {
    $.ajax({
        type: "POST",
        url: "/Client/SaveCompanyImage",
        contentType: false,
        processData: false,
        beforeSend: showLoader(),
        data: data,
        error: function () { popAlert("", "Image could not be uploaded."); }
    }).done(function (messageModel) {
        hideLoader();
        if (messageModel.AuthError) {
            handleAjaxError(messageModel);
            return;
        }
        if (messageModel.error) {
            popAlert("", "Image could not be uploaded.");
            return;
        }
        if (messageModel != null && messageModel != undefined) {
            if (messageModel.ErrorMessage.length > 0) {
                popAlert(messageModel.ErrorMessage);
            }
            else {
                var imgUrl = messageModel.MediaUrl + "?" + new Date().getTime();
                $(".img-CompanyLogo").css("background", "url(" + imgUrl + ") center no-repeat");
                $(".img-CompanyLogo").css("background-size", "cover");
                //$('.img-CompanyLogo').each(function () {
                //    $('.img-CompanyLogo').css("background", "url(" + imgUrl + ") center no-repeat");
                //    $('.img-CompanyLogo').css("background-size", "cover");
                //});
            }
        }
        else {
            popAlert("", "Image could not be uploaded.");
        }
    });
}

function FormLoginSuccess(result) {
    if (result.redirectTo != undefined && result.redirectTo != null) {
        //closeLoginPopup();
        window.location.href = result.redirectTo;
    }
    else {
        $('#_login').html(result);
        ShowloginForm();
    }
}

function ShowRegisterForm() {
    $(".popup-wrapper").css('display', 'block');
    $(".popup-login").css('display', 'none');
    $(".popup-ForgotPassword").css('display', 'none');
    $(".popup-register").css('display', 'block');
    $(".popup-signup").css('display', 'block');
    $("#dlgblock").hide();
    window.location.href = "#";
    setTimezoneCookie();
    // google tag manager script.
    dataLayer.push({ "event": "registration-form" });
}

function ShowloginForm() {
    $(".popup-wrapper").css('display', 'block');
    $(".popup-register").css('display', 'none');
    $(".popup-ForgotPassword").css('display', 'none');
    $(".popup-login").css('display', 'block');
    $(".popup-signup").css('display', 'block');
    $("body").css("overflow", "hidden");
    $("#dlgblock").hide();
}

function closeLoginPopup() {
    $(".popup-wrapper").css('display', 'none');
    $(".popup-register").css('display', 'none');
    $(".popup-signup").css('display', 'none');
    $(".popup-ForgotPassword").css('display', 'none');
    $("#divLoginFail").html("");
    $(".loginTxt").val("");
    $(".field-validation-error span").remove();
}

function closeRegisterPopup() {
    $(".popup-wrapper").css('display', 'none');
    $(".popup-register").css('display', 'none');
    $(".popup-signup").css('display', 'none');
    $(".popup-ForgotPassword").css('display', 'none');
    $(".registerTxt").val("");
    $("#divRegisterFail").html("");
    $(".field-validation-error span").remove();
}

function ShowForgotPasswordForm() {
    $(".popup-wrapper").css('display', 'block');
    $(".popup-register").css('display', 'none');
    $(".popup-login").css('display', 'none');
    $(".popup-ForgotPassword").css('display', 'block');
    $(".popup-signup").css('display', 'block');
    $(".ForgotPasswordTxt").val("");
    $("body").css("overflow", "hidden");
    $("#dlgblock").hide();
}


function closeForgotPasswordPopup() {
    $(".popup-wrapper").css('display', 'none');
    $(".popup-register").css('display', 'none');
    $(".popup-signup").css('display', 'none');
    $(".popup-ForgotPassword").css('display', 'none');
    $("#divForgotPasswordStatus").html("");
    $("#divForgotPasswordSuccess").html("");
    $(".ForgotPasswordTxt").val("");
    $(".field-validation-error span").remove();
}


function ForgotPasswordSuccess(data) {
    if (data.responseJSON == true) {
        $('#_forgotPassword').html("mail sent successfully");
        ShowForgotPasswordForm();
    }
    else {
        $('#_forgotPassword').html(data);
        ShowForgotPasswordForm();
    }
}

function injectOverlay(cssSelector) {
    var noOfParents = $(cssSelector).length;
    if (noOfParents > 0) {
        if (noOfParents > 1) {
            console.log("Can't inject overlay in multiple elements(use injectMultipleOverlays function).");
            return false;
        }
    }
    else {
        console.log("No elements found to inject.");
        return false;
    }
    $(cssSelector).append(overlayHTML);
}

function showOverlay(cssSelector) {
    var noOfOverlays = $(cssSelector + " .overlay").length;
    if (noOfOverlays > 0) {
        if (noOfOverlays > 1) {
            console.log("Can't display multiple overlays(use showMultipleOverlays function).");
            return false;
        }
    }
    else {
        console.log("No overlays found to show.");
        return false;
    }
    $(cssSelector + " .overlay").removeClass("none");
}

function hideOverlay(cssSelector) {
    var noOfOverlays = $(cssSelector + " .overlay").length;
    if (noOfOverlays > 0) {
        if (noOfOverlays > 1) {
            console.log("Can't hide multiple overlays(use hideMultipleOverlays function).");
            return false;
        }
    }
    else {
        console.log("No overlays found to hide.");
        return false;
    }
    $(cssSelector + " .overlay").addClass("none");
}

function removeOverlay(cssSelector) {
    var noOfOverlays = $(cssSelector + " .overlay").length;
    if (noOfOverlays > 0) {
        if (noOfOverlays > 1) {
            console.log("Can't remove multiple overlays(use removeMultipleOverlays function).");
            return false;
        }
    }
    else {
        console.log("No overlays found to remove.");
        return false;
    }
    $(cssSelector + " .overlay").remove();
}

function showMultipleOverlays(cssSelector) {
    $(cssSelector + " .overlay").removeClass("none");
}

function hideMultipleOverlays(cssSelector) {
    $(cssSelector + " .overlay").addClass("none");
}

function removeMultipleOverlays(cssSelector) {
    $(cssSelector + " .overlay").remove();
}

function injectMultipleOverlays(cssSelector) {
    $(cssSelector).each(function () {
        $(this).append(overlayHTML);
    });
}

function setOverlayImageCustomClass(cssSelector, customClass) {
    $(cssSelector + " .overlay img").addClass(customClass);
}

function setOverlayCustomClass(cssSelector, customClass) {
    $(cssSelector + " .overlay").addClass(customClass);
}

function removeOverlayImageCustomClass(cssSelector, customClass) {
    $(cssSelector + " .overlay img").removeClass(customClass);
}

function removeOverlayCustomClass(cssSelector, customClass) {
    $(cssSelector + " .overlay").removeClass(customClass);
}

function handleAjaxError(data) {
    console.log(data.error);
    if (data.AuthError) {
        if (closePopAlert) {
            closePopAlert();
        }
        removeMultipleOverlays('body');
        injectOverlay('body');
        showOverlay('body');
        setOverlayCustomClass("body", "border-radius-large");
        setOverlayImageCustomClass("body", "login-overlay-img-custom-margin");
        if (closePopAlert) {
            closePopAlert();
        }
        document.location.pathname = "/";
    }
}

function updateScroll(id) {
    var d = document.getElementById(id);
    if (d != undefined) {
        if (d.scrollHeight > d.clientHeight) {
            d.scrollTop = d.scrollHeight - d.clientHeight;
        }
    }
}

function convertUTCDateToLocalDate(date) {
    var newDate = new Date(date.getTime() + date.getTimezoneOffset() * 60 * 1000);

    var offset = date.getTimezoneOffset() / 60;
    var hours = date.getHours();

    newDate.setHours(hours - offset);

    return newDate;
}
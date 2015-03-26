
function GetDashboardAllMessage() {
    // int lastPageId = 0, int numberOfRecords = 100, string sortBy = "", bool isScroll = false, string direction = "desc"
    var lastPageId = 0, numberOfRecords = 10, sortBy = "", isScroll = false, direction = "desc";
    var data = { lastPageId: lastPageId, numberOfRecords: numberOfRecords, sortBy: sortBy, isScroll: isScroll, direction: direction };
    $.InitAjaxMethod(apiHelper.homePageDashboardAllMessage, data, BindDashboardAllMessage, false);
}


// Get more messages on scroll down.
var moreAllMessageLastPageId = 2;
var moreAllMessageRequestIsBusy = false;
var moreAllMessageSortBy = 2; // table header index.
var moreAllMessageSortDirection = 2; // 1 for Asc, 2 for Desc
var moreAllMessageRefill = false;
function GetMoreAllMessage(sortByColumn, sortDirection, callBackFunction, isRefill, isDashboard) {
    var sortByColumnName = "";
    var sortDirectionType = "desc";
    if (!moreAllMessageRequestIsBusy) {
        moreAllMessageRequestIsBusy = true;
        moreAllMessageSortBy = sortByColumn < 0 ? moreAllMessageSortBy : sortByColumn;
        // set sortByColumnName Note : There is only sorting on CreatedOn and Name and SortByColumnName="" for CreatedOn
        sortByColumnName = sortByColumn == 0 ? "Name" : "";
        moreAllMessageSortDirection = sortDirection < 0 ? moreAllMessageSortDirection : sortDirection;
        // set sortDirectionType.
        sortDirectionType = sortDirection == 1 ? "asc" : "desc";
        moreAllMessageRefill = (isRefill != undefined && isRefill) ? isRefill : false;
        moreAllMessageLastPageId = (isRefill != undefined && isRefill) ? 1 : moreAllMessageLastPageId;
        var records = 100;
        var data = { lastPageId: moreAllMessageLastPageId, numberOfRecords: records, sortBy: sortByColumnName, isScroll: true, direction: sortDirectionType };
        if (isDashboard == true) {
            $.InitAjaxMethod(apiHelper.homePageDashboardAllMessage, data, callBackFunction, false);
        }
        else {
            $.InitAjaxMethod(apiHelper.allMessagePage, data, callBackFunction, false);
        }
    }
}

function BindDashboardAllMessage(data) {
    if (data != 0) {
        $("#divdashbaordMessage").html(data);
    }
    else {
        $("#divdashbaordMessage").html("<center><h2>No messages to display <br/> Use Youffer and get more clients.</h2></center>");
    }
}

function BindDashboardAllMessageOnScroll(data) {
    if (data != 0) {

        if (moreAllMessageRefill) {
            moreAllMessageLastPageId = 2;
            $("#tblDashboardMessages tbody").html(data);
        }
        else {
            moreAllMessageLastPageId++;
            $("#tblDashboardMessages tbody").append(data);
        }
    }
    moreAllMessageRequestIsBusy = false;
}

// Get message conversation window.
function ShowMessageHistory(wishListId) {
    var data = { wishListId: wishListId };
    $.InitAjaxMethod(apiHelper.messageHistory, data, BindMessageHistoryFirstTime, true);
}

function BindMessageHistoryFirstTime(data) {
    popAlert("", data);
    var newheight = $("#popalert").css("max-height").replace("px", "") - 150;
    $("#messageHistoryPopup").height(newheight);
    $("#popalert").vAlign().hAlign();
    $("#divMessageHistory").height(newheight - 160);
    updateScroll("divMessageHistory");
}

function GetDashboardNotReviewClients() {
    var lastPageId = 0, numberOfRecords = 10, sortBy = "", isScroll = false, direction = "desc";
    var data = { lastPageId: lastPageId, numberOfRecords: numberOfRecords };
    $.InitAjaxMethod(apiHelper.dashboardNotReviewClients, data, BindDashboardNotReviewClient, false);
}

function BindDashboardNotReviewClient(data) {
    if (data != 0) {
        $("#divDashboardNotReviewClients").html(data);
    }
    else {
        $("#divDashboardNotReviewClients").html("<center><h2>No clients to display <br/> Use Youffer and get more clients.</h2></center>");
    }
}


// get client profile and review list for searchClient page row click.
function GetclientProfileAndReview(wishListId, clientInterest, isPurchased) {
    if (wishListId && clientInterest != undefined) {
        if (clientInterest.length > 0) {
            interest = clientInterest;
            isPurchased = (isPurchased != undefined && isPurchased != null) ? isPurchased : false;
            var data = { wishListId: wishListId, interest: interest, isPurchased: isPurchased };
            $.InitAjaxMethod(apiHelper.clientProfileAndReview, data, popAlert.bind("Client Profile", null), true);
        }
    }
}

// show review form popup and Message Form popup
function ShowReviewForm(obj) {
    var model = GetFormData(obj);
    var data = { model: JSON.stringify(model) };
    if (model.WishListId != undefined) {
        $.InitAjaxMethod(apiHelper.reviewPopup, data, popAlert.bind("Review Client", null), true);
    }
    else {
        popAlert("", "Some error occured. Please try again.");
    }
}

// submit review form with rating 5 by clicking on "Mark as purchased " on ReviewClient page.
function MarkAsPurchased(obj) {
    var id = $(obj).data("wishlistid");
    if (id != undefined && id != null) {
        var wishList = GetFormData(obj);
        var model = { model: JSON.stringify(wishList) }
        if (wishList != null && wishList != undefined) {
            if (wishList.WishListId.length > 0 && wishList.PurchasedInterest != undefined) {
                $.InitAjaxMethod(apiHelper.markAsPurchased, model, ShowMarkAsPurchasedPopup, true);

            }
        }
        else {
            popAlert("", "Some error occured. Please try again.");
        }
    }
}

function ShowMarkAsPurchasedPopup(data) {
    popConfirm("", data);
    $(".CnfrmPopBtns").hide();
}


// show new message window.
function ShowNewMessageWindow(obj, IsgetDataFromHiddenFields) {
    var model = {};
    if (IsgetDataFromHiddenFields == 1) {
        model = GetNewMessageDataFromHiddenFields();
    }
    else {
        model = GetFormData(obj);
    }
    model = { model: JSON.stringify(model) };
    $.InitAjaxMethod(apiHelper.newMessage, model, popAlert.bind("", null), true);
}

// Show bulk Message Window
function ShowBulkMessagePopUp() {
    var model = { WishListId: 0, Client: { ClientId: 0, FirstName: '', FacebookImageUrl: '' }, Message: { IsBulkMessage: true } }
    var model = { model: JSON.stringify(model) };
    $.InitAjaxMethod(apiHelper.newMessage, model, popAlert.bind("", null), true);
}


function GetNewMessageDataFromHiddenFields(wishListId) {
    var clientId = $("#divNewMessageHiddenData #hClientId").val();
    if (wishListId == undefined) {
        wishListId = $("#divNewMessageHiddenData #hWishListId").val();
    }
    var firstName = $("#divNewMessageHiddenData #hFirstName").val();
    var facebookImageUrl = $("#divNewMessageHiddenData #hImage").val();
    var model = { WishListId: wishListId, Client: { ClientId: clientId, FirstName: firstName, ImageUrl: facebookImageUrl } }
    return model;
}

function FakeCallReport(wishListId, rowId) {
    popConfirm("Fake Call Report", "<div style='text-align: center'>Are you sure you want to report this client?</div>");
    fnOnDlgConfirmYes = function () {
        closeConfirmDlg();
        var model = { wishListId: wishListId };
        $.InitAjaxPostMethod(apiHelper.reportUser, model, FakeCallReportComplete.bind(null, rowId), true, "Reporting Fake call...");
    }
}

function FakeCallReportComplete(rowId, data) {
    if (data.error) {
        popAlert("", "<div style='text-align: center'>Some error occured. Please try again.</div>");
        return;
    }
    if (data != undefined && data != null) {
        if (data == true) {
            var row = $("." + rowId);
            if (row != undefined && row != null) {
                row.remove();
            }
            popAlert("", "Fake Call report submitted successfully.");
            $('#popalert').delay(3000).fadeOut("slow", function () {
                closePopAlert();
            });
            return;
        }
    }

    $("#popmessage").html("<div style='text-align: center'>Some error occured. Please try again.</div>");
}

// show Note popup
function ShowNoteHistory(wishListId) {
    var model = { wishListId: wishListId }
    $.InitAjaxMethod(apiHelper.getNoteHistory, model, popAlert.bind("", null), true);
}
// show Note popup end

function DeleteClient(wishListId, interest) {
    if (wishListId.length > 0 && interest != undefined) {
        popConfirm("Delete Client", " Are you sure you want to delete this client?");
        $(".closeConfirmDlg").css("display", "none");
        fnOnDlgConfirmYes = function () {
            var model = { wishListId: wishListId, interest: interest };
            $.InitAjaxMethod(apiHelper.deleteClient, model, DeleteClientComplete.bind(null, wishListId, interest), true);
        }
    }
    else {
        popAlert("", "<div style='text-align: center;'>Some error occured. Please try again.</div>");
    }
}

function DeleteClientComplete(wishListId, interest, data) {
    closeConfirmDlg();
    if (data.error) {
        popAlert("Error", "<div style='text-align: center;'>Some error occured. Please try again.</div>");
        return;
    }
    if (data.result == true) {
        var row = $(".Detail_" + wishListId);
        row.each(function () {
            if ($(this).data("interest") == interest) {
                $(this).hide();
            }
        });

        $("#popmessage").html("<div style='text-align: center;'>Client deleted successfully.</div>");
        $('#popalert').delay(3000).fadeOut("slow", function () {
            closePopAlert();
        });
    }
    else {
        $("#popmessage").html("<div style='text-align: center;'>Some error occured. Please try again.</div>");
    }
}


//GetDashboardClient
var moreDashboardClientLastPageId = 2; // Assume 
var moreDashboardClientRequestIsBusy = false;
var moreDashboardClientFetchCount = 8;
function GetMoreDashboardClient(records) {
    if (!moreDashboardClientRequestIsBusy) {
        moreDashboardClientRequestIsBusy = true;
        moreDashboardClientFetchCount = records
        var model = { lastPageId: moreDashboardClientLastPageId, numberOfRecords: records }
        $.InitAjaxMethod(apiHelper.getMoreDashboardClient, model, BindMoreDashboardClient, false);
    }
}

function BindMoreDashboardClient(data) {
    moreDashboardClientRequestIsBusy = false;
    if (data.count > 0) {
        moreDashboardClientLastPageId++;
        $("#divDashboardClients").append(data.view);
        if (data.count < moreDashboardClientFetchCount) {
            var view = "<div class='row'></div><div class='row'><h4 class='section-heading text-center' '>No more results to show</h4></div>";
            $("#divLoadMoreDashboardClient").html(view);
        }
    }
    else {
        var view = "<div class='row'></div><div class='row'><h4 class='section-heading text-center' '>No more results to show</h4></div>";
        $("#divLoadMoreDashboardClient").html(view);
    }
}

function ManageDashboardAllMessagePushNotification(threadId, data) {
    if (data != 0) {
        var row = $("#tblDashboardMessages tr[data-id='" + threadId + "']");
        if (row.length > 0) {
            row.remove();
        }

        $("#tblDashboardMessages tbody").prepend(data);
    }
}

function GetHomePageTopRatedClients() {
    $.InitAjaxMethod(apiHelper.homePageTopRatedClients, null, BindHomePageTopRatedClients, false);
}

function BindHomePageTopRatedClients(data) {
    if (data != 0) {
        $("#divHomePageclient").html(data);
    }
    else {
        $("#homeSearchResult").hide();
    }
}


var moreHomePageClientLastPageId = 2; // Assume 
var moreHomePageClientRequestIsBusy = false;
var moreHomePageClientSortBy = 0; // table header index.
var moreHomePageClientSortDirection = 1; // 1 for Asc, 2 for Desc
var moreHomePageClientRefill = false;
function GetMoreHomePageClient(searchText, isRefill, callBackFunction) {
    if (!moreHomePageClientRequestIsBusy) {
        moreHomePageClientRequestIsBusy = true;
        moreHomePageClientRefill = (isRefill != undefined && isRefill) ? isRefill : false;
        moreHomePageClientLastPageId = (isRefill != undefined && isRefill) ? 1 : moreHomePageClientLastPageId;
        var records = 8;
        var data = { searchText: searchText, lastPageId: moreHomePageClientLastPageId, numberOfRecords: records };
        $.InitAjaxMethod(apiHelper.homePageClients, data, BindHomePageClient, false);
    }
}

// bind homepage client on ajax call of "show more" button click
function BindHomePageClient(data) {
    closePopAlert();
    $(".Cs_close_icon").show();
    moreHomePageClientRequestIsBusy = false;

    if (data != 0) {
        moreHomePageClientLastPageId++;
        $("#divHomePageclient").append(data);
    }
    else {
        $("#divLoadMoreClient").hide();
        var view = "<div class='row'></div><div class='row'><h4 class='section-heading text-center'>No more results to show</h4></div>";
        $("#divHomePageclient").append(view);
    }
}

// get message conversation on scroll down
var moreMessageLastPageId = 2;
var moreMessageRequestIsBusy = false;
function GetMoreMessageConversation(wishListId) {
    var NumberOfRecords = 100;
    var model = { wishListId: wishListId, lastPageId: moreMessageLastPageId, NumberOfRecords: NumberOfRecords };
    $.InitAjaxPostMethod(apiHelper.moreMessageHistory, model, BindOldMessages, false);
}

// Bind message conversation data messageHistory popup.
function BindMessageConversationData(data) {
    if (data != 0) {
        $("#divMessageHistory").find(".clearfix").before(data);
        updateScroll('divMessageHistory');
    }
}

function BindOldMessages(data) {
    moreMessageRequestIsBusy = false;
    if (data != 0) {
        moreMessageLastPageId++;
        $("#divMessageHistory").prepend(data);
    }
}
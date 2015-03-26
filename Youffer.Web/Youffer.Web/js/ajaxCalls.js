var domain = "";
apiHelper = {
    homePageClients: "Home/SearchHomePageClients",
    homePageTopRatedClients: "Home/TopRated",
    homePageDashboardAllMessage: "Client/DashboardAllMessage",
    homeDashboardAllMessagePushNotification: "Common/DashboardAllMessagePushNotification",
    allMessagePage: "Client/AllMessages",
    dashboardNotReviewClients: "Client/DashboardNotReviewClient",
    messageHistory: "Lead/MessageHistory",
    moreMessageHistory: "/Lead/GetMoreMessageHistory",
    newMessage: "Lead/Message",
    clientProfileAndReview: "Client/GetClientProfileAndReview",
    reviewPopup: "Lead/ReviewClient",
    markAsPurchased: "Lead/MarkAsPurchased",
    reportUser: "Client/ReportUser",
    getNoteHistory: "Lead/Note",
    deleteClient: "Lead/DeleteClient",
    getMoreDashboardClient: "Admin/GetDashboardClient",
    allCountry: "/Common/GetAllCountry",
    getStates: "/Common/GetStates"
};
(function ($) {
    $.InitAjaxMethod = function (url, data, doneMethod, isPageLoader, loaderMessage) {
        $.ajax({
            url: (domain + url),
            data: data,
            type: 'GET',
            beforeSend: function () { if (isPageLoader) { showLoader(loaderMessage); } },
            complete: function () { if (isPageLoader) { hideLoader(); } },
        }).done(function (data) {
            if (data.AuthError) {
                handleAjaxError(data);
                return;
            }

            if ($.isFunction(doneMethod)) {
                doneMethod(data);
            }
        });
    };
})(jQuery);

(function ($) {
    $.InitAjaxPostMethod = function (url, data, doneMethod, isPageLoader, loaderMessage) {
        $.ajax({
            url: (domain + url),
            data: data,
            type: 'POST',
            beforeSend: function () { if (isPageLoader) { showLoader(loaderMessage); } },
            complete: function () { if (isPageLoader) { hideLoader(); } },
        }).done(function (data) {
            if (data.AuthError) {
                handleAjaxError(data);
                return;
            }

            if ($.isFunction(doneMethod)) {
                doneMethod(data);
            }
        });
    };
})(jQuery);

$(function () {
    try {
        if (companyId != undefined && companyId.length > 0) {
            // Reference the auto-generated proxy for the hub.
            $.connection.hub.url = 'http://www.youffer.com:88/signalr/hubs';
            var signalRChat = $.connection.chat;
            signalRChat.client.addMessage = function (message) {
                SpreadMessage(message);
            };
            // Start the connection.
            $.connection.hub.start().done(function () {
                // leave room if already exists.
                signalRChat.server.leaveRoom(companyId);
                // join room
                signalRChat.server.joinRoom(companyId);
            });
        }

    }
    catch (err) {

    }
});


function PushMessageInChatWidnow(message) {
    $.ajax({
        url: '/Common/ChatWindowPushNotification',
        type: 'POST',
        data: { message: JSON.stringify(message) }
    }).done(function (data) {
        if (data.AuthError) {
            handleAjaxError(data);
            return;
        }
        else if (data.error) {
            console.log(data.error);
            return;
        }

        BindMessageConversationData(data);
    });
}

function PushMessageInAllMessageWindow(message, threadId) {
    $.ajax({
        url: '/Common/AllMessagePushNotification',
        type: 'POST',
        data: { message: JSON.stringify(message) }
    }).done(function (data) {
        if (data.AuthError) {
            handleAjaxError(data);
            return;
        }
        else if (data.error) {
            console.log(data.error);
            return;
        }
        AllMessageRemoveThread(threadId);
        $("#tblAllMessages tbody").prepend(data);
    });
}


function homeDashboardAllMessagePushNotification(message, threadId) {
    var lastPageId = 0, numberOfRecords = 10, sortBy = "", isScroll = false, direction = "desc";
    var data = { message: JSON.stringify(message) };
    $.InitAjaxMethod(apiHelper.homeDashboardAllMessagePushNotification, data, ManageDashboardAllMessagePushNotification.bind(null, threadId), false);
}

function SpreadMessage(message) {
    message.ModifiedOn = "\/Date(" + new Date(message.ModifiedOn).valueOf() + ")\/";
    message.CreatedOn = "\/Date(" + new Date(message.CreatedOn).valueOf() + ")\/";
    if (message.MessageMediaDto != null) {
        message.MessageMediaDto.ModifiedOn = "\/Date(" + new Date(message.ModifiedOn).valueOf() + ")\/";
        message.MessageMediaDto.CreatedOn = "\/Date(" + new Date(message.CreatedOn).valueOf() + ")\/";
    }
    var chatWidnow = $("#ChatWindowForPushNotification");
    var allMessageWindow = $("#AllMessageForPushNotification");
    var dashboardAllMessage = $("#tblDashboardMessages");
    if (chatWidnow != undefined && chatWidnow.length > 0) {
        var clientId = $("#hClientId").val();
        if (clientId != undefined && clientId.length > 0) {
            if (clientId.trim() == message.UserId) {
                PushMessageInChatWidnow(message);
            }
        }
    }
    if (allMessageWindow != undefined && allMessageWindow.length > 0) {
        PushMessageInAllMessageWindow(message, message.ThreadId);
    }

    if (dashboardAllMessage != undefined && dashboardAllMessage.length > 0) {
        homeDashboardAllMessagePushNotification(message, message.ThreadId)
    }
}

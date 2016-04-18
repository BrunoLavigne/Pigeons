/**********************************************************
                new scripts
**********************************************************/
var sessionUserName = $("#ContentPlaceHolder1_hdPersondUserName").val();

var chatHub = $.connection.chatHub;

var userName;
var authorId;
var roomName;
var roomId;
var newMessage;
var isMe;

function ajaxMessageData() {
    $.ajax({
        type: "POST",
        url: "Chat.aspx/GetGroupMessages",
        contentType: "application/json; charset=UTF-8",
        dataType: "json",
        success: OnSuccess,
        error: function (response) {
            alert(response.e);
        }
    });

    function OnSuccess(response) {
        console.log("success i guess " + response.d);
        var idToAppend;
        $.each(JSON.parse(response.d), function (index, value) {
            $('#divContainer').append("<div id='divChat_" + value.groupId + "' data-id='" + value.groupId + "' class='chatRoom'>" +
                "<div class='title'>" + value.groupName +
                "</div>" +
                "<div class='groupPersons' style='border-style: groove' >" +
                "</div>" +
                "<div class='content'>" +
                    "<div id='divChatWindow_" + value.groupId + "' class='chatWindow'>" +
                    "</div>" +
                    "<div id='divusers' class='users'>" +
                    "</div>" +
                "</div>" +
                "<div class='messageBar'>" +
                    "<input class='textbox txtMessage' type='text' />" +
                    "<input type='button' value='Send' class='submitButton btnSendMsg' />" +
                "</div>" +
            "</div>");

            $(".chat-rooms-nav").append("<div class='chat-room-link'>" +
                "<a href='#' data-room-id='" + value.groupId + "'>" + value.groupName + "</a></div>");

            joinRoom(value.groupId);
        });

        $.each(JSON.parse(response.d), function (index, value) {
            $.each(value.Message, function (numMessage, contentMessage) {
                idToAppend = "#divChatWindow_" + value.groupId;

                if (contentMessage.authorName != sessionUserName) {
                    $(idToAppend).append("<div><b>" + contentMessage.authorName + "</b><div style='float:right'> " + contentMessage.dateMessage + "</div><div class='contentMessage'>" + contentMessage.message + "</div>");
                } else {
                    $(idToAppend).append("<div>" + contentMessage.dateMessage + "<div style='float:right'><b> " + contentMessage.authorName + "</b></div><div class='contentMessage' >" + contentMessage.message + "</div>");
                }
            });
        });

        // Toggle corresponding chat box from chat nav
        var $navLinksToChat = $(".chat-room-link a");
        var $chatBox = $(".chatRoom");

        $navLinksToChat.click(function () {
            var roomToToggleID = $(this).data("room-id");

            $.each($chatBox, function (index, value) {
                if ($(this).data("id") == roomToToggleID) {
                    $(this).fadeToggle();
                }
            });
        });
    }
}

function ajaxGetPeopleData() {
    $.ajax({
        type: "POST",
        url: "Chat.aspx/GetGroupPeople",
        contentType: "application/json; charset=UTF-8",
        dataType: "json",
        success: OnSuccessCount,
        error: function (response) {
            alert(response.e);
        }
    });
    function OnSuccessCount(response) {
        //console.log("success i guess " + response.d);
        $.each(JSON.parse(response.d), function (index, value) {
            console.log(value);
            $.each(value.personName, function (ind, val) {
                console.log(val);
                //console.log("Le groupId est " + valueGroupId)
                $("#divContainer").find(".chatRoom[data-id=" + value.groupId + "] .groupPersons").append(val + "</br>")
            });
        });
    }
}

$(function () {
    $.connection.hub.logging = true;
    $.connection.hub.start().done(function () {
        console.log("toggle the group chat!");
        ajaxMessageData();
        console.log("Message data done");
        ajaxGetPeopleData();
        console.log("Get People Done");
        $(".chatRoom").slideToggle(200);
    });
});

$(document).on("click", ".chatRoom", function () {
    $(this).find(".title").css("background-color", "white");
});

//Lorsqu'un utilisateur rejoin un group
function joinRoom(roomNameId) {
    roomName = roomNameId;
    chatHub.server.joinRoom(roomName);
}
//Lorsqu'un utilisateur quite le group
function leaveRoom() {
    chatHub.server.leaveRoom(roomName);
}

//Lorsqu'on appuis sur notre clavier le bouton Enter en ayant le focus sur le txtMessage
$(document).on("keypress", ".txtMessage", function (e) {
    if (e.which == 13) {
        e.preventDefault();
        //On trouve dans quel chat room l'évenement à été executé, puis on déclenche l'evenement
        //du bouton btnSendMsg
        $(this).closest(".chatRoom").find(".btnSendMsg").click();
    }
});

//Après avoir appuyer sur le bouton Enter à partir de notre clavier
//on execute l'évenement suivant
$(document).on("click", ".btnSendMsg", function () {
    //Initialisation de la variable messageToSend, qui nous permettera de garder en memoire le message
    //qu'on devra envoyer aux autres membres du group
    var messageToSend = $(this).closest(".chatRoom").find(".txtMessage").val();
    roomId = $(this).closest(".chatRoom").data("id");

    //Si le message à envoyer contient une taille suppérieur à zero
    if (messageToSend.length > 0) {
        //...On execute la fonction sendMessage, en lui passant en paramètre le message à envoyer
        //Ansi que le id du group
        sendMessage(messageToSend, roomId);
        //On efface le contenu du champ pour écrire
        $(this).closest(".chatRoom").find(".txtMessage").val('');
    }
});

//La fonction sendMessage, qui prend en paramètre le message ainsi que le id du group, nous permet
//d'envoyer le message desirer au bon group
function sendMessage(message, roomId) {
    //initialisation des varibles suivante, afin d'avoir les informations nécessaire pour les messages envoyé
    userName = sessionUserName;
    newMessage = message;
    roomName = roomId;
    isMe = true;

    //On appel la methode sendMessage qui est dans la class chathub
    chatHub.server.sendMessage({ authorId: $("#hdPersondId").val(), name: sessionUserName, message: newMessage, roomName: roomName });

    //On appel la methode displayMessage, afin d'afficher directement à l'utilisateur le message qu'il vient d'envoyer
    displayMessage(userName, message, roomName, isMe);

    //On met la variable newMessage pour les messages futures afin qu'il n'y ai pas de conflit avec les anciens messages
    newMessage = "";
}

function displayMessage(userName, message, roomId, isMe) {
    var date = new Date();
    var day = date.getDate();
    var month = date.getMonth();
    var year = date.getFullYear();
    //Si l'utilisateur est celui qui envoit le message, on lui fais l'affichage suivant
    if (isMe == true) {
        $("#divContainer").find(".chatRoom[data-id=" + roomId + "] .chatWindow").append("<div>" + year + "-" + month + "-" + day + "<div style='float:right'><b> " + userName + "</b></div><div class='contentMessage' >" + message + "</div>");
    }
        //Si l'utilisateur est celui qui recoit le message, on lui fais l'affichage suivant
    else {
        $("#divContainer").find(".chatRoom[data-id=" + roomId + "] .chatWindow").append("<div><b>" + userName + "</b><div style='float:right'> " + year + "-" + month + "-" + day + "</div><div class='contentMessage'>" + message + "</div>");
    }
}

chatHub.client.newMessage = onNewMessage;

function onNewMessage(name, message, roomId) {
    isMe = false;
    displayMessage(name, message, roomId, isMe);
    var strMatch = "\B\@channel\b";
    if (message.match(strMatch[1])) {
        toastr.info(message);
        $("#divContainer").find(".chatRoom[data-id=" + roomId + "] .title").css("background-color", "yellow");
    }
};

$(document).on("click", ".title", function () {
    console.log("toggle the group chat!");
    $(this).closest(".chatRoom").find(".content").slideToggle(200);
    $(this).closest(".chatRoom").find(".messageBar").slideToggle(200);
    $(this).closest(".chatRoom").find(".messageBar").slideToggle(200);
});

$(".chat-toggler").click(function () {
    console.log("toggle the group chat!");
    ajaxMessageData();
    $(".chatRoom").slideToggle(200);
});

$(".group-toggler").click(function () {
    $(".users").slideToggle();
});
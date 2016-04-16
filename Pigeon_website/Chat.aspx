﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Chat.aspx.cs" Inherits="Chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="Resources/css/Group-chat.css" />
    <script type="text/javascript" src="Resources/js/ajax/chat.js">
    </script>
    <!-- Toastr links -->
    <link href="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css" rel="stylesheet" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js" rel="stylesheet" />
    <!-- Toastr scripts -->
    <script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="http://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.2/js/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!--Reference the SignalR library. -->
    <script src="Scripts/jquery.signalR-2.2.0.min.js"></script>

    <!--Reference the autogenerated SignalR hub script. -->
    <script src="/signalr/hubs"></script>

    <div id="divContainer">
     
        <input id="hdPersondId" type="hidden" runat="server" />
        <input id="hdPersondUserName" type="hidden" runat="server" />
        <input id="hdGroupId" type="hidden" runat="server" />
    </div>

    <div class="chat-toggler">
        <a href="#">Discussion pour le groupe</a>
    </div>

    <!--Add script to update the page and send messages.-->
    <script type="text/javascript">

        /**********************************************************
                        new scripts
        **********************************************************/
        
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
                        "<div class='title'>" +
                            "Welcome to Chat Room " + value.groupId +
                            "<div class='group-toggler'>toggle group</div>" +
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
                    
                    joinRoom(value.groupId);
                });
                $.each(JSON.parse(response.d), function (index, value) {
                    $.each(value.Message, function (numMessage, contentMessage) {
                        idToAppend = "#divChatWindow_" + value.groupId;
                        $(idToAppend).append("<div>" + numMessage + " : " + contentMessage + "</div>");
                    });
                });
            }
        }

        var chatHub = $.connection.chatHub;
        var messages = new Array();

        var userName;
        var roomName;
        var roomId;
        var newMessage;

        $(function () {
            $.connection.hub.logging = true;
            $.connection.hub.start();
        });

        function joinRoom(roomNameId) {
            roomName = roomNameId;
            chatHub.server.joinRoom(roomName);
            console.log('joining room ' + roomName);
        }

        function leaveRoom() {
            chatHub.server.joinRoom(roomName);
        }

        $(document).on("keypress", ".txtMessage", function (e) {
            if (e.which == 13) {
                e.preventDefault();
                $(this).closest(".chatRoom").find(".btnSendMsg").click();
            }
        });

        $(document).on("click", ".btnSendMsg", function () {
            var messageToSend = $(this).closest(".chatRoom").find(".txtMessage").val();
            roomId = $(this).closest(".chatRoom").data("id");
            if (messageToSend.length > 0) {
                sendMessage(messageToSend, roomId);
                $(this).closest(".chatRoom").find(".txtMessage").val('');
            }
        });

        function sendMessage(message, roomId) {
            userName =  <%= hdPersondId.Value %>
            newMessage = message;
            roomName = roomId;

            chatHub.server.sendMessage({ name: userName, message: newMessage, roomName: roomName });
            displayMessage("You: " + newMessage, roomName);
            newMessage = "";
 
        }

        function displayMessage(message, roomId) {
            messages.push({ message: message });
            console.log(messages);
            $("#divContainer").find(".chatRoom[data-id=" + roomId + "] .chatWindow").append('<div>' + message + '</div>');

            var height = $("#divContainer").find(".chatRoom[data-id=" + roomId + "] .chatWindow").scrollHeight;
            $("#divContainer").find(".chatRoom[data-id=" + roomId + "] .chatWindow").scrollTop(height);
        }

        chatHub.client.newMessage = onNewMessage;

        function onNewMessage(message, roomId) {
            console.log(roomId);
            displayMessage(message, roomId);
            if (!$("#txtMessage").is(":focus")) {
               toastr.info(message);
            }
        };

        $(document).on("click", ".title", function () {
            console.log("toggle the group chat!");
            $(this).closest(".chatRoom").find(".content").slideToggle(200);
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

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScripts" runat="Server">
</asp:Content>
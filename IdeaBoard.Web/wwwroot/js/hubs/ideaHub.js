﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/ideaHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("UpdateIdeas", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    console.log(user, message);
    connection.invoke("SaveIdea", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
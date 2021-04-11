"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/ideaHub").build();

document.getElementById("btnSaveIdea").disabled = true;

connection.start().then(function () {
    document.getElementById("btnSaveIdea").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("UpdateIdeas", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});



document.getElementById("btnSaveIdea").addEventListener("click", function (event) {
    var sessionId = document.getElementById("sessionId").value;
    var ideaDescription = document.getElementById("ideaDescription").value;
    console.log(sessionId, ideaDescription);
    connection.invoke("SaveIdea", sessionId, ideaDescription).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
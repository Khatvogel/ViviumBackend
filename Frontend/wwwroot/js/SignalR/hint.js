"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/hintsHub").build();

connection.on("Create", function (amount) {
    console.log("Hints: " + amount);
    let hints = document.getElementById("hints-notification");
    hints.innerHTML = amount;
});

connection.start();
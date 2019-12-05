"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/hintsHub").build();

connection.on("Create", function (amount) {
    console.log("Hints: " + amount);
    let hints = document.getElementById("hints-notification");
    if (amount > 0) {
        hints.classList.add("notification");
        hints.innerHTML = amount;
    } else {
        hints.classList.remove("notification")
    }
});

connection.start();
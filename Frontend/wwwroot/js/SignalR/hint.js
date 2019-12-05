"use strict";

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hintsHub")
    .withAutomaticReconnect()
    .build();

connection.on("Create", function (amount, hints) {
    console.log(hints);
    let hintDiv = document.getElementById("hints-notification");
    if (amount > 0) {
        hintDiv.classList.add("notification");
        hintDiv.innerHTML = amount;

        let ul = $("#hints-description");
        ul.empty();

        hints.forEach(function (hint) {
            ul.append("<a class=\"dropdown-item\" href=\"javascript:void(0)\">Ronde " + hint.attempt.id + " vroeg om een hint met id " + hint.id + "</a>");
        });

    } else {
        hintDiv.classList.remove("notification")
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

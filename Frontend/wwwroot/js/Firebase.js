var firebaseConfig = {
    apiKey: "AIzaSyD6miUnNyMth6fNgleojI-ZqrZU3xv6Nac",
    authDomain: "vivium.firebaseapp.com",
    databaseURL: "https://vivium.firebaseio.com",
    projectId: "vivium",
    storageBucket: "vivium.appspot.com",
    messagingSenderId: "790583480480",
    appId: "1:790583480480:web:8a161eb0e4bfd75c90f9c5",
    measurementId: "G-MLF17J6942"
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);

let gamesRef = firebase.database().ref();

gamesRef.on('value', function (data) {
    $("#status-spinner").hide();
    let games = Object.values(data.val());
    let ul = $("#game-status");
    ul.empty();
    games[0].forEach(function (game) {
        ul.append("<li class=\"list-group-item\">" + game["Name"] + " - " + game["Status"] + "</li>");
    });
}); 
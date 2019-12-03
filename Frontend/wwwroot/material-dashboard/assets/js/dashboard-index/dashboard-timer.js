let started = false;
let totalSeconds = -1;
let gameStatusHeader = $("#game-status-header");

gameStatusHeader.click(function () {
    $("#start-new-game-modal").modal();
});

$("#new-game-button").click(function () {
    if (!started) {
        countTimer();
        window.myInterval = setInterval(countTimer, 1000);       
        gameStatusHeader.removeClass("card-header card-header-success");
        gameStatusHeader.addClass("card-header card-header-danger");
        $("#modal-body-text").html("Wilt u het spel beëindigen?");
        started = true;
    } else {
        if (window.myInterval !== undefined && window.myInterval !== 'undefined') {
            window.clearInterval(window.myInterval);
        }
        totalSeconds = 0;
        gameStatusHeader.removeClass("card-header card-header-danger");
        gameStatusHeader.addClass("card-header card-header-success");
        gameStatusHeader.html("<h2>Start a new game!</h2>");
        started = false;
    }
});

function countTimer() {
    ++totalSeconds;
    let hour = Math.floor(totalSeconds / 3600);
    let minute = Math.floor((totalSeconds - hour * 3600) / 60);
    let seconds = totalSeconds - (hour * 3600 + minute * 60);

    document.getElementById("game-status-header").innerHTML
        = "<h2>Total time: " + hour + ":" + minute + ":" + seconds + "</h2>";
}


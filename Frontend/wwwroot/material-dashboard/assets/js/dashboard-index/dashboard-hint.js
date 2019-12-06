let sendHintButton = $("#send-hint-button");
let hintLabel = $("#label-hint-id");
let hintId = 0;

function hintOnClick(data) {
    hintId = data;
    hintLabel.empty();
    hintLabel.html("Hint #" + data);
    $("#hint-answer-modal").modal();
    $('input[id="hint-id"]').val(hintId);
}

$('.modal').on('hidden.bs.modal', function () {
    $(this).find('form')[0].reset();
});

sendHintButton.click(function () {
    $("#hint-form").submit();
});

$(document).on("submit", "#hint-form", function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: '/hint/save',
        data: $(this).serialize(),
        success: function (response) {
            console.log(response);
        },
        error: function (error) {
            console.log(error);
        }
    });
});


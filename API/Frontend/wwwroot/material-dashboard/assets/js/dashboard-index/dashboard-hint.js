let hintLabel = $("#label-hint-id");

function hintOnClick(data) {
    hintLabel.empty();
    hintLabel.html("Hint #" + data);
    $("#hint-answer-modal").modal();
    $('input[name="Hint.Id"]').val(data);
}

$('#hint-answer-modal').on('shown.bs.modal', function () {
    $('#Hint_Description').focus()
});

$('.modal').on('hidden.bs.modal', function () {
    $(this).find('form')[0].reset();
});


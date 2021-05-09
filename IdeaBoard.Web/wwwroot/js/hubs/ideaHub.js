"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/ideaHub").build();

document.getElementById("btnSaveIdea").disabled = true;

connection.start().then(function () {
    document.getElementById("btnSaveIdea").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("AddNewIdea", function (sessionId, idea) {
    var items = [];
    items.push('<div id="idea_' + idea.id + '" class="col-lg-3 col-md-4 col-sm-6" style="margin-bottom: 10px">');
    items.push('<div class="card rounded" style="padding-top:10px;">');
    items.push(getEmoji(idea.emojiId));
    items.push('<div class="card-body">');
    items.push('<p class="card-text">' + idea.description + '</p>');
    items.push('<button id="btnDeleteIdea_' + idea.id + '" class="btn btn-sm btn-outline-danger">X</button>');
    items.push('<a href="#" class="btn fa-pull-right"><i class="far fa-thumbs-up"></i> 0</a>');
    items.push('</div>');
    items.push('</div>');
    items.push('</div>');

    $('#sessionIdeas_' + sessionId).prepend(items.join(''));
    $('#divNoIdeas').hide();
    window.showSuccessToast("Fikir eklendi.");
});

connection.on("RemoveIdea", function (sessionId, ideaId) {
    $('#idea_' + ideaId).remove();
    var ideaCount = $('#sessionIdeas_' + sessionId + ' div[id^=idea_]').length;
    if (ideaCount === 0) {
        $('#divNoIdeas').show();
    }
    window.showSuccessToast("Fikir silindi.");
});

document.getElementById("btnSaveIdea").addEventListener("click", function (event) {
    if (!validateInputs())
        return;
    var sessionId = document.getElementById("sessionId").value;
    var ideaDescription = document.getElementById("ideaDescription").value;
    var emojiId = 0;
    $('input[id^=ideaEmoji_]').each(function () {
        if ($(this).is(':checked')) {
            var inputId = $(this).attr('id');
            emojiId = inputId.split('_')[1];
            return false;
        }
    });
    connection.invoke("SaveIdea", sessionId, ideaDescription, emojiId).catch(function (err) {
        return console.error(err.toString());
    });
    clearInputs();
    $('#addIdeaModal').modal('hide');
    event.preventDefault();
});

document.getElementById()
//$('[id^=btnDeleteIdea_]').click(function (event) {
    console.log("geldi");
    var sessionId = document.getElementById("sessionId").value;
    var btnId = $(this).attr('id');
    var ideaId = btnId.split('_')[1];
    connection.invoke("DeleteIdea", ideaId, sessionId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function validateInputs() {
    var emojiSelected = false;
    $('input[id^=ideaEmoji_]').each(function () {
        if ($(this).is(':checked')) {
            emojiSelected = true;
            return false;
        }
    });
    if (!emojiSelected) {
        window.showWarningToast('Emoji seçmediniz!');
        return false;
    }

    var description = $('#ideaDescription').val();
    if (description === '') {
        window.showWarningToast('Açıklama girmediniz!');
        return false;
    }
    return true;
}

function clearInputs() {
    $('#ideaDescription').val('');
}
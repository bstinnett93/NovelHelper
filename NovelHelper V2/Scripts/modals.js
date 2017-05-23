function addNovel(e) {
    $('#addModalBody').html('');
    $.ajax({
        url: e,
        type: 'GET',
        success: function (partialView) {
            $('#addModalBody').html('');
            $('#addModalBody').html(partialView);
        },
        error: function () {
            alert('error!');
        }
    });
}
function addSetting(e) {
    $('#addModalBody').html('');
    $.ajax({
        url: e,
        type: 'GET',
        success: function (partialView) {
            $('#addModalBody').html('');
            $('#addModalBody').html(partialView);
        },
        error: function () {
            alert('error!');
        }
    });
}
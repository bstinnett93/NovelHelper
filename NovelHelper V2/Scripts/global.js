$('#createNovel').click(function () {
    var link = $(this).data('request-url');
    $('#subView').load(link);
});
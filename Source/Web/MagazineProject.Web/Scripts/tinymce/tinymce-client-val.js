(function() {
    $('form input[type=submit]').click(function () {
        tinyMCE.triggerSave();
    });
    $.validator.setDefaults({
        ignore: ""
    });
})();
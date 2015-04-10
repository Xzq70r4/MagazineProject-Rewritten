$(function () {
    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function(data) {
            var $target = $($form.attr("data-ajax-update"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight", { color: 'white' }, 3000);
        });

        return false;
    };

    var submitAutocomplete = function (event, ui) {

        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    }

    var createAutocomplete = function() {
        var $input = $(this);

        var options = {
            source: $input.attr("data-search-autocomplete"),
            select: submitAutocomplete
        };

        $input.autocomplete(options);
    }

    $("form[data-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-search-autocomplete]").each(createAutocomplete);
});
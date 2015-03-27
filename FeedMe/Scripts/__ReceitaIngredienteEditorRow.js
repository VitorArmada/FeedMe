$(".deleteButton").click(function () {
    if ($(".editorRow").length > 1) {
        $(this).parent().remove();
    }
});
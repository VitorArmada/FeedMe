$(document).ready(function () {
    $("#addAnother").click(function () {
        $.get('/Receitas/EtapaEditorRow', function (template) {
            $("#editorRows").append(template);
        });
    });
});
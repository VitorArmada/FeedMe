$(document).ready(function () {
    $("#addAnother").click(function () {
        $.get('/Receitas/IngredienteEditorRow', function (template) {
            $("#editorRows").append(template);
        });
    });
});
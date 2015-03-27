$(document).ready(function () {

    $("#opac").bind('mouseenter', function () {
        $(this).css('cursor', 'pointer');
        $(this).addClass("oimg");
    });

    $("#opac").bind('mouseleave', function () {
        $(this).css('cursor', 'default');
        $(this).removeClass("oimg");
    });

    $(".close").click(function (event) {
        var idval = $(this).parent().attr("id");
        event.preventDefault();
        deleteComment(idval);
    });

    function deleteComment(Commentid) {
        $.ajax({
            type: "POST",
            url: "/Receitas/DeleteComment/" + Commentid,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: auxDelete
        });
    }

    function auxDelete(result) {
        $("div").filter(function () {
            return $(this).attr("id") == result;
        }).remove();
    }

    $(".follow").bind('mouseenter', function () {
        $(this).css('cursor', 'pointer');
    });

    $(".follow").bind('mouseleave', function () {
        $(this).css('cursor', 'default');
    });

    $(".follow").bind('click', function () {
        var prev = $(this).parent();
        var index = prev.index();
        var children = prev.parent().children();
        var children1 = prev.parent().children();
        var count = children.length;
        var next_index;
        if ((index + 1) < count) {
            next_index = index + 1;
        } else {
            next_index = 0;
        }
        children.eq(index).hide();
        children1.eq(next_index).show();
    });

});

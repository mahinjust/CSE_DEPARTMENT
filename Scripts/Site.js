
$(document).ready(function () {
    $("#btnShow").mousedown(function () {
        $("#Password").attr("type", "text");
    });
    $("#btnShow").mousedown(function () {
        $("#ConfirmPassword").attr("type", "text");
    });

    $("#btnShow").on("mouseleave", function () {
        $("#Password").attr("type", "password");
    });
    $("#btnShow").on("mouseleave", function () {
        $("#ConfirmPassword").attr("type", "password");
    });
});
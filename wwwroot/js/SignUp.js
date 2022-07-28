

$(document).ready(function () {

    $("#PasswordHidden").click(function () {
        $("#PasswordHidden").hide();
        $("#PasswordShow").show();
        $("#txtPassword").attr("type", "text");
    });

    $("#PasswordShow").click(function () {
        $("#PasswordShow").hide();
        $("#PasswordHidden").show();
        $("#txtPassword").attr("type", "password");
    });

    $("#ConfirmPasswordHidden").click(function () {
        $("#ConfirmPasswordHidden").hide();
        $("#ConfirmPasswordShow").show();
        $("#txtConfirmPassword").attr("type", "text");
    });

    $("#ConfirmPasswordShow").click(function () {
        $("#ConfirmPasswordShow").hide();
        $("#ConfirmPasswordHidden").show();
        $("#txtConfirmPassword").attr("type", "password");
    });
});
$(document).ready(function () {

    var x = 0;
    var s = "";

    console.log("Hello Pluralsight");

    var theForm = $("#theForm");
    theForm.hide();

    var button = $(".product-props li");
    button.on("click", function () {
        console.log("You have clicked on" + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");
    $loginToggle.on("click", function () {
        $popupForm.toggle(100);
    });
});
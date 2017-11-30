$(document).ready(function () {

    //var a = "Hello JavaScript!";
    //alert(a);

    //var theForm = $("#theForm");
    //theForm.hide();

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("Buying Item");
    });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You clicked on " + $(this).innerText);
    });


    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");
    $loginToggle.on("click", function() {
        $popupForm.slideToggle(200);
    });



});//end of document.ready


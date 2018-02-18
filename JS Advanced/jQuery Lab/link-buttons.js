function attachEvents() {
    $("a.button").on("click", mark);

    function mark() {
        $(".selected").removeClass("selected");
        $(this).addClass("selected");
    }
}
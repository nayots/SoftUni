function attachEvents() {
    $("#items > li").on("click", mark)

    function mark() {
        let li = $(this);
        if (li.attr('data-selected')) {
            li.removeAttr('data-selected');
            li.css('background', '');
        } else {
            li.attr('data-selected', 'true');
            li.css('background', '#DDD');
        }
    }

    $("#showTownsButton").on("click", function () {
        $("#selectedTowns").text("Selected towns: " + $("#items > li[data-selected=true]").toArray().map(l => l.textContent).join(", "));
    })
}
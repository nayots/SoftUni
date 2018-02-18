function extractText() {
    $("#result").text($("#items > li").toArray().map(e => e.textContent).join(", "));
}
function search() {
    let searchWord = $("#searchText").val();
    $("#result").text($(`#towns > li:Contains("${searchWord}")`).length);
    $(`#towns > li:contains("${searchWord}")`).css("font-weight", "bold");
    $(`#towns > li:not(:contains("${searchWord}"))`).css("font-weight", "");
}
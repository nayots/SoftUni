function sort(colIndex, descending) {
    let rows = $("#products > tbody > tr");
    let sortedRows = [];
    if (colIndex === 0) {
        sortedRows = rows.sort((a, b) => {
            if (descending) {
                return $(b.children[0]).text().localeCompare($(a.children[0]).text());

            } else {
                return $(a.children[0]).text().localeCompare($(b.children[0]).text());
            }
        })
    } else {
        sortedRows = rows.sort((a, b) => {
            if (descending) {
                return Number($(b.children[1]).text()) - (Number($(a.children[1]).text()));

            } else {
                return Number($(a.children[1]).text()) - (Number($(b.children[1]).text()));
            }
        })
    }
    $("#products  tbody").append(sortedRows);
}
// const $ = require("jquery");

function move(direction) {
    let selectedElement = null;
    switch (direction) {
        case "right":
            selectedElement = $("#available-towns option:selected")[0];
            $(selectedElement).appendTo("#selected-towns");
            break;

        case "left":
            selectedElement = $("#selected-towns option:selected")[0];
            $(selectedElement).appendTo("#available-towns");
            break;
        case "print":
            let items = [];
            $("#selected-towns > option").each((ind, ele) => items.push($(ele).val()));
            $("#output").html(items.join("; "));
            break;
        default:
            break;
    }
}
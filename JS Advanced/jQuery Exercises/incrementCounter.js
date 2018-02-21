function increment(selector) {
    let container = $(selector);
    let fragment = document.createDocumentFragment();
    let textArea = $("<textarea>");
    let incrementBtn = $("<button>Increment</button>");
    let addtBtn = $("<button>Add</button>");
    let list = $("<ul>");

    textArea.val(0);
    textArea.addClass("counter");
    textArea.attr("disabled", true);

    incrementBtn.addClass("btn");
    incrementBtn.attr("id", "incrementBtn");
    addtBtn.addClass("btn");
    addtBtn.attr("id", "addBtn");

    list.addClass("results");

    $(incrementBtn).on("click", function () {
        textArea.val(+textArea.val() + 1);
    });
    $(addtBtn).on("click", function () {
        let li = $(`<li>${textArea.val()}</li>`);
        li.appendTo(list);
    });

    textArea.appendTo(fragment);
    incrementBtn.appendTo(fragment);
    addtBtn.appendTo(fragment);
    list.appendTo(fragment);

    container.append(fragment);
}
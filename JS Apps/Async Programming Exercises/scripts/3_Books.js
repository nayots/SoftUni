function attachEvents() {
    const baseUrl = "https://baas.kinvey.com/appdata/kid_rkOE5IY5f/books";
    const auth = `Basic ${btoa("guest:guest")}`;
    const requestHeaders = {
        "Authorization": auth,
        "Content-type": "application/json"
    }

    $(loadBooks);
    $("#add").click(addBook);

    async function loadBooks() {
        let books = $("#books");
        books.empty();

        let allBooks = await $.ajax({
            method: "GET",
            headers: requestHeaders
        });

        for (const book of allBooks) {
            books.append(createBookItem(book));
        }
    }

    async function addBook() {

        let [title, author, isbn] = $("#newBooksFiels input").map((i, item) => $(item).val());

        if (title && author && isbn) {
            let data = {
                title,
                author,
                isbn
            }
            $("#newBooksFiels > input").val("")
            let res = await $.ajax({
                method: "POST",
                url: baseUrl,
                headers: requestHeaders,
                data: JSON.stringify(data)
            });

            let newBook = createBookItem(res);

            $("#books").append(newBook);
        }
    }

    function createBookItem(b) {
        let li = $("<li>");
        let content = $(`<span>Title: ${b.title}; Author: ${b.author}; ISBN: ${b.isbn}; </span>`);
        content.append($(`<a href="#">[Delete]</a>`).click(() => {
            $.ajax({
                method: "DELETE",
                url: baseUrl + `/${b._id}`,
                headers: requestHeaders
            }).then(() => {
                li.remove();
            });
        }));
        li.append(content);

        return li;
    }
}
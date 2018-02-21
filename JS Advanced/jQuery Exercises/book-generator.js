function createBook(selector, titleName, authorName, isbn) {
    let id = 1;

    let container = $(selector);
    let bookContainer = $('<div></div>');
    bookContainer.attr('id', 'book' + id);
    id++;

    let title = $('<p></p>').text(titleName);
    let author = $('<p></p>').text(authorName);
    let isBn = $('<p></p>').text(isbn);
    title.addClass('title');
    author.addClass('author');
    isBn.addClass('isbn');
    let btnSelect = $('<button>Select</button>');
    let btnDeselect = $('<button>Deselect</button>');

    btnSelect.on('click', function (event) {
        bookContainer.css('border', '2px solid blue');
    });
    btnDeselect.on('click', function (event) {
        bookContainer.css('border', 'none');
    });
    bookContainer
        .append(title)
        .append(author)
        .append(isBn)
        .append(btnSelect)
        .append(" ")
        .append(btnDeselect);

    bookContainer.appendTo(container);
};
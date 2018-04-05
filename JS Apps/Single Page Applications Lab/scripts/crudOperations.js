const BASE_URL = 'https://baas.kinvey.com/'
const APP_KEY = 'kid_ry-XrJacf'
const APP_SECRET = '88183786c3494887b0167e5451797664'
const AUTH_HEADERS = {
    'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)
}
const BOOKS_PER_PAGE = 10

function loginUser() {
    let loginForm = $("#formLogin");
    let username = loginForm.find('input[name="username"]').val();
    let password = loginForm.find('input[name="passwd"]').val();
    if (username && password) {

        let loginData = {
            username,
            password
        };
        $.ajax({
            method: "POST",
            url: BASE_URL + "user/" + APP_KEY + "/login",
            headers: AUTH_HEADERS,
            data: loginData
        }).then((res) => {
            $("#formLogin input").val("");
            signInUser(res, "Login successful.");
        }).catch(handleAjaxError);
    }
}

function registerUser() {
    let loginForm = $("#formRegister");
    let username = loginForm.find('input[name="username"]').val();
    let password = loginForm.find('input[name="passwd"]').val();
    if (username && password) {

        let registerData = {
            username,
            password
        };
        $.ajax({
            method: "POST",
            url: BASE_URL + "user/" + APP_KEY + "/",
            headers: AUTH_HEADERS,
            data: registerData
        }).then((res) => {
            $("#formRegister input").val("");
            signInUser(res, "Registration successful.");
        }).catch(handleAjaxError);
    }
}

function listBooks() {
    $.ajax({
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        }
    }).then(function (res) {
        showView('viewBooks')
        displayPaginationAndBooks(res.reverse())
    }).catch(handleAjaxError)
}


function createBook() {
    let author = $('#formCreateBook input[name=author]').val()
    let title = $('#formCreateBook input[name=title]').val()
    let description = $('#formCreateBook textarea[name=description]').val()
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
        data: {
            author,
            title,
            description
        },
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        }
    }).then(function (res) {
        listBooks()
        showInfo('Book created.')
    }).catch(handleAjaxError)
}

function deleteBook(book) {
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + book._id,
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        }
    }).then(function () {
        listBooks()
        showInfo('Book deleted.')
    }).catch(handleAjaxError)
}

function loadBookForEdit(book) {
    showView('viewEditBook')
    $('#formEditBook input[name=id]').val(book._id)
    $('#formEditBook input[name=title]').val(book.title)
    $('#formEditBook input[name=author]').val(book.author)
    $('#formEditBook textarea[name=description]').val(book.description)
}

function editBook() {
    let id = $('#formEditBook input[name=id]').val()
    let title = $('#formEditBook input[name=title]').val()
    let author = $('#formEditBook input[name=author]').val()
    let description = $('#formEditBook textarea[name=description]').val()

    $.ajax({
        method: 'PUT',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + id,
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        },
        data: {
            title,
            author,
            description
        }
    }).then(function (res) {
        listBooks()
        showView('viewBooks')
        showInfo('Book edited.')
    })
}

function logoutUser() {
    $.ajax({
        method: "POST",
        url: `${BASE_URL}user/${APP_KEY}/_logout`,
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        }
    }).then((res) => {
        sessionStorage.clear()
        showHomeView()
        showHideMenuLinks()
        showInfo('Logout successful.')
    }).catch(handleAjaxError);

}

function signInUser(res, message) {
    sessionStorage.setItem('username', res.username)
    sessionStorage.setItem('authToken', `Kinvey ${res._kmd.authtoken}`)
    sessionStorage.setItem('userId', res._id)
    showHomeView()
    showHideMenuLinks()
    showInfo(message)
}

function displayPaginationAndBooks(books) {
    let pagination = $('#pagination-demo')
    if (pagination.data("twbs-pagination")) {
        pagination.twbsPagination('destroy')
    }
    pagination.twbsPagination({
        totalPages: Math.ceil(books.length / BOOKS_PER_PAGE),
        visiblePages: 5,
        next: 'Next',
        prev: 'Prev',
        onPageClick: function (event, page) {
            let booksTable = $("#books > table");
            booksTable.find("tr:not(:first-child)").remove();

            let startBook = (page - 1) * BOOKS_PER_PAGE
            let endBook = Math.min(startBook + BOOKS_PER_PAGE, books.length)
            $(`a:contains(${page})`).addClass('active')
            for (let i = startBook; i < endBook; i++) {

                let tr = $("<tr>");
                booksTable.append(tr);
                tr.append($(`<td>${books[i].title}</td>`));
                tr.append($(`<td>${books[i].author}</td>`));
                tr.append($(`<td>${books[i].description}</td>`));
                if (books[i]._acl.creator === sessionStorage.getItem('userId')) {
                    tr.append(
                        $(`<td>`).append(
                            $(`<a href="#">[Edit]</a>`).on('click', function () {
                                loadBookForEdit(books[i])
                            })
                        ).append(
                            $(`<a href="#">[Delete]</a>`).on('click', function () {
                                deleteBook(books[i])
                            })
                        )
                    );
                }
            }
        }
    })
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response)
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error."
    if (response.responseJSON && response.responseJSON.description)
        errorMsg = response.responseJSON.description
    showError(errorMsg)
}
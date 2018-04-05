const BASE_URL = 'https://baas.kinvey.com/'
const APP_KEY = 'kid_B1aKyIA5z'
const APP_SECRET = '47faf52694e44b64ad8d5e72ac22f0fb'
const AUTH_HEADERS = {
    'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)
}

function startApp() {
    showHideMenuLinks()
    showView("viewHome");
    attachEvents();
}

function showView(viewName) {
    $('main > section').hide() // Hide all views
    $('#' + viewName).show() // Show the selected view only
}

function showHideMenuLinks() {
    $("#linkHome").show()
    if (sessionStorage.getItem('authToken') === null) { // No logged in user
        $("#linkLogin").show()
        $("#linkRegister").show()
        $("#linkListAds").hide()
        $("#linkCreateAd").hide()
        $("#linkLogout").hide()
    } else { // We have logged in user
        $("#linkLogin").hide()
        $("#linkRegister").hide()
        $("#linkListAds").show()
        $("#linkCreateAd").show()
        $("#linkLogout").show()
        $('#loggedInUser').text("Welcome, " + sessionStorage.getItem('username') + "!")
    }
}

function attachEvents() {
    $("#linkHome").click(showHomeView);
    $("#linkLogin").click(showLoginView);
    $("#linkRegister").click(showRegisterView);
    $("#linkListAds").click(() => {
        listAdds();
        showView("viewAds");
    });
    $("#linkCreateAd").click(() => {
        $('#formCreateAd').trigger('reset')
        showView("viewCreateAd")
    });
    $("#linkLogout").click(logOutuser);

    $("#formLogin").on('submit', loginUser)
    $("#formRegister").on('submit', registerUser)
    $("#formCreateAd").on('submit', createAdd)
    $("#formEditAd").on('submit', editAdd)
    $("form").on('submit', function (event) {
        event.preventDefault()
    })

    // Bind the info / error boxes
    $("#infoBox, #errorBox").on('click', function () {
        $(this).fadeOut()
    })

    // Attach AJAX "loading" event listener
    $(document).on({
        ajaxStart: function () {
            $("#loadingBox").show()
        },
        ajaxStop: function () {
            $("#loadingBox").hide()
        }
    })
}

function listAdds() {
    $.ajax({
        url: BASE_URL + 'appdata/' + APP_KEY + '/adds',
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        }
    }).then(function (res) {
        showView('viewAds')
        displayAdds(res.reverse());
    }).catch(handleAjaxError)
}

function displayAdds(adds) {
    let adsTable = $("#ads > table");
    adsTable.find("tr:not(:first-child)").remove();

    for (let i = 0; i < adds.length; i++) {

        let tr = $("<tr>");
        adsTable.append(tr);
        tr.append($(`<td>${adds[i].title}</td>`));
        tr.append($(`<td>${adds[i].description}</td>`));
        tr.append($(`<td>${adds[i].publisher}</td>`));
        tr.append($(`<td>${adds[i].dateOfPublishing}</td>`));
        tr.append($(`<td>${Number(adds[i].price)}</td>`));
        if (adds[i]._acl.creator === sessionStorage.getItem('userId')) {
            tr.append(
                $(`<td>`).append(
                    $(`<a href="#">[Edit]</a>`).on('click', function () {
                        loadAddForEdit(adds[i])
                    })
                ).append(
                    $(`<a href="#">[Delete]</a>`).on('click', function () {
                        deleteAdd(adds[i])
                    })
                )
            );
        }
    }
}

function createAdd() {
    let title = $('#formCreateAd input[name=title]').val()
    let description = $('#formCreateAd textarea[name=description]').val()
    let dateOfPublishing = $('#formCreateAd input[name=datePublished]').val()
    let price = Number($('#formCreateAd input[name=price]').val());
    let publisher = sessionStorage.getItem('username');
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/adds',
        data: {
            title,
            description,
            dateOfPublishing,
            price,
            publisher
        },
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        }
    }).then(function (res) {
        listAdds();
        showInfo('Add created.')
    }).catch(handleAjaxError)
}

function loadAddForEdit(add) {
    showView('viewEditAd')
    $('#formEditAd input[name=id]').val(add._id)
    $('#formEditAd input[name=publisher]').val(add.publisher)
    $('#formEditAd input[name=title]').val(add.title)
    $('#formEditAd textarea[name=description]').val(add.description)
    $('#formEditAd input[name=datePublished]').val(add.dateOfPublishing)
    $('#formEditAd input[name=price]').val(add.price)
}

function editAdd() {
    let id = $('#formEditAd input[name=id]').val()
    let publisher = $('#formEditAd input[name=publisher]').val()
    let title = $('#formEditAd input[name=title]').val()
    let description = $('#formEditAd textarea[name=description]').val()
    let dateOfPublishing = $('#formEditAd input[name=datePublished]').val()
    let price = Number($('#formEditAd input[name=price]').val());

    $.ajax({
        method: 'PUT',
        url: BASE_URL + 'appdata/' + APP_KEY + '/adds/' + id,
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        },
        data: {
            title,
            description,
            dateOfPublishing,
            price,
            publisher
        }
    }).then(function (res) {
        listAdds();
        showView("viewAds");
        showInfo('Add edited.')
    })
}

function deleteAdd(add) {
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/adds/' + add._id,
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        }
    }).then(function () {
        listAdds();
        showInfo('Add deleted.')
    }).catch(handleAjaxError)
}

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

function logOutuser() {
    $.ajax({
        method: "POST",
        url: `${BASE_URL}user/${APP_KEY}/_logout`,
        headers: {
            'Authorization': sessionStorage.getItem('authToken')
        }
    }).then((res) => {
        sessionStorage.clear()
        showHomeView();
        showHideMenuLinks();
        showInfo('Logout successful.');
    }).catch(handleAjaxError);

}

function signInUser(res, message) {
    sessionStorage.setItem('username', res.username)
    sessionStorage.setItem('authToken', `Kinvey ${res._kmd.authtoken}`)
    sessionStorage.setItem('userId', res._id)
    showHomeView();
    showHideMenuLinks();
    showInfo(message);
}

function showInfo(message) {
    let infoBox = $('#infoBox')
    infoBox.text(message)
    infoBox.show()
    setTimeout(function () {
        $('#infoBox').fadeOut()
    }, 3000)
}

function showError(errorMsg) {
    let errorBox = $('#errorBox')
    errorBox.text("Error: " + errorMsg)
    errorBox.show()
}

function showHomeView() {
    showView('viewHome')
}

function showLoginView() {
    showView('viewLogin')
    $('#formLogin').trigger('reset')
}

function showRegisterView() {
    $('#formRegister').trigger('reset')
    showView('viewRegister')
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response)
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error."
    if (response.responseJSON && response.responseJSON.description)
        errorMsg = response.responseJSON.description
    showError(errorMsg)
}
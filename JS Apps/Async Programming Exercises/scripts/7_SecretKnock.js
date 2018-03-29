const initialQuery = "Knock Knock.";
const authUrl = "https://baas.kinvey.com/user/kid_BJXTsSi-e/";
const baseUrl = "https://baas.kinvey.com/appdata/kid_BJXTsSi-e/knock?query=";
const auth = `Basic ${btoa("guest:guest")}`;
let requestHeaders = {
    "Authorization": auth,
    "Content-type": "application/json"
}

function attachEvents() {
    logIn();
    $("#knock").click(() => {
        $("h3").show();
        performKnockSequence(initialQuery);
    });
}

function performKnockSequence(query) {
    if (query) {
        $.ajax({
            method: "GET",
            url: baseUrl + query,
            headers: requestHeaders
        }).then((r) => {
            if (r.hasOwnProperty("message") && r.message) {
                console.log(r.answer);
                console.log(r.message);
                performKnockSequence(r.message);
            }
        })
    }
}

function logIn() {
    let body = {
        "username": "guest",
        "password": "guest"
    }
    $.ajax({
        method: "POST",
        url: authUrl + "login",
        headers: requestHeaders,
        data: JSON.stringify(body)
    }).then((r) => {
        $("knock").attr("disabled", false);
        requestHeaders.Authorization = `Kinvey ${r._kmd.authtoken}`;
        console.log("Logged in!");
    }).catch((err) => console.log(`Failed to log in, error: ${err}`));
}
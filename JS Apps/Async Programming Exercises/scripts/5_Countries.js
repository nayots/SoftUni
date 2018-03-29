const baseUrl = "https://baas.kinvey.com/appdata/kid_HkS9g_t9z/";
const auth = `Basic ${btoa("guest:guest")}`;
const requestHeaders = {
    "Authorization": auth,
    "Content-type": "application/json"
}

function attachEvents() {
    $(loadCountries());
    $("#closeCountryView").click(() => {
        $("#countryModal input").val("");
        $("#towns tr:not(:first-child)").remove();
        $("#countryModal").hide();
    })
    $("#updateCountry").click(updateCountry)
    $("#deleteCountry").click(deleteCountry)
    $("#addTown").click(addTown);
    $("#addCountryBtn").click(addCountry);
}

async function updateCountry() {
    let countryId = $("#countryId").val();
    let countryName = $("#countryName").val();
    if (countryId && countryName) {
        $("#updateCountry").attr("disabled", true);
        $("#deleteCountry").attr("disabled", true);
        let data = {
            name: countryName
        }

        await $.ajax({
            method: "PUT",
            url: baseUrl + `countries/${countryId}`,
            headers: requestHeaders,
            data: JSON.stringify(data)
        });
        $("#updateCountry").attr("disabled", false);
        $("#deleteCountry").attr("disabled", false);
        loadCountries();
    }
}

async function deleteCountry() {
    let countryId = $("#countryId").val();
    if (countryId) {
        $("#updateCountry").attr("disabled", true);
        $("#deleteCountry").attr("disabled", true);

        await $.ajax({
            method: "DELETE",
            url: baseUrl + `countries/${countryId}`,
            headers: requestHeaders
        });
        $("#updateCountry").attr("disabled", false);
        $("#deleteCountry").attr("disabled", false);
        $("#countryModal").hide();
        loadCountries();
    }
}

async function addCountry() {
    let countryNameInput = $("#newCountry");
    let countryName = countryNameInput.val();
    let btn = $("#addCountryBtn");
    if (!countryName) {
        return;
    }
    countryNameInput.val("")
    btn.attr("disabled", true);
    let data = {
        name: countryName
    }
    $.ajax({
        method: "POST",
        url: baseUrl + "countries",
        headers: requestHeaders,
        data: JSON.stringify(data)
    }).then((c) => {
        btn.attr("disabled", false);
        $("#countries").append(createCountryItem(c));
    })
}

async function loadCountries() {
    let countries = await $.ajax({
        method: "GET",
        url: baseUrl + "countries",
        headers: requestHeaders
    });
    let countryList = $("#countries");
    $("#countries tr:not(:first-child)").empty();

    for (const countryData of countries) {
        countryList.append(createCountryItem(countryData));
    }

}

async function addTown() {
    let newTownNameInput = $("#newTown");
    let newTownName = newTownNameInput.val();
    let countryId = $("#countryId").val();
    if (!newTownName || !countryId) {
        return;
    }
    $(this).attr("disabled", true);
    newTownNameInput.val("");
    newTownNameInput.attr("disabled", true);

    let data = {
        name: newTownName,
        countryId: countryId
    }

    $.ajax({
        method: "POST",
        url: baseUrl + `towns`,
        headers: requestHeaders,
        data: JSON.stringify(data)
    }).then((t) => {
        $("#towns").append(createTownItem(t));
        $(this).attr("disabled", false);
        newTownNameInput.attr("disabled", false);
    })
}

function createCountryItem(c) {
    let country = $(`<tr data-id="${c._id}"><td class="country">${c.name}</td></tr>`).click(() => {
        loadModalData(country.attr("data-id"));
    });


    return country;
}

function createTownItem(t) {
    let town = $(`<tr data-id="${t._id}"><td><input value="${t.name}"/></td></tr>`)
    let updateBtn = $(`<button>Update</button>`).click(function () {
        let townEle = $(this).parent();
        let townValue = townEle.find("input").val();
        if (!townValue) {
            return
        }
        $(this).attr("disabled", true);
        let data = {
            name: townValue,
            countryId: t.countryId
        };
        $.ajax({
            method: "PUT",
            url: baseUrl + `towns/${t._id}`,
            headers: requestHeaders,
            data: JSON.stringify(data)
        }).then(() => {
            $(this).attr("disabled", false);
        });
    });

    let deleteBtn = $(`<button>Delete</button>`).click(() => {
        deleteBtn.attr("disabled", true);
        $.ajax({
            method: "DELETE",
            url: baseUrl + `towns/${t._id}`,
            headers: requestHeaders
        }).then(() => {
            town.remove();
        });
    });

    town.append(updateBtn)
        .append(deleteBtn);

    return town;
}

async function loadModalData(countryId) {
    $("#countryModal").show();
    $("#countryModal button:not(:contains('Close')), input").attr("disabled", true)

    let countryData = await $.ajax({
        method: "GET",
        url: baseUrl + `countries/?query={"_id": "${countryId}"}`,
        headers: requestHeaders
    });
    if (countryData.length > 0) {
        $("#countryModal button, input").attr("disabled", false)
        $("#countryName").val(countryData[0].name);
        $("#countryId").val(countryData[0]._id);
    }

    let townsData = await $.ajax({
        method: "GET",
        url: baseUrl + `towns/?query={"countryId":"${countryId}"}`,
        headers: requestHeaders
    });
    if (townsData.length > 0) {
        let townsEle = $("#towns");
        for (const town of townsData) {
            townsEle.append(createTownItem(town));
        }
    }
}
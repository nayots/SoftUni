function attachEvents() {
    const baseServiceUrl = "https://judgetests.firebaseio.com/";
    $('#submit').click(getWeather);

    function getWeather() {
        $.get(baseServiceUrl + "locations.json")
            .then(loadForecast)
            .catch(displayError);

        function loadForecast(locations) {
            let location = locations.filter(l => l.name == $('#location').val())[0];

            let todayForecast = $.get(`${baseServiceUrl}forecast/today/${location.code}.json`);
            let upcomingForecast = $.get(`${baseServiceUrl}forecast/upcoming/${location.code}.json`);

            Promise.all([todayForecast, upcomingForecast])
                .then(displayForecast)
                .catch(displayError);

            function displayForecast([today, upcoming]) {
                let icons = {
                    ['Sunny']: "&#x2600;",
                    ['Partly sunny']: "&#x26C5;",
                    ['Overcast']: "&#x2601;",
                    ['Rain']: "&#x2614;",
                    ['Degrees']: "&#176;"
                };

                $('#current')
                    .append($('<span>').addClass("condition symbol").html(icons[today.forecast.condition]))
                    .append($('<span>').addClass("condition")
                        .append($('<span>').addClass("forecast-data").text(today.name))
                        .append($('<span>').addClass("forecast-data").html(`${today.forecast.low}${icons.Degrees}/${today.forecast.high}${icons.Degrees}`))
                        .append($('<span>').addClass("forecast-data").text(today.forecast.condition))
                    );

                for (let forecast of upcoming.forecast) {
                    $('#upcoming')
                        .append($('<span>').addClass("upcoming")
                            .append($('<span>').addClass("symbol").html(icons[forecast.condition]))
                            .append($('<span>').addClass("forecast-data").html(`${forecast.low}${icons.Degrees}/${forecast.high}${icons.Degrees}`))
                            .append($('<span>').addClass("forecast-data").text(forecast.condition))
                        );
                }

                $('#forecast').css("display", "block");
            }
        }

        function displayError(err) {
            $('#forecast').html("Error");
            $('#forecast').css("display", "block");
        }
    }
}

////This does not work in judge because who knows.
// function attachEvents() {
//     const baseUrl = "https://judgetests.firebaseio.com/";
//     const codes = {
//         "Sunny": "&#x2600;",
//         "Partly sunny": "&#x26C5;",
//         "Overcast": "&#x2601;",
//         "Rain": "&#x2614;",
//         "Degrees": "&#176;"
//     };

//     $("#submit").click(getWeather);

//     async function getWeather() {
//         let locationName = $("#location").val();
//         if (!locationName) {
//             handleError();
//             return;
//         }
//         $("#current > span").remove();
//         $("#upcoming > span").remove();
//         let locations = await $.get(baseUrl + "locations.json");
//         let loc = locations.filter(l => l.name == locationName)[0];
//         if (!loc) {
//             handleError();
//             return;
//         }
//         let currentForecast = await $.get(baseUrl + `forecast/today/${loc.code}.json `);
//         let extendedForecast = await $.get(baseUrl + `forecast/upcoming/${loc.code}.json `)

//         if (!forecast || !extendedForecast) {
//             handleError();
//             return;
//         }

//         let forecastEle = $("#forecast");
//         let currentEle = $("#current");
//         currentEle.append(`<span class="condition symbol">${codes[currentForecast.forecast.condition]}</span>`);
//         let conditionEle = $(`<span class="condition"></span>`);
//         conditionEle.append($(`<span class="forecast-data">${currentForecast.name}</span>`));
//         conditionEle.append($(`<span class="forecast-data">${currentForecast.forecast.low}&deg;/${currentForecast.forecast.high}&deg;</span>`));
//         conditionEle.append($(`<span class="forecast-data">${currentForecast.forecast.condition}</span>`));
//         currentEle.append(conditionEle);

//         let upcomingEle = $("#upcoming");
//         for (let i = 0; i < extendedForecast.forecast.length; i++) {
//             const dayForecast = extendedForecast.forecast[i];
//             let dayEle = $(`<span class="upcoming"></span>`);
//             dayEle.append(`<span class="symbol">${codes[dayForecast.condition]} </span>`);
//             dayEle.append($(`<span class="forecast-data">${dayForecast.low}&deg;/${dayForecast.high}&deg;</span>`));
//             dayEle.append($(`<span class="forecast-data">${dayForecast.condition}</span>`));
//             upcomingEle.append(dayEle);
//         }

//         forecastEle.show();

//         function handleError() {
//             $('#forecast').html("Error");
//             $('#forecast').css("display", "block");
//         }
//     }
// }
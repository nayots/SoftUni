function getInfo() {
    let stopId = $("#stopId").val();
    let buses = $("#buses");
    buses.empty();
    if (stopId.length === 0) {
        handleError();
        return;
    }
    let stopNameEle = $("#stopName");
    $.ajax({
        method: "GET",
        url: `https://judgetests.firebaseio.com/businfo/${stopId}.json`
    }).then((res) => {

        stopNameEle.text(res.name);
        for (const key in res.buses) {
            if (res.buses.hasOwnProperty(key)) {
                const element = res.buses[key];
                buses.append($(`<li>Bus ${key} arrives in ${element} minutes</li>`));
            }
        }
    }).catch((err) => {
        handleError();
    });

    function handleError() {
        stopNameEle.text("Error");
    }
}
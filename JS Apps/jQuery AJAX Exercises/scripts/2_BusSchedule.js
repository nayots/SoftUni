function solve() {
    let nextStation = "depot";
    let nextStop = "";

    function depart() {
        $("#depart").prop("disabled", true);
        $.ajax({
            method: "GET",
            url: `https://judgetests.firebaseio.com/schedule/${nextStation}.json`
        }).then((res) => {
            $("#info :nth-child(1)").text(`Next stop ${res.name}`);
            $("#arrive").prop("disabled", false);
            nextStop = res.name;
            nextStation = res.next;
        }).catch((err) => console.log(err));
    }

    function arrive() {
        $("#arrive").prop("disabled", true);
        $("#info :nth-child(1)").text(`Arriving at ${nextStop}`);
        $("#depart").prop("disabled", false);
    }

    return {
        depart,
        arrive
    };
}
let result = solve();
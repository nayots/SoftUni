function attachEventsListeners() {
    document.getElementById("convert").addEventListener("click", convertDistance);

    function convertDistance() {
        let baseValue = Number(document.getElementById("inputDistance").value);
        let selectedFromVal = document.getElementById("inputUnits").value;
        let selectedToVal = document.getElementById("outputUnits").value;
        if (selectedFromVal === selectedToVal) {
            document.getElementById("outputDistance").value = baseValue;
        } else {
            let baseInMeters = 0;
            switch (selectedFromVal) {
                case "km":
                    baseInMeters = baseValue * 1000;
                    break;
                case "m":
                    baseInMeters = baseValue * 1;
                    break;
                case "cm":
                    baseInMeters = baseValue * 0.01;
                    break;
                case "mm":
                    baseInMeters = baseValue * 0.001;
                    break;
                case "mi":
                    baseInMeters = baseValue * 1609.34;
                    break;
                case "yrd":
                    baseInMeters = baseValue * 0.9144;
                    break;
                case "ft":
                    baseInMeters = baseValue * 0.3048;
                    break;
                case "in":
                    baseInMeters = baseValue * 0.0254;
                    break;
            }
            let output = document.getElementById("outputDistance");
            switch (selectedToVal) {
                case "km":
                    output.value = baseInMeters / 1000;
                    break;
                case "m":
                    output.value = baseInMeters / 1;
                    break;
                case "cm":
                    output.value = baseInMeters / 0.01;
                    break;
                case "mm":
                    output.value = baseInMeters / 0.001;
                    break;
                case "mi":
                    output.value = baseInMeters / 1609.34;
                    break;
                case "yrd":
                    output.value = baseInMeters / 0.9144;
                    break;
                case "ft":
                    output.value = baseInMeters / 0.3048;
                    break;
                case "in":
                    output.value = baseInMeters / 0.0254;
                    break;
            }
        }
    }
}
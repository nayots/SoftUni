function attachEventsListeners() {
    let buttons = document.querySelectorAll("input[id$='Btn']");
    for (let i = 0; i < buttons.length; i++) {
        const element = buttons[i];
        element.addEventListener("click", convertTime);
    }

    function convertTime() {
        let secondsBase = 0;
        switch (this.id) {
            case "daysBtn":
                secondsBase = Number(document.getElementById("days").value) * 86400;
                break;

            case "hoursBtn":
                secondsBase = Number(document.getElementById("hours").value) * 3600;
                break;

            case "minutesBtn":
                secondsBase = Number(document.getElementById("minutes").value) * 60;
                break;

            case "secondsBtn":
                secondsBase = Number(document.getElementById("seconds").value);
                break;
        }
        document.getElementById("days").value = secondsBase / 86400;
        document.getElementById("hours").value = secondsBase / 3600;
        document.getElementById("minutes").value = secondsBase / 60;
        document.getElementById("seconds").value = secondsBase;
    }
}
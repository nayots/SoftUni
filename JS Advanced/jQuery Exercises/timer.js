function timer() {
    $("#start-timer").on("click", start);
    $("#stop-timer").on("click", stop);
    let timer;
    let seconds = 0;
    let started = undefined;

    function step() {
        seconds++;
        $("#hours").text(pad(Math.trunc(seconds / 3600)));
        $("#minutes").text(pad(Math.trunc((seconds % 3600) / 60)));
        $("#seconds").text(pad(Math.trunc(((seconds % 3600) % 60) % 60)));
    }

    function start() {
        if (!timer) {
            timer = setInterval(step, 1000);
        }
    }

    function stop() {
        clearInterval(timer);
        timer = undefined;
    }

    function pad(num) {
        if (num <= 9) {
            num = `0${num}`
        }
        return num;
    }
}
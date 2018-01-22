function roadRadar(params) {
    let [speed, area] = params;
    let limit = getLimit(area);

    if (speed > limit) {

        console.log(getWarning(limit, speed));
    }

    function getLimit(area) {
        switch (area) {
            case "motorway":
                return 130;
            case "interstate":
                return 90;
            case "city":
                return 50;
            case "residential":
                return 20;
            default:
                break;
        }
    }

    function getWarning(limit, realSpeed) {
        let overLimit = realSpeed - limit;
        if (overLimit <= 20) {
            return "speeding";
        } else if (overLimit <= 40) {
            return "excessive speeding";
        } else {
            return "reckless driving";
        }
    }
}

// roadRadar([21, "residential"]);
function distanceOverTime(params) {
    let speedA = params[0]*1000;
    let speedB = params[1]*1000;
    let time = (params[2] / 60) / 60;

    let distance1 = speedA * time;
    let distance2 = speedB * time;

    console.log(Math.abs((distance1-distance2)));
}

// distanceOverTime([0, 60, 3600])
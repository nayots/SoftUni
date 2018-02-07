function spiceMustFlow(input) {
    let startingYield = Number(input[0]);
    const depreciation = 10;
    let days = 0;
    let mined = 0;
    while ((startingYield - (depreciation * days)) >= 100) {
        mined += (startingYield - (depreciation * days)) - 26;
        days++;
    }
    mined -= 26;
    console.log(days);
    console.log(Math.max(0, mined));
}

// spiceMustFlow(["111"]);
// spiceMustFlow(["450"]);
// spiceMustFlow(["200"]);
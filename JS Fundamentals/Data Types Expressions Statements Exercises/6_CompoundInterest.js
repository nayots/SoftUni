function compoundInterest(params) {
    let [sum, interest, period, years] = params;
    period = 12/period;
    let compoundInterest = sum*Math.pow((1 + ((interest/100) / period)), (period * years));

    console.log(compoundInterest.toFixed(2));
}

// compoundInterest([1500, 4.3, 3, 6]);
// compoundInterest([100000, 5, 12, 25]);
function round(params) {
    let [num, precision] = params;

    precision = Math.pow(10, precision);
    console.log(Math.round(num * precision)/ precision);
}

round([3.1415926535897932384626433832795, 2]);
round([10.5, 3]);
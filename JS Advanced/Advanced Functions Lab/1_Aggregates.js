function solve(params) {
    params = params.map(Number);
    console.log("Sum = " + params.reduce((a, b) => a + b));
    console.log("Min = " + Math.min(...params));
    console.log("Max = " + Math.max(...params));
    console.log("Product = " + params.reduce((a, b) => a * b));
    console.log("Join = " + params.reduce((a, b) => "" + a + b));
}

// solve([2, 3, 10, 5])
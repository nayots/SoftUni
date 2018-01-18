function binaryLogarithm(numbers) {

    for (let i = 0; i < numbers.length; i++) {
        calculateAndPrint(numbers[i]);
    }

    function calculateAndPrint(n) {
        // let z = 2;
        // let x = n;
        // let y = Math.log(x)/Math.log(z);
        // y = ((Math.round(y*1000000))/1000000);
        console.log(Math.log2(n));
    }
}

// binaryLogarithm([16, 8]);
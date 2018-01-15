function sumNumbers(input) {
    let arr = input.map(Number);
    let sum = arr.reduce((a, b) => a + b, 0);
    let vat = sum * 0.2;
    let total = sum + vat;
    console.log(`${sum}\n${vat}\n${total}`)
}

// sumNumbers([1.2, 2.6,3.5]);
function euclidGCD(num1, num2) {
    var gcd;

    if (num1 === num2) {
        gcd = num1;
    } else if (num1 > num2) {
        gcd = euclidGCD((num1 - num2), num2);
    } else if (num1 < num2) {
        gcd = euclidGCD(num1, (num2 - num1));
    }

    return gcd;
}

console.log('GCD is: ' + euclidGCD(252, 105));
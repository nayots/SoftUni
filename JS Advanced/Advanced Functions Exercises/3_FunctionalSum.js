function add(num) {
    let sum = num;

    function calc(num2) {
        sum += num2;
        return calc;
    }

    calc.toString = function () {
        return sum
    };
    return calc;
}
console.log(add(5)(5)(5))
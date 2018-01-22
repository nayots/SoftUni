function modifyAverage(n) {
    n = n.toString();
    while (findAverage(n) <= 5.00) {
        n += 9;
    }
    console.log(n);

    function findAverage(number) {
        let sum = 0;
        for (let i = 0; i < number.length; i++) {
            sum += parseInt(number[i]);        
        }
        return sum / number.length;
        
    }
}

// modifyAverage(5835);
// modifyAverage(101);
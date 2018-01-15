function stringOfNumbers(n) {
    let num = parseInt(n);
    let result = "";
    for (let i = 1; i <= n; i++) {
        result += `${i}`;
    }
    console.log(result);
}

// stringOfNumbers(10);
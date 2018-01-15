function oddOrEven(n) {
    let result = "invalid";
    
    if (n % 1 === 0) {
        result = n % 2 === 0 ? "even" : "odd";
    }

    console.log(result);
}

// oddOrEven(5);
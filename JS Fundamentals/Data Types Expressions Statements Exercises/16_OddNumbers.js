function oddNumbers(n) {
    for (let index = 1; index <= n; index++) {
        if (index % 2 !== 0) {
            console.log(index);
        }
    }
}

// oddNumbers(5);
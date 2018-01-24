function oddNumbers(params) {
    let result = params.filter((ele, ind) => ind % 2 != 0).map(x => x*2).reverse().join(" ");
    console.log(result);
}

// oddNumbers([10, 15, 20, 25]);
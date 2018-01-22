function calculator(a,b,op) {
    console.log(((a,b,op) => eval(`(${a})${op}(${b})`))(a,b,op));
}

// calculator(2,4, "+");


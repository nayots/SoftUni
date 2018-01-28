function concantAndReverse(params) {
    let result = Array.from(params.join("")).reverse().join("");
    console.log(result);
}
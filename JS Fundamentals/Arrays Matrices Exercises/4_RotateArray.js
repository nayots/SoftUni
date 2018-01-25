function rotate(params) {
    let n = Number(params.pop());

    for (let i = 0; i < n % params.length; i++) {
        params.unshift(params.pop());
    }
    console.log(params.join(" "));
}
function firstAndLast(params) {
    let n = params.shift();
    let first = params.slice(0,Math.min(params.length, n));
    let last = params.slice(Math.max(0, params.length-n));
    console.log(`${first}\n${last}`);
}

// firstAndLast([2,7, 8, 9]);
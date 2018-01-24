function smallestTwo(params) {
    let result = params.sort((a,b) => a - b).slice(0,Math.min(2, params.length)).join(" ");
    console.log(result);
}

// smallestTwo([30, 15, 50, 5]);
function printEveryNEle(params) {
    let n = Number(params.pop());
    for (let i = 0; i < params.length; i+=n) {
        let element = params[i];
        console.log(element);
    }
}

// printEveryNEle([5,20,31,4,20,2]);
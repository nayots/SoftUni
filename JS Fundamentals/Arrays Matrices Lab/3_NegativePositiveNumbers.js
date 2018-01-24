function negativePositive(params) {
    let arr = [];
    for (let index = 0; index < params.length; index++) {
        const element = params[index];
        if (element >= 0) {
            arr.push(element);
        } else {
            arr.unshift(element)
        }
    }

    console.log(arr.join("\n"));
}

// negativePositive([7, -2, 8, 9]);
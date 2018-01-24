function evenPosition(params) {
    return params.filter((ele, ind) => ind % 2 === 0).join(" ");
}

// console.log(evenPosition([20,30,40]));
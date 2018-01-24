function biggestElement(matrix) {
    let sortDesc = (a,b) => b - a;
    let result = matrix.map(m => m.sort(sortDesc)[0]).sort(sortDesc)[0];
    console.log(result);
}
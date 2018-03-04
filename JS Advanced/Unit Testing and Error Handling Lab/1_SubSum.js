function subsum(arr, startIndex, endIndex) {
    if (!Array.isArray(arr)) {
        return NaN;
    }
    startIndex = Number(startIndex);
    startIndex = startIndex < 0 ? 0 : startIndex;
    endIndex = Number(endIndex);
    endIndex = endIndex > (arr.length - 1) ? arr.length - 1 : endIndex;
    arr = arr.map(Number);

    return arr.slice(startIndex, endIndex + 1).reduce((a, b) => a + b, 0);
}

// console.log(subsum([10, 20, 30, 40, 50, 60], 3, 300));
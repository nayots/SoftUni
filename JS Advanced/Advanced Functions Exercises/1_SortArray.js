function solve(arr, sortOrder) {
    return arr.map(Number).sort((a, b) => (sortOrder === "asc" ? a - b : b - a));
}
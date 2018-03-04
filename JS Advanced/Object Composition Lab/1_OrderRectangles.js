function solve(params) {
    params = params.map(i => {
        let obj = {
            width: Number(i[0]),
            height: Number(i[1]),
            area: () => obj.width * obj.height,
            compareTo: function (other) {
                return other.area() === obj.area() ? other.width - obj.width : other.area() - obj.area();
            }
        }

        return obj;
    })

    let results = params.sort((a, b) => a.compareTo(b));
    return results;
}

solve([
    [10, 5],
    [5, 12]
]);
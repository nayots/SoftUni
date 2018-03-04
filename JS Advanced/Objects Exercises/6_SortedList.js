function solve(params) {
    let collection = [];
    return {
        add: function (ele) {
            collection.push(ele);
            this.size++;
            collection = collection.sort((a, b) => a - b);
        },
        remove: function (ind) {
            collection[ind] = undefined;
            collection = collection.filter(i => i !== undefined).sort((a, b) => a - b);
            this.size = collection.length;
        },
        get: function (ind) {
            return collection[ind];
        },
        size: 0
    }
}


// let col = solve();
// console.log(col.size);
// col.add(10);
// console.log(col.size);
// console.log(col.get(0));
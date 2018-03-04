(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };
    Array.prototype.skip = function (n) {
        let results = [];
        for (let i = n; i < this.length; i++) {
            const element = this[i];
            results.push(element);
        }
        return results;
    }
    Array.prototype.take = function (n) {
        let results = [];
        for (let i = 0; i < this.length || i < n; i++) {
            const element = this[i];
            results.push(element);
        }
        return results;
    }
    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b);
    }
    Array.prototype.average = function () {
        return (this.sum() / this.length);
    }
})()
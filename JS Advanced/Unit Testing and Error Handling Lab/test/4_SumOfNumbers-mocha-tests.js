let expect = require("chai").expect;
let sum = require("../4_SumOfNumbers.js").sum;

describe("sum(arr)", function () {
    it("should return 3 for [1,2]", function () {
        expect(sum([1, 2])).to.be.equal(3);
    });
    it("should return 5 for [3,2]", function () {
        expect(sum([3, 2])).to.be.equal(5);
    });
    it("should return 0 for [0,0]", function () {
        expect(sum([0, 0])).to.be.equal(0);
    });
    it("should return 100 for [99,1]", function () {
        expect(sum([99, 1])).to.be.equal(100);
    });
});
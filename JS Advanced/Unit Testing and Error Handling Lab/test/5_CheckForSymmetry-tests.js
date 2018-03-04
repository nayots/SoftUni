let expect = require("chai").expect;
let isSymmetric = require("../5_CheckForSymmetry.js").isSymmetric;

describe("isSymmetric", function () {
    it("should return false for non-array {}", function () {
        expect(isSymmetric({})).to.be.equal(false);
    });
    it("should return false for non-array 1 2 3", function () {
        expect(isSymmetric(1, 2, 3)).to.be.equal(false);
    });
    it("should return false for non-array hello", function () {
        expect(isSymmetric("hello")).to.be.equal(false);
    });
    it("should return false for non-symmetryc array", function () {
        expect(isSymmetric([1, 1, 0])).to.be.equal(false);
    });
    it("should return false for non-symmetryc array", function () {
        expect(isSymmetric([1, 2, 3, 4, 2, 1])).to.be.equal(false);
    });
    it("should return false for non-symmetryc array", function () {
        expect(isSymmetric([-1, 2, 1])).to.be.equal(false);
    });
    it("should return false for non-symmetryc array", function () {
        expect(isSymmetric([1, 2])).to.be.equal(false);
    });
    it("should return true for symmetryc array", function () {
        expect(isSymmetric([1, 1, 1])).to.be.equal(true);
    });
    it("should return true for symmetryc array", function () {
        expect(isSymmetric([1, 0, 1])).to.be.equal(true);
    });
    it("should return true for symmetryc array", function () {
        expect(isSymmetric([0, 1, 0])).to.be.equal(true);
    });
    it("should return true for symmetryc array", function () {
        expect(isSymmetric([0])).to.be.equal(true);
    });
    it("should return true for symmetryc array", function () {
        expect(isSymmetric([5, 'hi', {
            a: 5
        }, new Date(), {
            a: 5
        }, 'hi', 5])).to.be.equal(true);
    });
    it("should return true for symmetryc array", function () {
        expect(isSymmetric([5, 'hi', {
            a: 5
        }, new Date(), {
            X: 5
        }, 'hi', 5])).to.be.equal(false);
    });
})
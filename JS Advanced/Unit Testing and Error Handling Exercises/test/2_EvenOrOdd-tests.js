const expect = require("chai").expect;
const isOddOrEven = require("../2_EvenOrOdd").isOddOrEven;

describe("isOddOrEven", function () {
    it("should return undefined for []", function () {
        expect(isOddOrEven([])).to.be.undefined;
    });
    it("should return undefined for {}}", function () {
        expect(isOddOrEven({})).to.be.undefined;
    });
    it("should return undefined for 10", function () {
        expect(isOddOrEven(10)).to.be.undefined;
    });
    it("should return undefined for new Date(2007,10,10)", function () {
        expect(isOddOrEven(new Date(2007, 10, 10))).to.be.undefined;
    });
    it("should return undefined for null", function () {
        expect(isOddOrEven(null)).to.be.undefined;
    });
    it("should return undefined for undefined", function () {
        expect(isOddOrEven(null)).to.be.undefined;
    });
    it("should return undefined for NaN", function () {
        expect(isOddOrEven(NaN)).to.be.undefined;
    });

    it("should return odd for abc", function () {
        expect(isOddOrEven("abc")).to.be.equal("odd");
    });
    it("should return odd for a", function () {
        expect(isOddOrEven("a")).to.be.equal("odd");
    });
    it("should return odd for abcdefg", function () {
        expect(isOddOrEven("abcdefg")).to.be.equal("odd");
    });

    it("should return even for ", function () {
        expect(isOddOrEven("")).to.be.equal("even");
    });
    it("should return even for aa", function () {
        expect(isOddOrEven("aa")).to.be.equal("even");
    });
    it("should return even for aaaaaa", function () {
        expect(isOddOrEven("aaaaaa")).to.be.equal("even");
    });
    it("should return even for 123456", function () {
        expect(isOddOrEven("123456")).to.be.equal("even");
    });
})
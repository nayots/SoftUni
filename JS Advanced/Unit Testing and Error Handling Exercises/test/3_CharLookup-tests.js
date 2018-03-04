const expect = require("chai").expect;
const lookupChar = require("../3_CharLookup").lookupChar;

describe("lookupChar", function () {
    it("should return undefined for {{},1}", function () {
        expect(lookupChar({}, 1)).to.be.undefined;
    });
    it("should return undefined for {[],1}", function () {
        expect(lookupChar([], 1)).to.be.undefined;
    });
    it("should return undefined for {10,1}", function () {
        expect(lookupChar(10, 1)).to.be.undefined;
    });
    it("should return undefined for {NaN,1}", function () {
        expect(lookupChar(NaN, 1)).to.be.undefined;
    });
    it("should return undefined for {null,1}", function () {
        expect(lookupChar(null, 1)).to.be.undefined;
    });
    it("should return undefined for {3.5,1}", function () {
        expect(lookupChar(3.5, 1)).to.be.undefined;
    });
    it("should return undefined for {undefined,1}", function () {
        expect(lookupChar(undefined, 1)).to.be.undefined;
    });
    it("should return undefined for {asd,1.5}", function () {
        expect(lookupChar("asd", 1.5)).to.be.undefined;
    });
    it("should return undefined for {asd,null}", function () {
        expect(lookupChar("asd", null)).to.be.undefined;
    });
    it("should return undefined for {asd,undefined}", function () {
        expect(lookupChar("asd", undefined)).to.be.undefined;
    });
    it("should return undefined for {asd,null}", function () {
        expect(lookupChar("asd", null)).to.be.undefined;
    });
    it("should return undefined for {asd,NaN}", function () {
        expect(lookupChar("asd", NaN)).to.be.undefined;
    });
    it("should return undefined for {asd,[]}", function () {
        expect(lookupChar("asd", [])).to.be.undefined;
    });

    it("should return Incorrect index for {asd,100}", function () {
        expect(lookupChar("asd", 100)).to.be.equal("Incorrect index");
    });
    it("should return Incorrect index for {a,2}", function () {
        expect(lookupChar("a", 2)).to.be.equal("Incorrect index");
    });
    it("should return Incorrect index for {a,-1}", function () {
        expect(lookupChar("a", -1)).to.be.equal("Incorrect index");
    });
    it("should return Incorrect index for {a,1}", function () {
        expect(lookupChar("a", 1)).to.be.equal("Incorrect index");
    });
    it("should return Incorrect index for {abcdefg,7}", function () {
        expect(lookupChar("abcdefg", 7)).to.be.equal("Incorrect index");
    });

    it("should return correct char for {a,0}", function () {
        expect(lookupChar("a", 0)).to.be.equal("a");
    });
    it("should return correct char for {abcdefg,6}", function () {
        expect(lookupChar("abcdefg", 6)).to.be.equal("g");
    });
    it("should return correct char for {abc,1}", function () {
        expect(lookupChar("abc", 1)).to.be.equal("b");
    });
})
let expect = require("chai").expect;
let rgbToHexColor = require("../6_RGBtoHex").rgbToHexColor;

describe("rgbToHexColor(red,green,blue)", function () {
    it("should return undefined for incorrect value (shit)", function () {
        expect(rgbToHexColor("shit")).to.be.equal(undefined);
    });
    it("should return undefined for incorrect value (asd, 1 ,1)", function () {
        expect(rgbToHexColor("asd", 1, 2)).to.be.equal(undefined);
    });
    it("should return undefined for incorrect value (1, 1 ,1)", function () {
        expect(rgbToHexColor("1", 1, 2)).to.be.equal(undefined);
    });
    it("should return undefined for incorrect value (-1, 1 ,2)", function () {
        expect(rgbToHexColor(-1, 1, 2)).to.be.equal(undefined);
    });
    it("should return undefined for incorrect value (-900, 1 ,1)", function () {
        expect(rgbToHexColor(-900, 1, 2)).to.be.equal(undefined);
    });
    it("should return undefined for incorrect value (10, 1 ,-2)", function () {
        expect(rgbToHexColor(10, 1, -2)).to.be.equal(undefined);
    });
    it("should return undefined for incorrect value (2, 300 ,1)", function () {
        expect(rgbToHexColor(2, 300, 2)).to.be.equal(undefined);
    });

    it("should return #000000 for value (0, 0 ,0)", function () {
        expect(rgbToHexColor(0, 0, 0)).to.be.equal("#000000");
    });
    it("should return #FF9EAA for value (255, 158 ,170)", function () {
        expect(rgbToHexColor(255, 158, 170)).to.be.equal("#FF9EAA");
    });
    it("should return #0C0D0E for value (12, 13, 14)", function () {
        expect(rgbToHexColor(12, 13, 14)).to.be.equal("#0C0D0E");
    });
    it("should return #FFFFFF for value (255, 255, 255)", function () {
        expect(rgbToHexColor(255, 255, 255)).to.be.equal("#FFFFFF");
    });
})
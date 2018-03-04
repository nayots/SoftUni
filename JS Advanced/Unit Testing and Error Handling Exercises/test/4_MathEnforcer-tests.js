const expect = require("chai").expect;
const assert = require("chai").assert;
const mathEnforcer = require("../4_MathEnforcer").mathEnforcer;

describe("mathEnforcer", function () {
    describe("addFive", function () {
        it("should have addFive, subtractTen, sum", function () {
            let keysJoined = Object.keys(mathEnforcer).join(", ");
            let expectedKeysJoined = "addFive, subtractTen, sum";
            assert.equal(keysJoined, expectedKeysJoined);
        });

        it("should return 15 for addFive(10)", function () {
            expect(mathEnforcer.addFive(10)).to.be.equal(15);
        });
        it("should return 5 for addFive(0)", function () {
            expect(mathEnforcer.addFive(0)).to.be.equal(5);
        });
        it("should return 1005 for addFive(1000)", function () {
            expect(mathEnforcer.addFive(1000)).to.be.equal(1005);
        });
        it("should return 0 for addFive(-5)", function () {
            expect(mathEnforcer.addFive(-5)).to.be.equal(0);
        });
        it("should return -5 for addFive(-10)", function () {
            expect(mathEnforcer.addFive(-10)).to.be.equal(-5);
        });
        it("should return 5.5 for addFive(0.5)", function () {
            expect(mathEnforcer.addFive(0.5)).to.be.equal(5.5);
        });

        it("should return undefined for addFive(asd)", function () {
            expect(mathEnforcer.addFive("asd")).to.be.undefined;
        });
        it("should return undefined for addFive([])", function () {
            expect(mathEnforcer.addFive([])).to.be.undefined;
        });
        it("should return undefined for addFive({})", function () {
            expect(mathEnforcer.addFive({})).to.be.undefined;
        });
        it("should return undefined for addFive(null)", function () {
            expect(mathEnforcer.addFive(null)).to.be.undefined;
        });
        it("should return undefined for addFive(NaN)", function () {
            expect(mathEnforcer.addFive(NaN)).to.be.NaN;
        });
        it("should return undefined for addFive(new Date(2007,10,10))", function () {
            expect(mathEnforcer.addFive(new Date(2007, 10, 10))).to.be.undefined;
        });
    });

    describe("subtractTen", function () {
        it("should return 0 for subtractTen(10)", function () {
            expect(mathEnforcer.subtractTen(10)).to.be.equal(0);
        });
        it("should return -10 for subtractTen(0)", function () {
            expect(mathEnforcer.subtractTen(0)).to.be.equal(-10);
        });
        it("should return 1005 for subtractTen(1015)", function () {
            expect(mathEnforcer.subtractTen(1015)).to.be.equal(1005);
        });
        it("should return -15 for subtractTen(-5)", function () {
            expect(mathEnforcer.subtractTen(-5)).to.be.equal(-15);
        });
        it("should return -5 for subtractTen(5)", function () {
            expect(mathEnforcer.subtractTen(5)).to.be.equal(-5);
        });
        it("should return 3.14 for subtractTen(13.4)", function () {
            expect(mathEnforcer.subtractTen(13.14)).to.be.closeTo(3.14, 0.01);
        });
        it("should return -6.86 for subtractTen(13.4)", function () {
            expect(mathEnforcer.subtractTen(3.14)).to.be.closeTo(-6.86, 0.01);
        });


        it("should return undefined for subtractTen(asd)", function () {
            expect(mathEnforcer.subtractTen("asd")).to.be.undefined;
        });
        it("should return undefined for subtractTen([])", function () {
            expect(mathEnforcer.subtractTen([])).to.be.undefined;
        });
        it("should return undefined for subtractTen({})", function () {
            expect(mathEnforcer.subtractTen({})).to.be.undefined;
        });
        it("should return undefined for subtractTen(null)", function () {
            expect(mathEnforcer.subtractTen(null)).to.be.undefined;
        });
        it("should return undefined for subtractTen(NaN)", function () {
            expect(mathEnforcer.subtractTen(NaN)).to.be.NaN;
        });
        it("should return undefined for subtractTen(new Date(2007,10,10))", function () {
            expect(mathEnforcer.subtractTen(new Date(2007, 10, 10))).to.be.undefined;
        });
    });

    describe("sum", function () {
        it("should return undefined for sum(asd, 1)", function () {
            expect(mathEnforcer.sum("asd", 1)).to.be.undefined;
        });
        it("should return undefined for sum([], 1)", function () {
            expect(mathEnforcer.sum([], 1)).to.be.undefined;
        });
        it("should return undefined for sum({}, 1)", function () {
            expect(mathEnforcer.sum({}, 1)).to.be.undefined;
        });
        it("should return undefined for sum(null, 1)", function () {
            expect(mathEnforcer.sum(null, 1)).to.be.undefined;
        });
        it("should return undefined for sum(NaN, 1)", function () {
            expect(mathEnforcer.sum(NaN, 1)).to.be.NaN;
        });
        it("should return undefined for sum(new Date(2007,10,10), 1)", function () {
            expect(mathEnforcer.sum(new Date(2007, 10, 10), 1)).to.be.undefined;
        });

        it("should return undefined for sum(1, asd)", function () {
            expect(mathEnforcer.sum(1, "asd")).to.be.undefined;
        });
        it("should return undefined for sum(1, [])", function () {
            expect(mathEnforcer.sum(1, [])).to.be.undefined;
        });
        it("should return undefined for sum(1, {})", function () {
            expect(mathEnforcer.sum(1, {})).to.be.undefined;
        });
        it("should return undefined for sum(1, null)", function () {
            expect(mathEnforcer.sum(1, null)).to.be.undefined;
        });
        it("should return undefined for sum(1, NaN)", function () {
            expect(mathEnforcer.sum(1, NaN)).to.be.NaN;
        });
        it("should return undefined for sum(1, new Date(2007,10,10))", function () {
            expect(mathEnforcer.sum(1), new Date(2007, 10, 10)).to.be.undefined;
        });

        it("should return 0 for sum(0,0)", function () {
            expect(mathEnforcer.sum(0, 0)).to.be.equal(0);
        });
        it("should return 1000 for sum(995,5)", function () {
            expect(mathEnforcer.sum(995, 5)).to.be.equal(1000);
        });
        it("should return -100 for sum(0,-100)", function () {
            expect(mathEnforcer.sum(0, -100)).to.be.equal(-100);
        });
        it("should return 1 for sum(1,0)", function () {
            expect(mathEnforcer.sum(1, 0)).to.be.equal(1);
        });
        it("should return 2 for sum(0,2)", function () {
            expect(mathEnforcer.sum(0, 2)).to.be.equal(2);
        });
        it("should return -50 for sum(-25,-25)", function () {
            expect(mathEnforcer.sum(-25, -25)).to.be.equal(-50);
        });
        it("should return -30 for sum(50,-80)", function () {
            expect(mathEnforcer.sum(50, -80)).to.be.equal(-30);
        });
        it("should return 0 for sum(2.5,2.5)", function () {
            expect(mathEnforcer.sum(2.5, 2.5)).to.be.equal(5);
        });
        it("should return -0.6 for sum(2.5,-3.1)", function () {
            expect(mathEnforcer.sum(2.5, -3.1)).to.be.equal(2.5 + (-3.1));
        });
        it("should return 0.6 for sum(2.5,-3.1)", function () {
            expect(mathEnforcer.sum(-3.1, 2.5)).to.be.equal((-3.1) + 2.5);
        });
        it("should return 0.0005 for sum(0.0004,0.0001)", function () {
            expect(mathEnforcer.sum(0.0004, 0.0001)).to.be.equal(0.0004 + 0.0001);
        });
        it("should return 0.0004 for sum(0.0005,-0.0001)", function () {
            expect(mathEnforcer.sum(0.0005, -0.0001)).to.be.equal(0.0005 + (-0.0001));
        });
        it("should return -0.0005 for sum(0.0004,0.0001)", function () {
            expect(mathEnforcer.sum(-0.0004, -0.0001)).to.be.equal(-0.0004 + -0.0001);
        });
        it("should return -0.0004 for sum(0.0005,-0.0001)", function () {
            expect(mathEnforcer.sum(-0.0005, 0.0001)).to.be.equal(-0.0005 + 0.0001);
        });

        it("should return 3.14 for sum(4.10,-0.96)", function () {
            let result = mathEnforcer.sum(4.10, -0.96);
            expect(result).to.be.closeTo(3.14, 0.1);
        });
        it("should return -3.14 for sum(-4.10,0.96)", function () {
            let result = mathEnforcer.sum(-4.10, 0.96);
            expect(result).to.be.closeTo(-3.14, 0.1);
        });
        it("should return correct result for floating point parameters", function () {
            expect(mathEnforcer.sum(2.7, 3.4)).to.be.closeTo(6.1, 0.01);
        })
    });
});
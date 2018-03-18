const expect = require("chai").expect;
const PaymentPackage = require("../2_PaymentPackage");


describe("PaymentPackage", function () {
    describe("constructor", function () {
        it("should create an instance for ('testP, 100')", function name() {
            let p = new PaymentPackage("testP", 100);

            expect(p instanceof PaymentPackage).to.be.true;
        });
        it("should create an instance with correct properties for ('testP, 50')", function name() {
            let p = new PaymentPackage("testP", 50);

            expect(p.hasOwnProperty("_name")).to.be.true;
            expect(p.hasOwnProperty("_value")).to.be.true;
            expect(p.hasOwnProperty("_VAT")).to.be.true;
            expect(p.hasOwnProperty("_active")).to.be.true;
        });
        it("should have correct values for ('test3', 60.5)", function name() {
            let p = new PaymentPackage('test3', 60.5);

            expect(p.name).to.be.equal("test3");
            expect(p.value).to.be.closeTo(60.5, 0.01);
            expect(p.VAT).to.be.closeTo(20, 0.01);
            expect(p.active).to.be.true;
            expect(p._active).to.be.true;
            expect(p.VAT).to.be.greaterThan(1);
            expect(p._VAT).to.be.greaterThan(1);
            expect(p.value).to.be.greaterThan(50);
            expect(p._value).to.be.greaterThan(50);
        });
        it("should throw error when initialised with incorrect values", function () {
            let p = null;
            expect(() => p = new PaymentPackage(123, 123)).to.throw(Error);
            expect(() => p = new PaymentPackage("correct", "asd")).to.throw(Error);
            expect(() => p = new PaymentPackage([], 10.50)).to.throw(Error);
            expect(() => p = new PaymentPackage(null, 60.50)).to.throw(Error);
            expect(() => p = new PaymentPackage("ttt", {})).to.throw(Error);
            expect(() => p = new PaymentPackage("tttt", new Date(2010, 10, 10))).to.throw(Error);
            expect(() => p = new PaymentPackage(null, null)).to.throw(Error);
            expect(() => p = new PaymentPackage(undefined, undefined)).to.throw(Error);
            expect(() => p = new PaymentPackage("ok")).to.throw(Error);
            expect(() => p = new PaymentPackage("", 123)).to.throw(Error);
            expect(() => p = new PaymentPackage("asd", -1)).to.throw(Error);
            expect(() => p = new PaymentPackage("asd", -50)).to.throw(Error);
            expect(() => p = new PaymentPackage("", -2)).to.throw(Error);
        })
    });

    describe("name", function () {
        it("should create instance with corrrect name for ('abc', 10)", function () {
            let p = new PaymentPackage("abc", 10);

            expect(p.name).to.be.equal("abc");
            expect(p._name).to.be.equal("abc");
            expect(p.hasOwnProperty("_name")).to.be.true;
        });
        it("should create instance with corrrect name for ('dasdasdasdasdasdas', 10)", function () {
            let p = new PaymentPackage("dasdasdasdasdasdas", 10);

            expect(p.name).to.be.equal("dasdasdasdasdasdas");
            expect(p._name).to.be.equal("dasdasdasdasdasdas");
            expect(p.hasOwnProperty("_name")).to.be.true;
        });
        it("should create instance with corrrect name for ('a', 10)", function () {
            let p = new PaymentPackage("a", 10);

            expect(p.name).to.be.equal("a");
            expect(p._name).to.be.equal("a");
            expect(p.hasOwnProperty("_name")).to.be.true;
        });
    });

    describe("value", function () {
        it("should create instance with corrrect name for ('abc', 10)", function () {
            let p = new PaymentPackage("abc", 10);

            expect(p.value).to.be.closeTo(10, 0.01);
            expect(p._value).to.be.closeTo(10, 0.01);
            expect(p.hasOwnProperty("_value")).to.be.true;
        });
        it("should create instance with corrrect name for ('abc', 0.5)", function () {
            let p = new PaymentPackage("abc", 0.5);

            expect(p.value).to.be.closeTo(0.5, 0.001);
            expect(p._value).to.be.closeTo(0.5, 0.001);
            expect(p.hasOwnProperty("_value")).to.be.true;
        });
        it("should throw error for ('abc', -10)", function () {
            let p = undefined;

            expect(() => p = new PaymentPackage("abc", -10)).to.throw(Error);
        });
    });

    describe("VAT", function () {
        let p = null;
        beforeEach(function () {
            let p = new PaymentPackage("abc", 10);
        });
        it("should have default property VAT with default value", function () {
            expect(p.VAT).to.be.closeTo(20, 0.01);
            expect(p._VAT).to.be.closeTo(20, 0.01);
            expect(p.hasOwnProperty("_VAT")).to.be.true;
        });
        it("should change value for correct input for VAT 30", function () {
            p.VAT = 30;
            expect(p.VAT).to.be.closeTo(30, 0.01);
        });
        it("should change value for correct input for VAT 10.5", function () {
            p.VAT = 10.5;
            expect(p.VAT).to.be.closeTo(10.5, 0.001);
        });
        it("should change value for correct input for VAT 0", function () {
            p.VAT = 0;
            expect(p.VAT).to.be.closeTo(0, 0.001);
        });
        it("should throw error for invalid values for VAT", function () {
            expect(() => p.VAT = -1).to.throw(Error);
            expect(() => p.VAT = -0.1).to.throw(Error);
            expect(() => p.VAT = -0.0001).to.throw(Error);
            expect(() => p.VAT = []).to.throw(Error);
            expect(() => p.VAT = {}).to.throw(Error);
            expect(() => p.VAT = "asd").to.throw(Error);
            expect(() => p.VAT = null).to.throw(Error);
            expect(() => p.VAT = undefined).to.throw(Error);
        })
    });

    describe("active", function () {
        let p = null;
        beforeEach(function () {
            let p = new PaymentPackage("abc", 10);
        });

        it("should have default value when instantiated", function () {
            expect(p.active).to.be.true;
            expect(p._active).to.be.true;
            expect(p.hasOwnProperty("_active")).to.be.true;
        });

        it("should change value for correct input", function () {
            p.active = false;
            expect(p.active).to.be.false;
            expect(p._active).to.be.false;
            p.active = true;
            expect(p.active).to.be.true;
            expect(p._active).to.be.true;
            p.active = false;
            p.active = true;
            p.active = false;
            expect(p.active).to.be.false;
            expect(p._active).to.be.false;
        });
        it("should throw error for invalid values for active", function () {
            expect(() => p.active = -11).to.throw(Error);
            expect(() => p.active = -0.1).to.throw(Error);
            expect(() => p.active = -0.0001).to.throw(Error);
            expect(() => p.active = []).to.throw(Error);
            expect(() => p.active = {}).to.throw(Error);
            expect(() => p.active = "asd").to.throw(Error);
            expect(() => p.active = null).to.throw(Error);
            expect(() => p.active = undefined).to.throw(Error);
        });
    });

    describe("toString", function () {
        it("should return correct value for ('asdasd', 500)", function () {
            let p = new PaymentPackage("asdasd", 500);
            let expectedText = [
                `Package: ${p.name}` + '',
                `- Value (excl. VAT): ${p.value}`,
                `- Value (VAT ${p.VAT}%): ${p.value * (1 + p.VAT / 100)}`
            ].join("\n");
            let actualText = p.toString();

            expect(actualText).to.be.equal(expectedText);
        });
        it("should return correct value for ('heyheyhey', 0.5)", function () {
            let p = new PaymentPackage("heyheyhey", 0.5);
            let expectedText = [
                `Package: ${p.name}` + '',
                `- Value (excl. VAT): ${p.value}`,
                `- Value (VAT ${p.VAT}%): ${p.value * (1 + p.VAT / 100)}`
            ].join("\n");
            let actualText = p.toString();

            expect(actualText).to.be.equal(expectedText);
        });
        it("should return correct value for ('h', 5000)", function () {
            let p = new PaymentPackage("h", 5000);
            let expectedText = [
                `Package: ${p.name}` + '',
                `- Value (excl. VAT): ${p.value}`,
                `- Value (VAT ${p.VAT}%): ${p.value * (1 + p.VAT / 100)}`
            ].join("\n");
            let actualText = p.toString();

            expect(actualText).to.be.equal(expectedText);
        });

        it("should return correct value for ('h', 5000) inactive", function () {
            let p = new PaymentPackage("h", 5000);
            p.active = false;
            p.active = true;
            p.active = false;
            let expectedText = [
                `Package: ${p.name}` + ' (inactive)',
                `- Value (excl. VAT): ${p.value}`,
                `- Value (VAT ${p.VAT}%): ${p.value * (1 + p.VAT / 100)}`
            ].join("\n");
            let actualText = p.toString();

            expect(actualText).to.be.equal(expectedText);
        });
        it("should return correct value for ('123123123', 123) inactive", function () {
            let p = new PaymentPackage("123123123", 123);
            p.active = false;
            p.active = true;
            p.active = false;
            let expectedText = [
                `Package: ${p.name}` + ' (inactive)',
                `- Value (excl. VAT): ${p.value}`,
                `- Value (VAT ${p.VAT}%): ${p.value * (1 + p.VAT / 100)}`
            ].join("\n");
            let actualText = p.toString();

            expect(actualText).to.be.equal(expectedText);
        });
        it("should return correct value for ('123123123', 0.9) inactive", function () {
            let p = new PaymentPackage("123123123", 0.9);
            p.active = false;
            p.active = true;
            p.active = false;
            let expectedText = [
                `Package: ${p.name}` + ' (inactive)',
                `- Value (excl. VAT): ${p.value}`,
                `- Value (VAT ${p.VAT}%): ${p.value * (1 + p.VAT / 100)}`
            ].join("\n");
            let actualText = p.toString();

            expect(actualText).to.be.equal(expectedText);
        });
        it("should return correct value for ('0', 0) inactive", function () {
            let p = new PaymentPackage("0", 0);
            p.active = false;
            p.active = true;
            p.active = false;
            let expectedText = [
                `Package: ${p.name}` + ' (inactive)',
                `- Value (excl. VAT): ${p.value}`,
                `- Value (VAT ${p.VAT}%): ${p.value * (1 + p.VAT / 100)}`
            ].join("\n");
            let actualText = p.toString();

            expect(actualText).to.be.equal(expectedText);
        });
    })
});
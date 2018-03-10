const expect = require("chai").expect;
const Console = require("../5_Console");

describe("console", function () {
    describe("writeLine(string)", function () {
        it("should return 'abc' for writeLine('abc')", function () {
            expect(Console.writeLine("abc")).to.be.equal("abc");
        });
        it("should return 'a' for writeLine('a')", function () {
            expect(Console.writeLine("a")).to.be.equal("a");
        });
        it("should return '' for writeLine('')", function () {
            expect(Console.writeLine("")).to.be.equal("");
        });
        it("should return 'abcd' for writeLine('abcd')", function () {
            expect(Console.writeLine("abcd")).to.be.equal("abcd");
        });
    });

    describe("writeLine(object)", function () {
        it("should return json for writeLine({name: 'gosho', color: 'black'})", function () {
            expect(Console.writeLine({
                name: 'gosho',
                color: 'black'
            })).to.be.equal(JSON.stringify({
                name: 'gosho',
                color: 'black'
            }));
        });
        it("should return json for writeLine({name: 'pesho', color: 'whie'})", function () {
            expect(Console.writeLine({
                name: 'pesho',
                color: 'white'
            })).to.be.equal(JSON.stringify({
                name: 'pesho',
                color: 'white'
            }));
        });
        it("should return json for writeLine({arr: [], color: (a) => a})", function () {
            expect(Console.writeLine({
                arr: [],
                color: (a) => a
            })).to.be.equal(JSON.stringify({
                arr: [],
                color: (a) => a
            }));
        });
        it("should return json for writeLine({name: null, color: undefined})", function () {
            expect(Console.writeLine({
                name: null,
                color: undefined
            })).to.be.equal(JSON.stringify({
                name: null,
                color: undefined
            }));
        });
        it("should return json for writeLine({name: new Map(), color: new Set()})", function () {
            expect(Console.writeLine({
                name: new Map(),
                color: new Set()
            })).to.be.equal(JSON.stringify({
                name: new Map(),
                color: new Set()
            }));
        });
    });

    describe("writeLine(templateString, parameters)", function () {
        it("should throw Error for writeLine([], 1, 2)", function () {
            expect(() => Console.writeLine([], 1, 2)).to.throw(TypeError);
        });

        it("should return 'text 1 2' for writeLine('text {0} {1}', 1, 2)", function () {
            expect(Console.writeLine('text {0} {1}', 1, 2)).to.equal("text 1 2");
        })

        it("should throw RangeError for writeLine('text {0} {1}', 1, 2, 3)", function () {
            expect(() => Console.writeLine('text {0} {1}', 1, 2, 3)).to.throw(RangeError);
        })

        it("should throw RangeError for writeLine('text {0} {1} {2}', 1, 2)", function () {
            expect(() => Console.writeLine('text {0} {1} {2}', 1, 2)).to.throw(RangeError);
        })

        it("should throw RangeError for writeLine('text {0} {1} {12}', 1, 2)", function () {
            expect(() => Console.writeLine('text {0} {1} {12}', 1, 2)).to.throw(RangeError);
        })

        it("should throw RangeError for writeLine('text {0} {2}', 1, 2)", function () {
            expect(() => Console.writeLine('text {0} {2}', 1, 2)).to.throw(RangeError);
        })
    });
})
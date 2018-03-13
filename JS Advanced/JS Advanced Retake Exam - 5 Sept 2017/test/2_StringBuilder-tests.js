const expect = require("chai").expect;
const StringBuilder = require("../2_StringBuilder");

describe("stringBuilder", function () {
    let sb = new StringBuilder();
    describe("constructor", function () {
        beforeEach(function () {
            sb = null;
        });

        it("should create instance for new StringBuilder()", function () {
            sb = new StringBuilder();
            expect(sb).not.equal(null);
            expect(sb._stringArray.length).to.be.equal(0);
            expect(sb._stringArray).not.equal(undefined);
        });
        it("should create instance for new StringBuilder('asd')", function () {
            sb = new StringBuilder('asd');
            expect(sb).not.equal(null);
            expect(sb._stringArray.length).to.be.equal(3);
            expect(sb._stringArray.join("")).to.be.equal("asd");
            expect(sb._stringArray).not.equal(undefined);
        });

        it('has all properties', function () {
            sb = new StringBuilder();
            expect(sb.hasOwnProperty('_stringArray')).to.equal(true, "Missing _stringArray property");
        });

        it('has functions attached to prototype', function () {
            sb = new StringBuilder();
            expect(Object.getPrototypeOf(sb).hasOwnProperty('append')).to.equal(true, "Missing append function");
            expect(Object.getPrototypeOf(sb).hasOwnProperty('prepend')).to.equal(true, "Missing prepend function");
            expect(Object.getPrototypeOf(sb).hasOwnProperty('insertAt')).to.equal(true, "Missing insertAt function");
            expect(Object.getPrototypeOf(sb).hasOwnProperty('remove')).to.equal(true, "Missing remove function");
            expect(Object.getPrototypeOf(sb).hasOwnProperty('toString')).to.equal(true, "Missing toString function");
        });

        it('must initialize data to an empty array', function () {
            sb = new StringBuilder();
            expect(sb._stringArray instanceof Array).to.equal(true, 'Data must be of type array');
            expect(sb._stringArray.length).to.equal(0, 'Data array must be initialized empty');
        });

        it("should throw error if passed argument is not a string", function () {
            expect(() => sb = new StringBuilder(null)).to.throw(TypeError);
            expect(() => sb = new StringBuilder(123)).to.throw(TypeError);
            expect(() => sb = new StringBuilder({})).to.throw(TypeError);
            expect(() => sb = new StringBuilder(new Map())).to.throw(TypeError);
            expect(() => sb = new StringBuilder([])).to.throw(TypeError);
            expect(() => sb = new StringBuilder(NaN)).to.throw(TypeError);
        });
    });

    describe("append", function () {
        beforeEach(function () {
            sb = new StringBuilder();
        });

        it("should append data to inner array for sb.append('asd')", function () {
            sb.append("asd");

            expect(sb._stringArray.join("")).to.equal("asd");
        });

        it("should append data to inner array for sb.append('asd') sb.append('dsa')", function () {
            sb.append("asd");
            sb.append("dsa");

            expect(sb._stringArray.join("")).to.equal("asddsa");
        });

        it("should not change data for sb.append('')", function () {
            sb.append("");

            expect(sb._stringArray.join("")).to.equal("");
        });

        it("should throw error if passed argument is not a string", function () {
            expect(() => sb.append(null)).to.throw(TypeError);
            expect(() => sb.append(123)).to.throw(TypeError);
            expect(() => sb.append({})).to.throw(TypeError);
            expect(() => sb.append(new Map())).to.throw(TypeError);
            expect(() => sb.append([])).to.throw(TypeError);
            expect(() => sb.append(NaN)).to.throw(TypeError);
        });
    });

    describe("prepend", function () {
        beforeEach(function () {
            sb = new StringBuilder();
        });

        it("should prepend data to inner array for sb.prepend('asd')", function () {
            sb.prepend("asd");

            expect(sb._stringArray.join("")).to.equal("asd");
        });

        it("should prepend data to inner array for sb.prepend('asd') sb.prepend('dsa')", function () {
            sb.prepend("asd");
            sb.prepend("dsa");

            expect(sb._stringArray.join("")).to.equal("dsaasd");
        });

        it("should not change data for sb.prepend('')", function () {
            sb.append("");

            expect(sb._stringArray.join("")).to.equal("");
        });

        it("should throw error if passed argument is not a string", function () {
            expect(() => sb.prepend(null)).to.throw(TypeError);
            expect(() => sb.prepend(123)).to.throw(TypeError);
            expect(() => sb.prepend({})).to.throw(TypeError);
            expect(() => sb.prepend(new Map())).to.throw(TypeError);
            expect(() => sb.prepend([])).to.throw(TypeError);
            expect(() => sb.prepend(NaN)).to.throw(TypeError);
            expect(() => sb.prepend(function () {})).to.throw(TypeError);
        });
    });

    describe("insertAt", function () {
        beforeEach(function () {
            sb = new StringBuilder("abcdefg");
        });

        it("should insert change date for insertAt('www',0)", function () {
            sb.insertAt("www", 0);

            expect(sb._stringArray.join("")).to.be.equal("wwwabcdefg");
        });

        it("should insert change date for insertAt('www',7)", function () {
            sb.insertAt("www", 7);

            expect(sb._stringArray.join("")).to.be.equal("abcdefgwww");
        });

        it("should insert change date for insertAt('www',3)", function () {
            sb.insertAt("www", 3);

            expect(sb._stringArray.join("")).to.be.equal("abcwwwdefg");
        });

        it("should insert change date for insertAt('ww',0)", function () {
            sb.insertAt("ww", 0);
            let w = "ww";

            function compare(itemA, itemB) {
                expect(itemA).to.be.equal(itemB);
            }

            compare(...w);
            for (let i = 0; i < sb.toString().length; i++) {
                const element = sb.toString()[i];


            }
            expect(sb._stringArray.join("")).to.be.equal("wwabcdefg");
        });

        it("should not insert change date for insertAt('',3)", function () {
            sb.insertAt("", 3);

            expect(sb._stringArray.join("")).to.be.equal("abcdefg");
        });

        it("should throw error if passed argument is not a string", function () {
            expect(() => sb.insertAt(null, 1)).to.throw(TypeError);
            expect(() => sb.insertAt(123, 1)).to.throw(TypeError);
            expect(() => sb.insertAt({}, 1)).to.throw(TypeError);
            expect(() => sb.insertAt(new Map(), 1)).to.throw(TypeError);
            expect(() => sb.insertAt([], 1)).to.throw(TypeError);
            expect(() => sb.insertAt(NaN, 1)).to.throw(TypeError);
        });
    });

    describe("remove", function () {
        beforeEach(function () {
            sb = new StringBuilder("abcdefg");
        });

        it("should remove data for remove(0,2)", function () {
            sb.remove(0, 2);

            expect(sb._stringArray.join("")).to.be.equal("cdefg");
        })

        it("should remove data for remove(5,2)", function () {
            sb.remove(5, 2);

            expect(sb._stringArray.join("")).to.be.equal("abcde");
        })

        it("should not remove data for remove(5,0)", function () {
            sb.remove(5, 0);

            expect(sb._stringArray.join("")).to.be.equal("abcdefg");
        })
    });

    describe("toString", function () {
        beforeEach(function () {
            sb = new StringBuilder();
        });

        it("should return concatenated value for append('asdasd')", function () {
            sb.append("asdasd");

            expect(sb.toString()).to.be.equal("asdasd");
        });

        it("should return concatenated value for append('asdasd') append('zzz')", function () {
            sb.append("asdasd");
            sb.append("zzz");

            expect(sb.toString()).to.be.equal("asdasdzzz");
        });

        it("should return concatenated value for append('asdasd') prepend('zzz')", function () {
            sb.append("asdasd");
            sb.prepend("zzz");

            expect(sb.toString()).to.be.equal("zzzasdasd");
        });
    });
});
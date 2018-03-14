const expect = require("chai").expect;
const Sumator = require("../2_SumatorClass");

describe("Sumator", function () {
    describe("constructor", function () {
        it("should create an instance with data member", function () {
            let sut = new Sumator();
            expect("data" in sut).to.be.true;
            expect(Array.isArray(sut.data)).to.be.true;
            expect(sut.data.length).to.be.equal(0);
        });
        it("should create an instance with data member that is an array", function () {
            let sut = new Sumator();
            expect(Array.isArray(sut.data)).to.be.true;
            expect(sut.data.length).to.be.equal(0);
        });
        it("should create an instance with data member that is an empty array", function () {
            let sut = new Sumator();
            expect(sut.data.length).to.be.equal(0);
            expect(sut.data).to.be.empty;
        });
    });

    describe("add(item)", function () {
        let sut = new Sumator();
        beforeEach(function () {
            sut = new Sumator();
        })
        it("should add item for add([])", function () {
            sut.add([]);
            expect(Array.isArray(sut.data[0])).to.be.true;
        });
        it("should add item for add(null)", function () {
            sut.add(null);
            expect(sut.data[0]).to.be.null;
        });
        it("should add item for add('gosho')", function () {
            sut.add('gosho');
            expect(sut.data[0]).to.be.equal("gosho");
        });
        it("should add item for add(123)", function () {
            sut.add(123);
            expect(sut.data[0]).to.be.equal(123);
        });
        it("should add multiple items for add(123), add(0.5), add(789)", function () {
            sut.add(123);
            sut.add(0.5);
            sut.add(789);
            expect(sut.data.length).to.be.equal(3);
        })
    });

    describe("sumNums()", function () {
        let sut = new Sumator();
        beforeEach(function () {
            sut = new Sumator();
        })
        it("should sum items", function () {
            sut.add(123);
            sut.add(0.5);
            sut.add(789);
            let sum = sut.sumNums();

            expect(sum).to.be.closeTo(912.5, 0.01);
        });
        it("should return 0 for empty data", function () {
            let sum = sut.sumNums();

            expect(sum).to.be.closeTo(0, 0.0001);
        });
        it("should sum only numbers", function () {
            sut.add("asd");
            sut.add(null);
            sut.add([]);
            sut.add(20);
            sut.add(0.5);

            let sum = sut.sumNums();

            expect(sum).to.be.closeTo(20.5, 0.01);
        })
    });

    describe("removeByFilter()", function () {
        let sut = new Sumator();
        beforeEach(function () {
            sut = new Sumator();
            sut.add("asd");
            sut.add(null);
            sut.add([]);
            sut.add(20);
            sut.add(0.5);
        })
        it("should remove all Arrays", function () {
            sut.removeByFilter((x) => Array.isArray(x));
            expect(sut.data.length).to.be.equal(4);
        });
        it("should remove all null items", function () {
            sut.removeByFilter((x) => x === null);
            expect(sut.data.length).to.be.equal(4);
        });
        it("should remove all strings", function () {
            sut.removeByFilter((x) => typeof x === "string");
            expect(sut.data.length).to.be.equal(4);
        });
        it("should remove all odd numbers", function () {
            sut = new Sumator();
            sut.add(20);
            sut.add(0.5);
            sut.add(0.3);
            sut.removeByFilter((x) => x % 2 !== 0);
            expect(sut.data.length).to.be.equal(1);
        });
        it("should remove all even numbers", function () {
            sut = new Sumator();
            sut.add(20);
            sut.add(30);
            sut.add(0.5);
            sut.add(0.3);
            sut.add(7);
            sut.removeByFilter((x) => x % 2 === 0);
            expect(sut.data.length).to.be.equal(3);
        });
    });

    describe("toString", function () {
        it("should return (empty) for empty data", function () {
            let sut = new Sumator();

            expect(sut.toString()).to.be.equal("(empty)");
        });

        it("should return a string with all the data", function () {
            let sut = new Sumator();
            let items = ["asd", 0.5, 20, 30, {
                name: "pesho"
            }, null, undefined, [1, 2], new Date(2017, 10, 10)];

            items.forEach(element => {
                sut.add(element);
            });

            expect(sut.toString()).to.be.equal(items.join(", "));
        });
    });
});
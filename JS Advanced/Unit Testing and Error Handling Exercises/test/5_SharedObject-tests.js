const expect = require('chai').expect;
const jsdom = require('jsdom-global')();
const $ = require('jquery');
let sharedObject = require("../5_SharedObject").sharedObject;

document.body.innerHTML =
    `<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Shared Object</title>
</head>
<body>
    <div id="wrapper">
        <input type="text" id="name">
        <input type="text" id="income">
    </div>
</body>
</html>
`;

describe("sharedObject", function () {
    before(() => global.$ = $);
    describe("name", function () {
        it("should have property name with null value", function () {
            expect(sharedObject["name"]).to.be.null;
        });
    });
    describe("income", function () {
        it("should have property income with null value", function () {
            expect(sharedObject["income"]).to.be.null;
        });
    });

    describe("changeName(name)", function () {
        it("should not change name for empty string", function () {
            sharedObject.changeName("");
            expect(sharedObject["name"]).to.be.null;
        });
        it("should change name property and field for asd", function () {
            sharedObject.changeName("asd");
            let htmlElementvalue = $("#name").val()
            expect(sharedObject["name"]).to.be.equal("asd");
            expect(htmlElementvalue).to.be.equal("asd");
        });
    });

    describe("changeIncome(income)", function () {
        it("should not change value for 3.14", function () {
            sharedObject.changeIncome(3.14);
            expect(sharedObject["income"]).to.be.null;
        });
        it("should not change value for -10", function () {
            sharedObject.changeIncome(-10);
            expect(sharedObject["income"]).to.be.null;
        });
        it("should not change value for asd", function () {
            sharedObject.changeIncome("asd");
            expect(sharedObject["income"]).to.be.null;
        });
        it("should not change value for []", function () {
            sharedObject.changeIncome([]);
            expect(sharedObject["income"]).to.be.null;
        });

        it("should change value for 10", function () {
            sharedObject.changeIncome(10);
            let incomeHtmlValue = $("#income").val();
            expect(sharedObject["income"]).to.be.equal(10);
            expect(incomeHtmlValue).to.be.equal("10");
        });

        it("should return previous value after calling with 0 parameter", function () {
            sharedObject.changeIncome(50);
            sharedObject.changeIncome(0);
            expect(sharedObject.income).to.equal(50);
            expect($('#income').val()).to.equal("50");
        });
    });

    describe("updateName()", function () {
        beforeEach(function () {
            $("#name").val("");
            sharedObject["name"] = null;
        });
        it("should not change name property for empty name field value", function () {
            sharedObject.updateName();
            expect(sharedObject["name"]).to.be.null;
        });
        it("should change name property for valid name field value", function () {
            $("#name").val("123456");
            sharedObject.updateName();
            expect(sharedObject["name"]).to.be.equal("123456");
        });
    });

    describe("updateIncome()", function () {
        beforeEach(function () {
            $("#income").val("");
            sharedObject["income"] = 0;
        });
        it("should not change income property for empty income field value", function () {
            sharedObject.updateIncome();
            expect(sharedObject["income"]).to.be.equal(0);
        });
        it("should not change income property for asd income field value", function () {
            $("#income").val("asd");
            sharedObject.updateIncome();
            expect(sharedObject["income"]).to.be.equal(0);
        });
        it("should not change income property for 3.14 income field value", function () {
            $("#income").val("3.14");
            sharedObject.updateIncome();
            expect(sharedObject["income"]).to.be.equal(0);
        });
        it("should not change income property for -3.14 income field value", function () {
            $("#income").val("-3.14");
            sharedObject.updateIncome();
            expect(sharedObject["income"]).to.be.equal(0);
        });
        it("should change income property for valid income field value", function () {
            $("#income").val("123456");
            sharedObject.updateIncome();
            expect(sharedObject["income"]).to.be.equal(123456);
        });

        it("should return previous value if value is 0", function () {
            sharedObject.changeIncome(15);
            $("#income").val("0");
            sharedObject.updateIncome();
            expect(sharedObject.income).to.equal(15);
            expect($("#income").val()).to.equal("0");
        });
    });
})
const expect = require("chai").expect;
const jsdom = require("jsdom-global")();
const $ = require("jquery");
let nuke = require("../6_ArmageDOM").nuke;

describe("nuke", function () {
    beforeEach(function () {
        document.body.innerHTML = `
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>ArmageDOM</title>
</head>
<body>
<div id="target">
    <div class="nested target">
        <p>This is some text</p>
    </div>
    <div class="target">
        <p>Empty div</p>
    </div>
    <div class="inside">
        <span class="nested">Some more text</span>
        <span class="target">Some more text</span>
    </div>
</div>
</body>
</html>`;
    });

    before(() => global.$ = $);

    it("should do nothing for same selector", function () {
        let beforeNuke = $('body').html();
        nuke('#target', '#target');
        let afterNuke = $('body').html();
        expect(beforeNuke).to.equal(afterNuke);
    });
    it("should remove one span for ('.target', 'span')", function () {
        let initialTargetLength = $('.target').length;
        let initialSpanLength = $('span').length;
        let initialSpanTargetLength = $('.target').filter('span').length;
        nuke(".target", "span");
        expect($('.target').filter('span').length).to.be.equal(0);
        expect($('span').length).to.equal(initialSpanLength - initialSpanTargetLength);
        expect($('.target').length).to.equal(initialTargetLength - initialSpanTargetLength);
    });
    it("should remove remove p for ('.target', 'p')", function () {
        let initialElementCount = $(".target").length;
        let nestedElementCount = $(".target p").length;
        nuke(".target", "p");
        let afterNukeElementCount = $(".target").length;

        expect(afterNukeElementCount).to.be.equal(initialElementCount - nestedElementCount);
    });
    it("should remove all nested divs for ('#target','div')", function () {
        let initialElementCount = $("#target").length;
        let nestedElementCount = $("#target div").length;
        nuke("#target", "div");
        let afterNukeElementCount = $("#target").length;

        expect(afterNukeElementCount).to.be.equal(initialElementCount - nestedElementCount);
    });
    it("should do nothing for non-existing selectors", function () {
        let beforeHtml = $("#body").html();
        nuke("#asd", "div");
        let afterHtml = $("#body").html();

        expect(beforeHtml).to.be.equal(afterHtml);
    });
    it("should remove two divs for ('div', '.target')", function () {
        let initialTargetLength = $('.target').length;
        let initialDivLength = $('div').length;
        let initialDivTargetLength = $('.target').filter('div').length;
        nuke('div', '.target');
        expect($('.target').filter('div').length).to.be.equal(0);
        expect($('div').length).to.equal(initialDivLength - initialDivTargetLength);
        expect($('.target').length).to.equal(initialTargetLength - initialDivTargetLength);
    });

});
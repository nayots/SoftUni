function solve(params) {
    return (function () {
        let sel1;
        let sel2;
        let resSel;
        return {
            init: function (selector1, selector2, resultSelector) {
                sel1 = $(`${selector1}`);
                sel2 = $(`${selector2}`);
                resSel = $(`${resultSelector}`);
            },
            add: function () {
                resSel.val(Number(sel1.val()) + Number(sel2.val()));
            },
            subtract: function () {
                resSel.val(Number(sel1.val()) - Number(sel2.val()));
            }
        }
    })();
}
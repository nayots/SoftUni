// const $ = require("jquery");

function addProduct() {
    let productNameELe = $("#add-product").find("input[type=text]");
    let productPriceEle = $("#add-product").find("input[type=number]");
    let productName = productNameELe.val();
    let productPrice = productPriceEle.val();

    if (productName.length > 0 && productPrice.length > 0 && !isNaN(productPrice)) {
        let row = $("<tr>");
        row.append($(`<td>${productName}</td>`));
        row.append($(`<td>${productPrice}</td>`));

        $("#product-list").append(row);
        let sumEle = $("#bill > tfoot > tr > td:nth-child(2)");
        let currentSum = Number(sumEle.text());
        let newSum = currentSum + Number(productPrice);
        sumEle.text(newSum);

        productNameELe.val("");
        productPriceEle.val("");
    }
}
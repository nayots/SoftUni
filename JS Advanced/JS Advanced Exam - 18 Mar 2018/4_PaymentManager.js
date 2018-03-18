// const $ = require("jquery");

class PaymentManager {
    constructor(titleParam) {
        this.element = this.createElement(titleParam);
    }

    createElement(titleParam) {
        let table = $("<table>");
        let caption = $(`<caption>${titleParam} Payment Manager</caption>`);

        let thead = $(`
        <thead>
            <tr>
                <th class="name">Name</th>
                <th class="category">Category</th>
                <th class="price">Price</th>
                <th>Actions</th>
            </tr>
        </thead>`);

        let tbody = $(`<tbody class="payments">`);

        let tfoot = $(`<tfoot class="input-data">`);
        let trF = $("<tr>");

        let nameTd = $(`<td><input name="name" type="text"></td>`);
        trF.append(nameTd);

        let categoryTd = $(`<td><input name="category" type="text"></td>`);
        trF.append(categoryTd);

        let priceTd = $(`<td><input name="price" type="number"></td>`);
        trF.append(priceTd);

        let tdAdd = $("<td>");
        let addButton = $("<button>Add</button>").click(() => {
            let name = $(nameTd.children()[0]).val();
            let cat = $(categoryTd.children()[0]).val();
            let price = $(priceTd.children()[0]).val();

            if (name.length > 0 && cat.length > 0 && price.length > 0) {
                let rowToAdd = $("<tr>");
                rowToAdd.append(`<td>${name}</td>`);
                rowToAdd.append(`<td>${cat}</td>`);
                rowToAdd.append(`<td>${Math.round(Number(price) * 100000) / 100000}</td>`);
                let tdDel = $("<td>");
                let delBtn = $("<button>Delete</button>").click(() => {
                    rowToAdd.remove();
                })
                tdDel.append(delBtn);
                rowToAdd.append(tdDel);

                tbody.append(rowToAdd);

                $(nameTd.children()[0]).val("");
                $(categoryTd.children()[0]).val("");
                $(priceTd.children()[0]).val("");
            }
        });
        tdAdd.append(addButton);
        trF.append(tdAdd);
        tfoot.append(trF);

        table.append(caption);
        table.append(thead);
        table.append(tbody);
        table.append(tfoot);

        return table;
    }

    render(id) {
        let ele = this.element;

        $(`#${id}`).append(ele);
    }
}
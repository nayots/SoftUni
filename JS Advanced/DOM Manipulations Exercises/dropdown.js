function addItem() {
    let opt = document.createElement("option");
    opt.textContent = document.getElementById("newItemText").value;
    opt.value = document.getElementById("newItemValue").value;
    document.getElementById("menu").appendChild(opt);
    document.getElementById("newItemText").value = "";
    document.getElementById("newItemValue").value = "";
}
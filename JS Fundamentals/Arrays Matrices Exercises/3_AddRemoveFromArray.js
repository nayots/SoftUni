function addRemove(params) {
    let arr = [];
    let n = 1;

    params.forEach(element => {
        if (element === "add") {
            arr.push(n);
        }
        else if (element === "remove") {
            arr.pop();
        }
        n++;
    });

    console.log(arr.length > 0 ? arr.join("\n") : "Empty");
}
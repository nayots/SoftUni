function sortArray(params) {
    let order = (a,b) => {
        if (a.length != b.length) {
            return a.length - b.length;
        } else {
            return a.toLowerCase() > b.toLowerCase();
        }
    } 

    console.log(params.sort(order).join("\n"));
}
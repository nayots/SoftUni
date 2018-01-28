function extractText(str) {
    let results = [];
    let ind = str.indexOf("(");

    while (ind > -1) {
        let endInd = str.indexOf(")", ind);
        if (endInd !== -1) {
            let word = str.substring(ind + 1, endInd);
            results.push(word);
        } else {
            break;
        }
        ind = str.indexOf("(", endInd + 1);
    }
    console.log(results.join(", "));
}
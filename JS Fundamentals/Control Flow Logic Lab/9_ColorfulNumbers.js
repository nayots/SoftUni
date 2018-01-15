function colorfulNumbers(n) {
    let result = "<ul>\n"
    for (let i = 0; i < n; i++) {
        if (i % 2 === 0) {
            result += `  <li><span style='color:green'>${i+1}</span></li>\n`;
        } else {
            result += `  <li><span style='color:blue'>${i+1}</span></li>\n`;
        }
    }
    result += "</ul>"

    return result;
}

// console.log(colorfulNumbers(10));
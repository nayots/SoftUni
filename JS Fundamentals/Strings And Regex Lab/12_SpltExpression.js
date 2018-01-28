function splitExp(expression) {
    let parts = expression.split(/[\s.();,]+/).filter(e => e !== "");
    console.log(parts.join("\n"));
}

// splitExp('let sum = 4 * 4,b = "wow";');
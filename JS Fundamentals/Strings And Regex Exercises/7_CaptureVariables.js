function captureVariables(input) {
    let pattern = /\b(?:_)([A-Za-z0-9]+)\b/g;
    let matches = input.match(pattern).map(m => m.substr(1));

    console.log(matches.join(","));
}
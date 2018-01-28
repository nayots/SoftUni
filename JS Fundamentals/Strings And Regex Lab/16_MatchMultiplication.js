function matchMultiplication(text) {
    let pattern = /(\-?\d+[.]?\d*)\s*\*\s*(\-?\d+[.]?\d*)/g;

    text = text.replace(pattern, (m, g1, g2) => g1 * g2);

    console.log(text);
}
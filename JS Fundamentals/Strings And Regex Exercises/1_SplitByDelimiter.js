function splitByDelimiter(text, delimiter) {
    console.log(text.split(delimiter).filter(t => t !== "").join("\n"));
}
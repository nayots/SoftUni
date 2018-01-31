function uniqueWords(input) {
    let result = new Set();
    input.join(" ").split(/[^A-Za-z0-9_]/g).filter(w => w !== "").forEach(e => result.add(e.toLowerCase()));

    console.log(Array.from(result.keys()).join(", "));
}

uniqueWords(["Lorem ipsum dolor sit amet, consectetur adipiscing elit. "])
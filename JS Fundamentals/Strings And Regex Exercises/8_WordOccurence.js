function wordOccurence(text, word) {
    let pattern = new RegExp(`\\b${word}\\b`, "gi");

    let matches = text.match(pattern);
    console.log(matches === null ? 0 : matches.length);
}

// wordOccurence("abc", "d")
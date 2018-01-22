function wordsUpper(text) {
    const regex = /\w+/g;
    let m;
    let result = [];
    while ((m = regex.exec(text)) !== null) {
        // This is necessary to avoid infinite loops with zero-width matches
        if (m.index === regex.lastIndex) {
            regex.lastIndex++;
        }
        result.push(m[0].toUpperCase());
    }

    console.log(result.join(", "));
}

// wordsUpper("Hi, how are you?");
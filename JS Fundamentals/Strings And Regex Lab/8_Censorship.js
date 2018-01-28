function censor(text, words) {
    for (const word of words) {
        text = text.replace(new RegExp(word, "g"), "-".repeat(word.length));
    }

    console.log(text);
}

// censor('roses are red, violets are blue', [', violets are', 'red']);
function extractLinks(sentences) {
    let text = sentences.join(" ");
    let pattern = /www\.[A-Za-z0-9-]+(\.[a-z]+)+/g;
    let matches = text.match(pattern);
    if (matches !== null) {
        console.log(matches.join("\n"));
    }
}
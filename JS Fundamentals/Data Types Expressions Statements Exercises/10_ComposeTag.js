function composeTag(params) {
    let [src, alt] = params;

    let tag = `<img src="${src}" alt="${alt}">`;
    console.log(tag);
}

// composeTag(['smiley.gif', 'Smiley Face']);
function occurences(keyword, text) {
    let counter = 0;
    let ind = text.indexOf(keyword);
    while (ind > -1) {
        counter++;
        ind = text.indexOf(keyword, ind + 1);
    }

    return counter;
}
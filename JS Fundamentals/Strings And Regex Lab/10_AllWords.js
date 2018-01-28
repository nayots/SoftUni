function allWords(str) {
    let result = str.split(/\W/g).filter(w => w !== "").join("|");

    console.log(result);
}
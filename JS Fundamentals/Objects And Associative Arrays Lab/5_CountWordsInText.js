function countWordInText(input) {
    let params = input[0].split(/[^A-Za-z0-9_]/g).filter(w => w !== "");
    let result = {};
    for (let i = 0; i < params.length; i++) {
        let prop = params[i];
        if (!result.hasOwnProperty(prop)) {
            result[prop] = 0;
        }
        result[prop] += 1;
    }

    console.log(JSON.stringify(result));
}

countWordInText(["Far too slow, you're far too slow."])
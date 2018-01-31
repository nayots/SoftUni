function countWordInText(input) {
    let params = input[0].split(/[^A-Za-z0-9_]/g).filter(w => w !== "");
    let result = new Map();
    for (let i = 0; i < params.length; i++) {
        let prop = params[i].toLowerCase();
        if (!result.has(prop)) {
            result.set(prop, 0);
        }
        result.set(prop, result.get(prop) + 1);
    }

    Array.from(result.keys()).sort().forEach((k) => console.log(`'${k}' -> ${result.get(k)} times`));
}

// countWordInText(["Far too slow, you're far too slow."])
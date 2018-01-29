function capitalizeWords(text) {
    let pattern = /(\b\w+)/g;

    text = text.replace(pattern, (m, g1) => {
        let result = g1.toLowerCase();
        result = result[0].toUpperCase() + (result.length > 1 ? result.substr(1).toLowerCase() : "");

        return result;
    })

    console.log(text);
}

// capitalizeWords("Capitalize these words");
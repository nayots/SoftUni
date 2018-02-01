function storeCatalogue(params) {
    let products = new Map();
    params.forEach(line => {
        let tokens = line.split(/\s*:\s*/g).filter(t => t !== "");
        let name = tokens[0];
        let price = Number(tokens[1]);
        let letter = name[0];
        if (!products.has(letter)) {
            products.set(letter, new Map());
        }

        products.get(letter).set(name, price);
    });

    let orderedMapKeys = Array.from(products.keys()).sort();
    orderedMapKeys.forEach(mapKey => {
        console.log(`${mapKey}`);
        let value = products.get(mapKey);
        let innerKeys = Array.from(value.keys()).sort();
        innerKeys.forEach(inKey => {
            console.log(`  ${inKey}: ${value.get(inKey)}`)
        });
    });
}

// storeCatalogue(["Appricot : 20.4",
//     "Fridge : 1500",
//     "TV : 1499",
//     "Deodorant : 10",
//     "Boiler : 300",
//     "Apple : 1.25",
//     "Anti-Bug Spray : 15",
//     "T-Shirt : 10"
// ])
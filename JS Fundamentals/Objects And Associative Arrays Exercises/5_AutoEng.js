function autoEng(params) {
    let brands = new Map();
    params.forEach(line => {
        let tokens = line.split(/\s*\|\s*/g).filter(t => t !== "");
        let brandName = tokens[0];
        let model = tokens[1];
        let count = Number(tokens[2]);
        if (!brands.has(brandName)) {
            brands.set(brandName, new Map());
        }
        if (!brands.get(brandName).has(model)) {
            brands.get(brandName).set(model, 0);
        }
        let currentCount = brands.get(brandName).get(model);
        brands.get(brandName).set(model, currentCount + count);
    });

    brands.forEach((v, k) => {
        console.log(k);
        v.forEach((v1, k1) => {
            console.log(`###${k1} -> ${v1}`);
        });
    });
}

// autoEng(["Audi | Q7 | 1000",
//     "Audi | Q6 | 100",
//     "BMW | X5 | 1000",
//     "BMW | X6 | 100",
//     "Citroen | C4 | 123",
//     "Volga | GAZ-24 | 1000000",
//     "Lada | Niva | 1000000",
//     "Lada | Jigula | 1000000",
//     "Citroen | C4 | 22",
//     "Citroen | C5 | 10"
// ])
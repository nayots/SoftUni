function arithmephile(params) {
    params = params.map(Number);

    let indexes = [];

    for (let i = 0; i < params.length; i++) {
        const element = params[i];
        if (element >=0 && element <= 9) {
            indexes.push({index:i, count:element});
        }
    }

    let results = [];
    indexes.forEach(entry => {
        let product = null;
        for (let j = entry.index+1; j < params.length && j <= (entry.index + entry.count); j++) {
            const element = params[j];
            if (product === null) {
                product = element;
                continue;
            }
            product = product * element;
        }
        results.push(product);
    });

    let biggest = results.sort((a,b) => b - a)[0];

    console.log(biggest);
}

arithmephile(["10",
    "20",
    "2",
    "30",
    "44",
    "3",
    "56",
   "20",
    "24",
    ])
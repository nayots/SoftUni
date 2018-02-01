function cappyJuice(params) {
    let bottlesKeys = [];
    let juices = new Map();
    params.forEach(element => {
        let [juice, quantity] = element.split(/\s*=>\s*/g).filter(t => t !== "");
        if (!juices.has(juice)) {
            juices.set(juice, 0);
        }

        juices.set(juice, juices.get(juice) + Number(quantity));
        if (juices.get(juice) >= 1000) {
            if (bottlesKeys.indexOf(juice) === -1) {
                bottlesKeys.push(juice);
            }
        }
    });

    bottlesKeys.forEach(key => {
        console.log(`${key} => ${parseInt(juices.get(key) / 1000)}`);
    });
}

cappyJuice(["Orange => 2000",
    "Peach => 1432",
    "Banana => 450",
    "Peach => 600",
    "Strawberry => 549"
])
function market(params) {
    let result = new Map();
    for (let i = 0; i < params.length; i++) {
        let ele = params[i].split(/\s*->\s*/g).filter(w => w !== "");
        let townName = ele[0];
        let product = ele[1];
        let [count, price] = ele[2].split(/\s*:\s*/g).filter(w => w !== "").map(Number);
        let sum = count * price;
        if (!result.has(townName)) {
            result.set(townName, new Map());
        }
        if (!result.get(townName).has(product)) {
            result.get(townName).set(product, 0);
        }
        let lastTotal = result.get(townName).get(product);
        result.get(townName).set(product, sum + lastTotal);
    }

    Array.from(result.keys()).forEach((k) => {
        console.log(`Town - ${k}`);
        Array.from(result.get(k).keys()).forEach(ik => {
            console.log(`$$$${ik} : ${result.get(k).get(ik)}`);
        });
    });
}

market(["Sofia -> Laptops HP -> 200 : 2000",
    "Sofia -> Raspberry -> 200000 : 1500",
    "Sofia -> Audi Q7 -> 200 : 100000",
    "Montana -> Portokals -> 200000 : 1",
    "Montana -> Qgodas -> 20000 : 0.2",
    "Montana -> Chereshas -> 1000 : 0.3"
])
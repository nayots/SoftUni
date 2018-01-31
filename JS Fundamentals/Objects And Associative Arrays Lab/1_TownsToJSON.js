function townsToJson(input) {
    let [town, lat, lon] = input.shift().split(/\s*\|\s*/g).filter(r => r !== "");

    let results = [];

    input.forEach(element => {
        let [name, la, lo] = element.split(/\s*\|\s*/g).filter(r => r !== "");
        let res = {};
        res[town] = name;
        res[lat] = Number(la);
        res[lon] = Number(lo);

        results.push(res);
    });

    console.log(JSON.stringify(results));
}


// townsToJson(['| Town | Latitude | Longitude |',
//     '| Sofia | 42.696552 | 23.32601 |',
//     '| Beijing | 39.913818 | 116.363625 |'
// ])
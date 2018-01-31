function populationIntown(params) {
    let result = {};
    for (let i = 0; i < params.length; i++) {
        let ele = params[i].split(/\s*<->\s*/g).filter(w => w !== "");
        let townName = ele[0];
        let sumForTown = Number(ele[1]);
        if (!result.hasOwnProperty(townName)) {
            result[townName] = 0;
        }
        result[townName] += sumForTown;
    }

    Object.keys(result).forEach(k => console.log(`${k} : ${result[k]}`));
}
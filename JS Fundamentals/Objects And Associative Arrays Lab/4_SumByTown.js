function sumByTown(params) {
    let result = {};
    for (let i = 0; i < params.length; i += 2) {
        let townName = params[i];
        let sumForTown = Number(params[i + 1]);
        if (!result.hasOwnProperty(townName)) {
            result[townName] = 0;
        }
        result[townName] += sumForTown;
    }

    console.log(JSON.stringify(result));
}

// sumByTown(["Sofia", "20", "Varna", "3", "sofia", "5", "varna", "4"]);
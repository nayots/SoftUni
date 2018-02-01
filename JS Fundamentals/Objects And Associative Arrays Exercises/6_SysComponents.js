function sysComp(params) {
    let results = new Map();
    params.forEach(line => {
        let tokens = line.split(/\s*\|\s*/g).filter(t => t !== "");
        let system = tokens[0];
        let component = tokens[1];
        let subComp = tokens[2];
        if (!results.has(system)) {
            results.set(system, new Map());
        }
        if (!results.get(system).has(component)) {
            results.get(system).set(component, new Map());
        }

        results.get(system).get(component).set(subComp);
    });

    let keysOrder = Array.from(results.keys()).sort((a, b) => {
        let val1 = results.get(a);
        let val2 = results.get(b);

        let val1ComponentCount = Array.from(val1.keys()).length;
        let val2ComponentCount = Array.from(val2.keys()).length;
        if (val1ComponentCount != val2ComponentCount) {
            return val1ComponentCount < val2ComponentCount;
        }
        return a.toLowerCase() > b.toLowerCase();
    })

    keysOrder.forEach(sysKey => {
        console.log(sysKey);
        let currentSystem = results.get(sysKey);
        let compKeysOrdered = Array.from(currentSystem.keys()).sort((a, b) => {
            let val1 = currentSystem.get(a);
            let val2 = currentSystem.get(b);

            let val1ComponentCount = Array.from(val1.keys()).length;
            let val2ComponentCount = Array.from(val2.keys()).length;

            return val1ComponentCount < val2ComponentCount;
        })
        compKeysOrdered.forEach(cKey => {
            console.log(`|||${cKey}`);
            currentSystem.get(cKey).forEach((v, k) => {
                console.log(`||||||${k}`);
            });
        });
    });
}

// sysComp(["SULS | Main Site | Home Page",
//     "SULS | Main Site | Login Page",
//     "SULS | Main Site | Register Page",
//     "SULS | Judge Site | Login Page",
//     "SULS | Judge Site | Submittion Page",
//     "Lambda | CoreA | A23",
//     "SULS | Digital Site | Login Page",
//     "Lambda | CoreB | B24",
//     "Lambda | CoreA | A24",
//     "Lambda | CoreA | A25",
//     "Lambda | CoreC | C4",
//     "Indice | Session | Default Storage",
//     "Indice | Session | Default Security"
// ])
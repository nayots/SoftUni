function planesAirport(params) {
    let airportPlanes = new Set();
    let cities = new Map();

    params.forEach(cmd => {
        let tokens = cmd.split(/\s+/g).filter(w => w != "");
        let plane = tokens[0];
        let city = tokens[1];
        let peopleCount = Number(tokens[2]);
        let action = tokens[3];

        if (action === "land") {
            if (!airportPlanes.has(plane)) {
                airportPlanes.add(plane);
                if (!cities.has(city)) {
                    cities.set(city, [0, 0, new Set()]);
                }
                cities.get(city)[0] += peopleCount;
                cities.get(city)[2].add(plane);
            }
        } else if (action === "depart") {
            if (airportPlanes.has(plane)) {
                airportPlanes.delete(plane);
                if (!cities.has(city)) {
                    cities.set(city, [0, 0, new Set()]);
                }
                cities.get(city)[1] += peopleCount;
                cities.get(city)[2].add(plane);
            }
        }
    });

    let planesLeft = Array.from(airportPlanes.keys()).sort((a, b) => {
        return a.localeCompare(b);
    });
    console.log(`Planes left:`);
    planesLeft.forEach(pln => {
        console.log(`- ${pln}`);
    });

    let townsOrdered = Array.from(cities.entries()).sort((a, b) => {
        if (a[1][0] === b[1][0]) {
            return a[0].localeCompare(b[0]);
        } else {
            return b[1][0] - a[1][0];
        }
    });

    townsOrdered.forEach(town => {
        console.log(town[0]);
        console.log(`Arrivals: ${town[1][0]}`)
        console.log(`Departures: ${town[1][1]}`)
        console.log(`Planes:`);
        Array.from(town[1][2].keys()).sort((a, b) => a.localeCompare(b)).forEach(k => {
            console.log(`-- ${k}`);
        });
    });
}

// planesAirport(["Boeing474 Madrid 300 land", "AirForceOne WashingtonDC 178 land",
//     "Airbus London 265 depart", "ATR72 WashingtonDC 272 land", "ATR72 Madrid 135 depart"
// ]);
// planesAirport(["Airbus Paris 356 land",
//     "Airbus London 321 land", "Airbus Paris 213 depart", "Airbus Ljubljana 250 land"
// ]);
// planesAirport(["RTA72 London 140 land",
//     "RTA72 Brussels 240 depart",
//     "RTA72 Sofia 450 land",
//     "RTA72 Lisbon 240 depart",
//     "RTA72 Berlin 350 land",
//     "RTA72 Otava 201 depart",
//     "RTA72 Haga 350 land",
//     "RTA72 Otava 201 depart",
//     "RTA72 Dortmund 150 land",
//     "RTA72 Montana 243 depart",
//     "RTA72 Monreal 350 land",
//     "RTA72 NewYork 201 depart",
//     "RTA72 Pekin 350 land",
//     "RTA72 Tokyo 201 depart",
//     "RTA72 Warshaw 350 land",
//     "RTA72 Riga 201 depart"
// ])
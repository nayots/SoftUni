function solve(blueprint) {
    const engines = [{
            power: 90,
            volume: 1800
        },
        {
            power: 120,
            volume: 2400
        },
        {
            power: 200,
            volume: 3500
        }
    ];

    function getEngine(power) {
        return engines.filter(e => e.power >= power)[0];
    }

    function getCarriage(type, color) {
        return {
            type: type,
            color: color
        };
    }

    function getWheels(size) {
        let results = [];
        for (let j = 0; j < 4; j++) {
            results.push(Math.trunc(size) % 2 !== 0 ? Math.trunc(size) : Math.trunc(size - 1));
        }

        return results;
    }

    return {
        model: blueprint.model,
        engine: getEngine(blueprint.power),
        carriage: getCarriage(blueprint.carriage, blueprint.color),
        wheels: getWheels(blueprint.wheelsize)
    }
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}))
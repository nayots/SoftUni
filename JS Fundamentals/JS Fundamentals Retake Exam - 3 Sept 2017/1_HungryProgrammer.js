function hungryProgrammer(meals, commands) {
    let eatenCount = 0;

    for (let j = 0; j < commands.length; j++) {
        const comm = commands[j];
        let tokens = comm.split(/\s+/g).filter(f => f !== "");

        if (tokens[0] === "Serve" && tokens.length === 1) {
            if (meals.length > 0) {
                console.log(`${meals.pop()} served!`);
            }
        } else if (tokens[0] === "Eat" && tokens.length === 1) {
            if (meals.length > 0) {
                console.log(`${meals.shift()} eaten`);
                eatenCount++;
            }
        } else if (tokens[0] === "Add" && tokens.length === 2) {
            meals.unshift(tokens[1]);
        } else if (tokens[0] === "Consume" && tokens.length === 3) {
            if (!Number.isNaN(tokens[1]) && !Number.isNaN(tokens[2]) && validIndex(Number(tokens[1])) && validIndex(Number(tokens[2]))) {
                let delCount = (Number(tokens[2]) - Number(tokens[1])) + 1;
                meals.splice(Number(tokens[1]), delCount);
                console.log("Burp!");
                eatenCount += delCount;
            }
        } else if (tokens[0] === "Shift" && tokens.length === 3) {
            if (!Number.isNaN(tokens[1]) && !Number.isNaN(tokens[2]) && validIndex(Number(tokens[1])) && validIndex(Number(tokens[2]))) {
                let temp = meals[Number(tokens[1])];
                meals[Number(tokens[1])] = meals[Number(tokens[2])];
                meals[Number(tokens[2])] = temp;
            }
        } else if (tokens[0] === "End" && tokens.length === 1) {
            break;
        }
    }

    function validIndex(ind) {
        return ind <= (meals.length - 1);
    }

    meals.length === 0 ? console.log("The food is gone") : console.log(`Meals left: ${meals.join(", ")}`);
    console.log(`Meals eaten: ${eatenCount}`)
}

//Serve - pop - {name} served!
//Eat - shift - {name} eaten
//Add - unshift
//Consume - splice {range}
//Shift - {swap ?}
//End

// hungryProgrammer(['chicken', 'steak', 'eggs'], ['Serve',
//     'Eat',
//     'End',
//     'Consume 0 1'
// ])
// hungryProgrammer(['fries', 'fish', 'beer', 'chicken', 'beer', 'eggs'], ['Add spaghetti',
//     'Shift 0 1',
//     'Consume 1 4',
//     'End'
// ])
// hungryProgrammer(['soup', 'spaghetti', 'eggs'], ["Consume 0 2",
//     "Eat",
//     "Eat",
//     "Shift 0 1",
//     "End",
//     "Eat"
// ])
function solve(m, cmds) {
    let matrix = m.map(line => parseMatrixRow(line));
    let polutedBlocks = new Set();
    smog(0); //CHECK POLUTION AT START
    cmds.forEach(command => {
        let cmdTokens = command.split(/\s+/g).filter(w => w !== "");
        let commandName = cmdTokens[0];
        let commandDigit = Number(cmdTokens[1]);
        switch (commandName) {
            case "breeze":
                breeze(commandDigit);
                break;
            case "gale":
                gale(commandDigit);
                break;
            case "smog":
                smog(commandDigit);
                break;

            default:
                break;
        }
    });

    let results = Array.from(polutedBlocks.keys()).sort((a, b) => {
        let [aR, aC] = a.split(/-/g).filter(s => s !== "").map(Number);
        let [bR, bC] = b.split(/-/g).filter(s => s !== "").map(Number);

        if (aR !== bR) {
            return aR - bR;
        }

        return aC - bC;
    });

    if (results.length > 0) {
        console.log(`Polluted areas: ${results.map(e => `[${e}]`).join(", ")}`);
    } else {
        console.log("No polluted areas");
    }

    function smog(smogValue) {
        for (let r = 0; r < matrix.length; r++) {
            for (let c = 0; c < matrix[0].length; c++) {
                let currentValue = matrix[r][c];
                let newValue = (currentValue + smogValue);
                if (newValue >= 50) {
                    polutedBlocks.add(`${r}-${c}`);
                }
                matrix[r][c] = newValue;
            }
        }
    }

    function gale(colIndex) {
        for (let r = 0; r < matrix.length; r++) {
            let newBlockValue = matrix[r][colIndex] - 20;
            newBlockValue = Math.max(0, newBlockValue);
            if (newBlockValue < 50 && polutedBlocks.has(`${r}-${colIndex}`)) {
                polutedBlocks.delete(`${r}-${colIndex}`);
            }
            matrix[r][colIndex] = newBlockValue;
        }
    }

    function breeze(rowIndex) {
        for (let c = 0; c < matrix[rowIndex].length; c++) {
            let newBlockValue = matrix[rowIndex][c] - 15;
            newBlockValue = Math.max(0, newBlockValue);
            if (newBlockValue < 50 && polutedBlocks.has(`${rowIndex}-${c}`)) {
                polutedBlocks.delete(`${rowIndex}-${c}`)
            }
            matrix[rowIndex][c] = newBlockValue;
        }
    }

    function parseMatrixRow(str) {
        return str.split(/\s+/g).filter(r => r !== "").map(Number);
    }
}


// solve([
//     "5 7 72 14 4",
//     "41 35 37 27 33",
//     "23 16 27 42 12",
//     "2 20 28 39 14",
//     "16 34 31 10 24",
// ], ["breeze 1", "gale 2", "smog 25"])

// solve([
//     "5 7 3 28 32",
//     "41 12 49 30 33",
//     "3 16 20 42 12",
//     "2 20 10 39 14",
//     "7 34 4 27 24",
// ], [
//     "smog 11", "gale 3",
//     "breeze 1", "smog 2"
// ])

// solve([
//     "5 7 2 14 4",
//     "21 14 2 5 3",
//     "3 16 7 42 12",
//     "2 20 8 39 14",
//     "7 34 1 10 24",
// ], ["breeze 1", "gale 2", "smog 35"]);
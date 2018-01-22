function dnaHelix(n) {
    let pairs = [
        ["A", "T"],
        ["C", "G"],
        ["T", "T"],
        ["A", "G"],
        ["G", "G"]
    ];
    let fullCircle = parseInt(n / 4);
    let semiCircle = n % 4;

    let firstLine = (x, y) => `**${x}${y}**`;
    let secondLine = (x, y) => `*${x}--${y}*`;
    let thirdLine = (x, y) => `${x}----${y}`;
    let fourthLine = (x, y) => `*${x}--${y}*`;
    let linesPrint = [firstLine, secondLine, thirdLine, fourthLine];


    let currentPairindex = 0;

    for (let i = 0; i < fullCircle; i++) {
        linesPrint.forEach(f => {
            let currentPair = pairs[currentPairindex++];
            currentPairindex = currentPairindex > 4 ? 0 : currentPairindex;
            let left = currentPair[0];
            let right = currentPair[1];
            console.log(f(left, right));
        });
    }

    for (let j = 0; j < semiCircle; j++) {
        let currentPair = pairs[currentPairindex++];
        currentPairindex = currentPairindex > 4 ? 0 : currentPairindex;
        let left = currentPair[0];
        let right = currentPair[1];
        console.log(linesPrint[j](left, right));
    }
}

// dnaHelix(4);
// dnaHelix(10);
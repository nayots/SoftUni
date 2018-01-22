function radioCrystals(params) {
    let target = params[0];
    let chunkz = params.slice(1,params.lenth);

    chunkz.forEach(chunk => {
            chipDown(chunk);
    });
    
    function chipDown(currentChunk) {
        console.log(`Processing chunk ${currentChunk} microns`);
        let counter = 0;
        while (currentChunk / 4 >= target  || currentChunk / 4 === target-1) {
            currentChunk = currentChunk / 4;
            counter++;
        }
        if (counter > 0) {
            console.log(`Cut x${counter}`);
            currentChunk = wash(currentChunk);
        }
        counter = 0;

        while (currentChunk * 0.8 >= target  || currentChunk * 0.8 === target-1) {
            currentChunk = currentChunk * 0.8;
            counter++;
        }
        if (counter > 0) {
            console.log(`Lap x${counter}`);
            currentChunk = wash(currentChunk);
        }
        counter = 0;

        while (currentChunk - 20 >= target || currentChunk - 20 === target-1) {
            currentChunk = currentChunk - 20;
            counter++;
        }
        if (counter > 0) {
            console.log(`Grind x${counter}`);
            currentChunk = wash(currentChunk);
        }
        counter = 0;

        while (currentChunk - 2 >= target || currentChunk - 2 === target-1) {
            currentChunk = currentChunk - 2;
            counter++;
        }
        if (counter > 0) {
            console.log(`Etch x${counter}`);
            currentChunk = wash(currentChunk);
        }
        counter = 0;

        if (currentChunk +1 === target) {
            currentChunk += 1;
            console.log("X-ray x1");
        }

        console.log(`Finished crystal ${currentChunk} microns`);
    }

    function wash(chunk) {
        console.log("Transporting and washing");
        return parseInt(chunk);
    }
}

// radioCrystals([1375,50000]);
// radioCrystals([10,9]);
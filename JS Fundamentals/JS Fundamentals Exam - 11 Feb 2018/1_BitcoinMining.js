function solve(params) {
    const exchangeRateGoldToLeva = 67.51; //For a gram of gold
    const exchangeRateLevaToBitcoin = 11949.16; //For 1 bitcoin
    let goldForEachDay = params.map(Number);
    goldForEachDay.unshift(0);
    let firstGoldDay = NaN;
    let amountOfLeva = 0;
    let amountOBitcoins = 0;

    for (let i = 1; i < goldForEachDay.length; i++) {
        const element = goldForEachDay[i];
        let goldForTheDay = element;
        if (i % 3 === 0) {
            goldForTheDay = element * 0.7;
        }

        let levaForTheDay = goldForTheDay * exchangeRateGoldToLeva;
        amountOfLeva += levaForTheDay;
        if (amountOfLeva >= exchangeRateLevaToBitcoin) {
            let bitcoinsBought = parseInt((amountOfLeva / exchangeRateLevaToBitcoin));
            let levaLeft = amountOfLeva % exchangeRateLevaToBitcoin;

            amountOBitcoins += bitcoinsBought;
            amountOfLeva = levaLeft;

            if (Number.isNaN(firstGoldDay) && bitcoinsBought > 0) {
                firstGoldDay = i;
            }
        }
    }

    console.log(`Bought bitcoins: ${amountOBitcoins}`)
    if (amountOBitcoins > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstGoldDay}`)
    }
    console.log(`Left money: ${amountOfLeva.toFixed(2)} lv.`)
}

solve(["100", "200", "300"]);
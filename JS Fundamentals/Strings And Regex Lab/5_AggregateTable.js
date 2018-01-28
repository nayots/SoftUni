function aggregateTable(towns) {
    let results = [];
    let sum = 0;
    for (let i = 0; i < towns.length; i++) {
        const element = towns[i];
        let [town, money] = element.split("|").filter(t => t !== "").map(t => t.trim());
        results.push(town);
        sum += Number(money);
    }
    console.log(`${results.join(", ")}\n${sum}`)
}
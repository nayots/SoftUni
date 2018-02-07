function buildAWall(workers) {
    workers = workers.map(Number);
    const concretePerCrew = 195;
    const costPer1900Concrete = 1900;
    let concreteUsed = new Map();
    let day = 1;
    let crewsWorking = workers.filter(c => c < 30);

    while (crewsWorking.length > 0) {
        let concreteUsedToday = crewsWorking.length * concretePerCrew;
        concreteUsed.set(day, concreteUsedToday);
        day++;
        crewsWorking = crewsWorking.map(c => c += 1).filter(c => c < 30);
    }

    let concreteEachDay = Array.from(concreteUsed.entries()).map(e => e[1]);

    let totalConcreteCost = concreteEachDay.reduce((a, b) => a + b) * costPer1900Concrete;
    console.log(`${concreteEachDay.join(", ")}\n${totalConcreteCost} pesos`);
}

buildAWall([21, 25, 28]);
buildAWall([17]);
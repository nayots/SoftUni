function solve(kingdomsData, battleData) {
    let kingdoms = new Map();

    class Stats {
        constructor(a, w, l) {
            this.army = a;
            this.wins = w;
            this.loses = l;
        }
    }

    kingdomsData.forEach(kData => {
        if (!kingdoms.has(kData.kingdom)) {
            kingdoms.set(kData.kingdom, new Map());
        }
        if (!kingdoms.get(kData.kingdom).has(kData.general)) {
            kingdoms.get(kData.kingdom).set(kData.general, new Stats(0, 0, 0));
        }

        let st = kingdoms.get(kData.kingdom).get(kData.general);
        st.army += kData.army;
    });

    battleData.forEach(bData => {
        let [kingdomA, generalA, kingdomB, generalB] = bData;

        if (kingdomA !== kingdomB) {

            let generalStatsA = kingdoms.get(kingdomA).get(generalA);
            let generalStatsB = kingdoms.get(kingdomB).get(generalB);
            if (generalStatsA.army > generalStatsB.army) {
                generalStatsA.army = parseInt((generalStatsA.army * 1.1));
                generalStatsB.army = parseInt((generalStatsB.army * 0.9));
                generalStatsA.wins += 1;
                generalStatsB.loses += 1;
            } else if (generalStatsA.army < generalStatsB.army) {
                generalStatsA.army = parseInt((generalStatsA.army * 0.9));
                generalStatsB.army = parseInt((generalStatsB.army * 1.1));
                generalStatsB.wins += 1;
                generalStatsA.loses += 1;
            }
        }
    });

    let results = Array.from(kingdoms.entries()).sort((a, b) => {
        let aWins = Array.from(a[1]).map(e => e[1].wins).reduce((x, y) => x + y);
        let bWins = Array.from(b[1]).map(e => e[1].wins).reduce((x, y) => x + y);
        let aLoses = Array.from(a[1]).map(e => e[1].loses).reduce((x, y) => x + y);
        let bLoses = Array.from(b[1]).map(e => e[1].loses).reduce((x, y) => x + y);
        if (aWins !== bWins) {
            return bWins - aWins;
        }
        if (aLoses !== bLoses) {
            return aLoses - bLoses;
        }

        return a[0].localeCompare(b[0]);
    });

    console.log(`Winner: ${results[0][0]}`);
    Array.from(results[0][1].entries()).sort((a, b) => {
        return b[1].army - a[1].army;
    }).forEach(g => {
        console.log("/\\" + `general: ${g[0]}`);
        console.log(`---army: ${g[1].army}`);
        console.log(`---wins: ${g[1].wins}`);
        console.log(`---losses: ${g[1].loses}`);
    })
}

// solve([{
//         kingdom: "Maiden Way",
//         general: "Merek",
//         army: 5000
//     },
//     {
//         kingdom: "Stonegate",
//         general: "Ulric",
//         army: 4900
//     },
//     {
//         kingdom: "Stonegate",
//         general: "Doran",
//         army: 70000
//     },
//     {
//         kingdom: "YorkenShire",
//         general: "Quinn",
//         army: 0
//     },
//     {
//         kingdom: "YorkenShire",
//         general: "Quinn",
//         army: 2000
//     },
//     {
//         kingdom: "Maiden Way",
//         general: "Berinon",
//         army: 100000
//     }
// ], [
//     ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
//     ["Stonegate", "Ulric", "Stonegate", "Doran"],
//     ["Stonegate", "Doran", "Maiden Way", "Merek"],
//     ["Stonegate", "Ulric", "Maiden Way", "Merek"],
//     ["Maiden Way", "Berinon", "Stonegate", "Ulric"]
// ]);

solve([{
        kingdom: "Stonegate",
        general: "Ulric",
        army: 5000
    },
    {
        kingdom: "YorkenShire",
        general: "Quinn",
        army: 5000
    },
    {
        kingdom: "Maiden Way",
        general: "Berinon",
        army: 1000
    }
], [
    ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
    ["Maiden Way", "Berinon", "YorkenShire", "Quinn"]
])
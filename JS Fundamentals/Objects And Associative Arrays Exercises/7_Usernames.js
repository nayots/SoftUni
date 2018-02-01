function userNames(params) {
    let names = new Set();
    params.forEach(line => {
        names.add(line);
    });

    Array.from(names).sort((a, b) => {
        if (a.length !== b.length) {
            return a.length - b.length;
        }
        return a.localeCompare(b);
    }).forEach(n => console.log(n));
}

// userNames(["Ashton",
//     "Kutcher",
//     "Ariel",
//     "Lilly",
//     "Keyden",
//     "Aizen",
//     "Billy",
//     "Braston"
// ])
// userNames(["Denise",
//     "Ignatius",
//     "Iris",
//     "Isacc",
//     "Indie",
//     "Dean",
//     "Donatello",
//     "Enfuego",
//     "Benjamin",
//     "Biser",
//     "Bounty",
//     "Renard",
//     "Rot"
// ])
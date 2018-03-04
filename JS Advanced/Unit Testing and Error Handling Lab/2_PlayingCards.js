function makeCard(cardFace, cardSuit) {
    const Faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
    const Suits = {
        "S": "\u2660",
        "H": "\u2665",
        "D": "\u2666",
        "C": "\u2663"
    };

    if (!Faces.includes(cardFace))
        throw new Error("Invalid card face: " + cardFace);
    if (!Object.keys(Suits).includes(cardSuit))
        throw new Error("Invalid card suit: " + cardSuit);


    let card = {
        face: cardFace,
        suit: Suits[cardSuit],
        toString: () => `${card.face}${card.suit}`
    }
    return card;
}

// console.log('' + makeCard('A', 'S'));
console.log('' + makeCard('J', 'D'));
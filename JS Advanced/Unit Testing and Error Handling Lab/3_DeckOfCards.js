function printDeckOfCards(cards) {
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

    let result = [];
    for (let i = 0; i < cards.length; i++) {
        const element = cards[i];

        let face = element.substr(0, element.length - 1);
        let suit = element.substr(element.length - 1, 1);
        try {
            result.push(makeCard(face, suit).toString());
        } catch (ex) {
            console.log(`Invalid card: ${element}`);
            return;
        }

    }
    console.log(result.join(" "));
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);
function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this.ribbon = {
                color: ribbonColor,
                length: ribbonLength
            };
        }

        get ribbon() {
            return this._ribbon;
        }
        set ribbon(obj) {
            this._ribbon = obj;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this.text = text;
        }

        get text() {
            return this._text;
        }
        set text(txt) {
            this._text = txt;
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    }
}
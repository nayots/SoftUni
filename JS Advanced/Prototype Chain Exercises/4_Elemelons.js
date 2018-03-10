function solve() {
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw Error("Abstract class cannot be instantiated directly");
            }
            this.weight = weight;
            this.melonSort = melonSort;
            this.element = this.constructor.name.replace("melon", "");
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }
        toString() {
            return `Element: ${this.element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }
    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }
    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }
    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }
    }

    class Melolemonmelon extends Watermelon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = "Water";
        }

        morph() {
            if (this.element == "Water") {
                this.element = "Fire";
            } else if (this.element == "Fire") {
                this.element = "Earth";
            } else if (this.element == "Earth") {
                this.element = "Air";
            } else {
                this.element = "Water";
            }
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Earthmelon,
        Airmelon,
        Melolemonmelon
    }
}
let obj = solve();

let test = new obj.Melolemonmelon(150, "Melo");

test.morph();
test.morph();
console.log(test);
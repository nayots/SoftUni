class Rat {
    constructor(name) {
        this.name = name;
        this.otherRats = [];
    }

    unite(otherRat) {
        if (otherRat instanceof Rat) {
            this.otherRats.push(otherRat);
        }
    }

    getRats() {
        return this.otherRats;
    }

    toString() {
        let result = this.name;
        if (this.otherRats.length > 0) {
            result += "\n";
        }
        this.otherRats.forEach(r => {
            result += `##${r.name}\n`;
        });

        return result;
    }
}

let test = new Rat("Pesho");

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));

console.log(test.toString());
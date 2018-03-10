class Stringer {
    constructor(str, len) {
        this.innerString = str;
        this.innerLength = len;
    }

    increase(length) {
        if (Number.isInteger(length)) {
            this.innerLength += length;
        }
    }
    decrease(length) {
        if (Number.isInteger(length)) {
            this.innerLength -= length;
            this.innerLength = this.innerLength < 0 ? 0 : this.innerLength;
        }
    }

    toString() {
        if (this.innerLength === 0) {
            return "...";
        }
        if (this.innerString.length > this.innerLength) {
            return this.innerString.substr(0, this.innerLength) + "...";
        }
        return this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test
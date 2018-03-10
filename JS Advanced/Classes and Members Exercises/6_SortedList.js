class Collection {
    constructor() {
        this.collection = [];
        this.size = 0;
    }

    add(ele) {
        this.collection.push(ele);
        this.size++;
        this.collection = this.collection.sort((a, b) => a - b);
    }

    remove(ind) {
        this.collection[ind] = undefined;
        this.collection = this.collection.filter(i => i !== undefined).sort((a, b) => a - b);
        this.size = this.collection.length;
    }

    get(ind) {
        return this.collection[ind];
    }
}
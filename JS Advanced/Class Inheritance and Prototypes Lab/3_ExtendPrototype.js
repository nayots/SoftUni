function solve(toExtent) {
    toExtent.prototype.species = "Human";
    toExtent.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}
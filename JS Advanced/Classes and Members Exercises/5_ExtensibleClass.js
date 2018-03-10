(function solve() {
    let id = 0;
    class Extensible {
        constructor() {
            this.id = id++;
        }
        extend(template) {
            for (let prop in template) {
                if (typeof template[prop] == 'function')
                    Extensible.prototype[prop] = template[prop];
                else
                    this[prop] = template[prop];
            }
        }
    }

    return Extensible;
})()
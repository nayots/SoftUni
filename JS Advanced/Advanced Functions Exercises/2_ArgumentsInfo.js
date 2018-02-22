function solve() {
    let counter = new Map();
    for (let i = 0; i < arguments.length; i++) {
        const ar = arguments[i];
        console.log(`${typeof ar}: ${ar}`)
        if (!counter.has(typeof ar)) {
            counter.set(typeof ar, 0);
        }
        counter.set(typeof ar, counter.get(typeof ar) + 1);
    }
    Array.from(counter.entries()).sort((a, b) => b[1] - a[1]).forEach(entry => {
        console.log(`${entry[0]} = ${entry[1]}`);
    });
}

solve({
    name: 'bob'
}, 3.333, 9.999)
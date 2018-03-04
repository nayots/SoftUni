function solve(params) {
    let proc = (function processor() {
        let col = [];

        return {
            add: (ele) => col.push(ele),
            remove: (ele) => col = col.filter(item => item !== ele),
            print: () => console.log(col.join(","))
        }
    })();

    params.forEach(element => {
        let tokens = element.split(/\s+/g).filter(i => i !== "");
        proc[tokens[0]](tokens.length > 1 ? tokens[1] : undefined);
    });
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
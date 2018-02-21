function solve(params) {
    let cmdProc = (function () {
        let str = "";
        return {
            append: (x) => str += x,
            removeStart: (y) => str = str.substring(y),
            removeEnd: (s) => str = str.substr(0, Math.max(str.length - Number(s), 0)),
            print: () => console.log(str)
        }
    })();

    params.forEach(cmd => {
        let [cmdName, arg] = cmd.split(' ');
        cmdProc[cmdName](arg);
    });
}

// solve(['append hello',
//     'append again',
//     'removeStart 3',
//     'removeEnd 4',
//     'print'
// ])
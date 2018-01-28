function empData(params) {
    let pattern = /^([A-Z][a-zA-Z]*)\s+-\s+([1-9][0-9]*)\s+-\s+([a-zA-Z0-9 -]+)$/g;
    params.forEach(element => {
        while (m = pattern.exec(element)) {
            console.log(`Name: ${m[1]}\nPosition: ${m[3]}\nSalary: ${m[2]}`);
        }
    });
}
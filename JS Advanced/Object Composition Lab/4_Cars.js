function solve(params) {
    let processor = (function () {
        let objects = {};

        function create(name, parent) {
            if (parent === undefined) {
                objects[name] = {};
            } else {
                objects[name] = Object.create(objects[parent]);
            }
        }

        function set(name, key, value) {
            objects[name][key] = value;
        }

        function print(name) {
            let obj = objects[name];
            let keys = Object.keys(obj);
            let result = [];
            for (const key of keys) {
                result.push(`${key}:${obj[key]}`);
            }
            let proto = Object.getPrototypeOf(obj);
            while (proto !== null && proto !== undefined) {
                for (const k of Object.keys(proto)) {
                    result.push(`${k}:${obj[k]}`);
                }
                proto = Object.getPrototypeOf(proto);
            }

            console.log(result.join(", "));
        }

        return {
            create,
            set,
            print
        };
    })();

    params.forEach(command => {
        let tokens = command.split(/\s+/g).filter(i => i !== "" && i !== "inherit");
        processor[tokens.shift()](...tokens);
    });
}

solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
])
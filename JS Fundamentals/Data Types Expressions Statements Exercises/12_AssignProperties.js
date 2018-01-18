function assignProps(params) {
    let obj = {};
    obj[params[0]] = params[1];
    obj[params[2]] = params[3];
    obj[params[4]] = params[5];

    console.log(obj);
}

assignProps(['name', 'Pesho', 'age', '23', 'gender', 'male']);
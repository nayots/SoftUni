const fs = require("fs");

let storageCollection = {};

module.exports.storage = {};

module.exports.storage.put = (key, value) => {
    if (!(typeof key == "string") || storageCollection.hasOwnProperty(key)) {
        throw new Error("Invalid key!");
    }
    storageCollection[key] = value;
}

module.exports.storage.get = (key) => {
    if (!(typeof key == "string") || !storageCollection.hasOwnProperty(key)) {
        throw new Error("Invalid key!");
    }
    return storageCollection[key];
}

module.exports.storage.getAll = () => {
    if (Object.keys(storageCollection).length === 0) {
        return "Collection is empty!";
    } else {
        return storageCollection;
    }
}

module.exports.storage.update = (key, newValue) => {
    if (!(typeof key == "string") || !storageCollection.hasOwnProperty(key)) {
        throw new Error("Invalid key!");
    }
    storageCollection[key] = newValue;
}

module.exports.storage.delete = (key) => {
    if (!(typeof key == "string") || !storageCollection.hasOwnProperty(key)) {
        throw new Error("Invalid key!");
    }
    delete storageCollection[key];
}

module.exports.storage.clear = () => {
    storageCollection = {};
}

module.exports.storage.save = (callback) => {
    let dataJson = JSON.stringify(storageCollection, null, "\t");

    fs.writeFile("./storage.json", dataJson, (err) => {
        if (err) {
            console.log(err);
            return;
        }
        callback();
    });
}

module.exports.storage.load = (callback) => {
    fs.exists("./storage.json", (exists) => {
        if (exists) {
            fs.readFile("./storage.json", "utf-8", (err, dataJson) => {
                if (err) {
                    console.log(err);
                    return;
                }
                let data = JSON.parse(dataJson);
                if (Object.keys(data).length > 0) {
                    storageCollection = data;
                }

                callback();
            });
        } else {
            fs.writeFile("./storage.json", JSON.stringify({}, null, "\t"), (err) => {
                console.log(err);
                return;
            })
            callback();
        }
    })
}
function heroicInventory(params) {
    let heroData = [];

    params.forEach(element => {
        let tokens = element.split(/\s*\/\s*/g).filter(t => t !== "");
        let name = tokens[0];
        level = Number(tokens[1]);
        items = [];
        if (tokens.length > 2) {
            items = tokens[2].split(/\s*,\s*/g).filter(t => t !== "");
        }
        let obj = {};
        obj.name = name;
        obj.level = level;
        obj.items = items;
        heroData.push(obj);
    });

    console.log(JSON.stringify(heroData));
}
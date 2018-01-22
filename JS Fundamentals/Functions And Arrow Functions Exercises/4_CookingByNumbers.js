function cookingByNumbers(params) {
    let num = params[0];
    let commands = params.slice(1,params.lenght);
    
    let chop = (x) => x / 2;
    let dice = (x) => Math.sqrt(x);
    let spice = (x) => x + 1;
    let bake = (x) => x * 3;
    let fillet = (x) => x * 0.8;

    commands.forEach(element => {
        num = eval(`${element}(num)`);
        console.log(num);
    });
}

// cookingByNumbers([32, "chop", "chop", "chop", "chop", "chop"]);
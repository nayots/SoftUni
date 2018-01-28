function bill(params) {
    let goods = [];
    let sum = 0;
    for (let i = 0; i < params.length; i += 2) {
        const product = params[i];
        const price = Number(params[i + 1]);
        goods.push(product);
        sum += price;
    }
    console.log(`You purchased ${goods.join(", ")} for a total sum of ${sum}`);
}
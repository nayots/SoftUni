function fruitOrVegetable(product) {
    let fruits = [ "banana", "apple", "kiwi", "cherry", "lemon", "grapes", "peach"];
    let vegetables = ["tomato", "cucumber", "pepper", "onion", "garlic", "parsley"];

    let isFruit = fruits.indexOf(product) !== -1;
    let isVegetable = vegetables.indexOf(product) !== -1;

    if (isFruit || isVegetable) {
        console.log( isFruit ? "fruit" : "vegetable")
    } else {
        console.log("unknown");
    }
}

// fruitOrVegetable("banana");
// fruitOrVegetable("cucumber");
// fruitOrVegetable("pizza");
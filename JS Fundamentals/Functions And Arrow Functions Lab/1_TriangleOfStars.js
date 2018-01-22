function triangleOfStars(n) {
    printStars = (count) => console.log("*".repeat(count));
    for (let i = 1; i <= n; i++) {
        printStars(i);                
    }
    for (let j = n-1; j > 0; j--) {
        printStars(j)
    }
}

triangleOfStars(1);
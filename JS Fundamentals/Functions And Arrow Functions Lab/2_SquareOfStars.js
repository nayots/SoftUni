function squareOfStars(n = 5) {
    printStars = (count) => console.log("* ".repeat(count));
    for (let i = 0; i < n; i++) {
       printStars(n);  
    }
}

// squareOfStars();
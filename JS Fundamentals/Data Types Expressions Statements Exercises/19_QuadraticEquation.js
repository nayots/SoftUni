function quadraticEquation(a, b, c) {
    var result = (-1 * b + Math.sqrt(Math.pow(b, 2) - (4 * a * c))) / (2 * a);
    var result2 = (-1 * b - Math.sqrt(Math.pow(b, 2) - (4 * a * c))) / (2 * a);

    if (result < result2) {
        console.log(result);
        console.log(result2);
    }
    else if(result === result2){
        console.log(result);
    }
    else if (isNaN(result) && isNaN(result2)) {
        console.log("no");
    }
    else{
        console.log(result2);
        console.log(result);
    }
}

// quadraticEquation(5, 2 , 1);
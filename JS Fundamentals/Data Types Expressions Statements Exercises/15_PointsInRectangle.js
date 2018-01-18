function pointInRectangle(params) {
    let [x, y, xMin, xMax, yMin, yMax ] = params;
    if (x >= xMin && x <= xMax && y >= yMin && y <= yMax) {
        console.log("inside");
    } else {
        console.log("outside");        
    }
}
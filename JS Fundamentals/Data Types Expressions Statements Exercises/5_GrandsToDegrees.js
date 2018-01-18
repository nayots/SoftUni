function gradsToDegrees(grad) {
    let degrees = grad * 0.9;
    
    degrees = degrees % 360;
    degrees = degrees < 0 ? (360 + degrees) : degrees;
    console.log(degrees);
}

// gradsToDegrees(100);
// gradsToDegrees(400);
// gradsToDegrees(850);
// gradsToDegrees(-50);
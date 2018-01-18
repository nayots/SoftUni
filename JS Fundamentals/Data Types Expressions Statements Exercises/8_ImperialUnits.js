function imperialUnits(inches) {
    let feet = inches / 12;

    console.log(`${parseInt(feet)}'-${inches%12}"`);
}

// imperialUnits(36);
// imperialUnits(55);
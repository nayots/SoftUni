function matchDates(params) {

    let pattern = /\b([0-9]{1,2})-([A-Z][a-z]{2})-(\d{4})\b/g;
    params.forEach(element => {
        while (match = pattern.exec(element)) {
            console.log(`${match[0]} (Day: ${match[1]}, Month: ${match[2]}, Year: ${match[3]})`);
        }
    });
}
function solve(textDoc) {
    const surveyContentRegex = /<svg>(.*?)<\/svg>/g;
    const innerSurveyDataRegex = /<cat>(<text>.*?\[(.+?)\].*?<\/text>)<\/cat>[^<\/>]*?<cat>(.+?)<\/cat>/g;
    const votesRegex = /<g><val>([1-9]|10)<\/val>([1-9][0-9]*)<\/g>/g;

    let category = "";
    let votesCounter = 0;
    let votesSum = 0;

    let hasData = false;
    let validFormat = true;
    while ((m = surveyContentRegex.exec(textDoc)) !== null) {
        hasData = true;
        let survData = innerSurveyDataRegex.exec(m[1]);
        if (survData !== null) {
            category = survData[2];
            let votes = survData[3];
            while ((v = votesRegex.exec(votes))) {
                let ratingValue = Number(v[1]);
                let ratingsCount = Number(v[2]);
                votesCounter += ratingsCount;
                votesSum += (ratingsCount * ratingValue);
            }
        } else {
            validFormat = false;
            break;
        }
    }

    if (hasData) {
        if (validFormat) {
            let average = (votesSum / votesCounter).toFixed(2);
            average = parseFloat(average);
            console.log(`${category}: ${average}`)
        } else {
            console.log("Invalid format");
        }
    } else {
        console.log("No survey found");
    }
}

// solve("<p>Some random text</p><svg><cat><text>How do you rate our food? [Food - General]</text></cat><cat><g><val>1</val>0</g><g><val>2</val>1</g><g><val>3</val>3</g><g><val>4</val>10</g><g><val>5</val>7</g></cat></svg><p>Some more random text</p>");
// solve("<svg><cat><text>How do you rate the special menu? [Food - Special]</text></cat> <cat><g><val>1</val>5</g><g><val>5</val>13</g><g><val>10</val>22</g></cat></svg>");
// solve("<p>How do you suggest we improve our service?</p><p>More tacos.</p><p>It's great, don't mess with it!</p><p>I'd like to have the option for delivery</p>");
// solve("<svg><cat><text>Which is your favourite meal from our selection?</text></cat><cat><g><val>Fish</val>15</g><g><val>Prawns</val>31</g><g><val>Crab Langoon</val>12</g><g><val>Calamari</val>17</g></cat></svg>");
// solve("<p>Some random text</p> <svg> <cat><text>[Thingy] Stuff around?</text></cat> <cat> <g><val>6</val>3</g> <g><val>8</val>3</g> <g><val>10</val>3</g> </cat> </svg> <p>Some more random text</p>");
function scoreToHtml(input) {
    let data = JSON.parse(input);

    let escape = (x) => x.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/\"/g, "&quot;").replace(/'/g, "&#39;");
    let result = "<table>\n";
    result += "  <tr><th>name</th><th>score</th></tr>\n";
    for (const item of data) {
        result += `  <tr><td>${escape(item.name)}</td><td>${Number(item.score)}</td></tr>\n`
    }

    result += "</table>";
    console.log(result);
}

scoreToHtml('[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]');
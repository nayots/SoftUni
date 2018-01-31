function jsonToHtml(input) {
    let data = JSON.parse(input);
    let keys = Object.keys(data[0]);
    let start = 0;
    let escape = (x) => x.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/\"/g, "&quot;").replace(/'/g, "&#39;");
    let result = "<table>\n";
    result += `  <tr>`;
    for (let i = 0; i < keys.length; i++) {
        const element = keys[i];
        result += `<th>${element}</th>`;
    }
    result += `</tr>\n`;
    for (const item of data) {
        result += `  <tr>`
        for (const key of Object.keys(item)) {
            result += `${`<td>${escape(item[key]+ "")}</td>`}`;
        }
        result += `</tr>\n`
    }


    result += "</table>";
    console.log(result);
}

// jsonToHtml('[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]');
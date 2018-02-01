function JSONTable(input) {
    let result = "<table>\n";
    input.forEach(element => {
        let obj = JSON.parse(element);
        result += "	<tr>\n";
        result += `		<td>${obj.name}</td>\n`;
        result += `		<td>${obj.position}</td>\n`;
        result += `		<td>${Number(obj.salary)}</td>\n`;
        result += "	<tr>\n";
    });
    result += "</table>";

    console.log(result);
}
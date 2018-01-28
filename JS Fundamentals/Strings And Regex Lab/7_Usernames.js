function userNames(params) {
    let results = [];

    for (let i = 0; i < params.length; i++) {
        const element = params[i];
        let tokens = element.split("@");
        let name = tokens[0] + ".";
        let suffix = tokens[1].split(".").map(s => s[0]).join("");
        results.push(`${name}${suffix}`);
    }

    console.log(results.join(", "));
}
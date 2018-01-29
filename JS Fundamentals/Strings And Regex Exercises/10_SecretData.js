function secretData(params) {
    const nameRegex = /(\*[A-Z][A-Za-z]*)(?= |\t|$)/g;
    const phoneRegex = /(\+[0-9-]{10})(?= |\t|$)/g;
    const idRegex = /(\![A-Za-z0-9]+)(?= |\t|$)/g;
    const baseRegex = /(\_[A-Za-z0-9]+)(?= |\t|$)/g;
    const replChar = "|";

    for (let i = 0; i < params.length; i++) {
        params[i] = makeSecret(params[i]);
    }

    function makeSecret(line) {
        line = line.replace(nameRegex, (m) => replChar.repeat(m.length));
        line = line.replace(phoneRegex, (m) => replChar.repeat(m.length));
        line = line.replace(idRegex, (m) => replChar.repeat(m.length));
        line = line.replace(baseRegex, (m) => replChar.repeat(m.length));
        return line;
    }

    console.log(params.join("\n"));
}
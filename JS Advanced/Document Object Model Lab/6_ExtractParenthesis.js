function extract(eleId) {
    let para = document.getElementById(eleId).textContent;
    let pattern = /\(([^)]+)\)/g;
    let result = [];

    let match = pattern.exec(para);
    while (match) {
        result.push(match[1]);
        match = pattern.exec(para);
    }
    return result.join('; ');
}
function templateFormat(params) {
    console.log('<?xml version="1.0" encoding="UTF-8"?>\n<quiz>')
    for (let i = 0; i < params.length; i += 2) {
        console.log(formatXml(params[i], params[i + 1]));
    }
    console.log("</quiz>")

    function formatXml(question, answer) {
        let result = `  <question>
    ${question}
  </question>
  <answer>
    ${answer}
  </answer>`
        return result;
    }

}
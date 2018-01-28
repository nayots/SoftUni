    function escape(params) {
        let result = "<ul>\n";

        params.forEach(element => {
            let ele = element.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/\"/g, "&quot;");
            result += `<li>${ele}</li>\n`;
        });

        result += "</ul>";

        return result;
    }
const url = require("url");
const fs = require("fs");
const path = require("path");
const database = require("../config/dataBase");

module.exports = (req, res) => {
    if ((req.headers.hasOwnProperty("statusheader"))) {
        let headerValue = req.headers["statusheader"]
        if (headerValue === "Full") {
            let filePath = path.normalize(
                path.join(__dirname, "../views/status.html")
            );
    
            fs.readFile(filePath, (err, data) => {
                if (err) {
                    console.log(err);
                    res.writeHead(404, {
                        "Content-Type": "text/plain"
                    });
    
                    res.write("404 not found!");
                    res.end();
                    return;
                }
    
                let content = "";
                content += database.length;
    
                let html = data.toString().replace("{{replaceMe}}", content);
    
                res.writeHead(200, {
                    "Content-Type": "text/html"
                });
    
                res.write(html);
                res.end();
            });
        } else {
            return true;
        }
    } else {
        return true;
    }
}
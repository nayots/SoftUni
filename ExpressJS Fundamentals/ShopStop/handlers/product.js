const url = require("url");
const database = require("../config/database");
const fs = require("fs");
const path = require("path");
const qs = require("querystring");

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname

    if (req.pathname === "/product/add" && req.method === "GET") {
        let filePath = path.normalize(
            path.join(__dirname, "../views/products/add.html")
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

            res.writeHead(200, {
                "Content-Type": "text/html"
            });

            res.write(data);
            res.end();
        })
    } else if (req.pathname === "/product/add" && req.method === "POST") {
        let dataString = "";

        req.on("data", (data) => {
            dataString += data;
        });

        req.on("end", () => {
            let product = qs.parse(dataString);
            database.products.add(product);

            res.writeHead(302, {
                "Location": "/"
            });

            res.end();
        })
    } else {
        return true;
    }
}
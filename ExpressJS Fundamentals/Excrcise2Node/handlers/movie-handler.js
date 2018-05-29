const url = require("url");
const fs = require("fs");
const path = require("path");
const database = require("../config/dataBase");
const qs = require("querystring");
const multiparty = require("multiparty");

const detailsRegex = /\/movies\/details\/([^\s]+)/g;

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if ((req.pathname === "/" || req.pathname === "/viewAllMovies" || req.pathname === "/home") && req.method === "GET") {
        let filePath = path.normalize(
            path.join(__dirname, "../views/viewAll.html")
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
            let moviesInfo = database.map((m,i) => {
                m.id = i;
                return m;
            }).sort((a,b) => b.movieYear - a.movieYear);
            
            for (const movieInfo of moviesInfo) {
                content +=
                `<div class="movie">
                    <a href="movies/details/${movieInfo.id}">
                        <img class="moviePoster" src="${decodeURIComponent(movieInfo.moviePoster)}"/>
                    </a>        
                 </div>`
            }

            let html = data.toString().replace("{{replaceMe}}", content);

            res.writeHead(200, {
                "Content-Type": "text/html"
            });

            res.write(html);
            res.end();
        })
    } else if (req.pathname === "/addMovie" && req.method === "GET") {
        let filePath = path.normalize(
            path.join(__dirname, "../views/addMovie.html")
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
    } else if (req.pathname === "/addMovie" && req.method === "POST") {
        let form = new multiparty.Form();
        let movie = {};
        form.on("part", (part) => {
            part.setEncoding("utf-8");
            let field = "";
            part.on("data", (data) => {
                field += data;
            });

            part.on("end", () => {
                movie[part.name] = field;
            });
        });

        form.on("close", ()=> {

            let addFail = !movie.movieTitle || !movie.moviePoster;
            let filePath = path.normalize(
                path.join(__dirname, "../views/addMovie.html")
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
                if (addFail) {
                    content += `<div id="errBox"><h2 id="errMsg">Please fill all fields</h2></div>`;
                } else {
                    database.push(movie);
                    content += `<div id="succssesBox"><h2 id="succssesMsg">Movie Added</h2></div>`;
                }
                let html = data.toString().replace("{{replaceMe}}", content);
    
                res.writeHead(200, {
                    "Content-Type": "text/html"
                });
    
                res.write(html);
                res.end();
            });
        });
        form.parse(req);
    } else if (detailsRegex.test(req.pathname) && req.method === "GET") {
        detailsRegex.lastIndex = 0;
        let match = detailsRegex.exec(req.pathname);
        let id = match[1];
        
        let filePath = path.normalize(
            path.join(__dirname, "../views/details.html")
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
            let movieInfo = database[id];
            content += `
            <div class="content">
            <img src="${decodeURIComponent(movieInfo.moviePoster)}" alt=""/>
            <h3>Title  ${decodeURIComponent(movieInfo.movieTitle).replace(/\+/g, " ")}</h3>
            <h3>Year ${decodeURIComponent(movieInfo.movieYear).replace(/\+/g, " ")}</h3>
            <p> ${decodeURIComponent(movieInfo.movieDescription).replace(/\+/g, " ")}</p>
            </div>
            `;

            let html = data.toString().replace('<div id="replaceMe">{{replaceMe}}</div>', content);

            res.writeHead(200, {
                "Content-Type": "text/html"
            });

            res.write(html);
            res.end();
        });
    } else {
        return true;
    }
}


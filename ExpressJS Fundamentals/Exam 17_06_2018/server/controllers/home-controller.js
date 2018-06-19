const Article = require("mongoose").model("Article");

module.exports = {
    index: (req, res) => {
        Article.find({}).populate("edits").exec().then((results) => {
            if (results.length === 0) {
                res.render('home/index', {
                    latest: {},
                    latestEntries: []
                });
                return;
            }
            let latestArticle = results.pop();
            let content = latestArticle.edits.sort((a, b) => {
                return b.creationDate - a.creationDate;
            })[0].content.substr(0, 50).replace(/\r\n/g, "<p></p>");

            let obj = {
                title: latestArticle.title,
                id: latestArticle.id,
                content: content
            }
            results.push(latestArticle);
            let latestEntries = [];

            
            while (latestEntries.length < 3 && results.length > 0) {
                let ele = results.pop();
                latestEntries.push({
                    title: ele.title,
                    id: ele.id
                });
            }

            res.render('home/index', {
                latest: obj,
                latestEntries: latestEntries
            });
        })
    }
};
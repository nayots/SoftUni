const Article = require("mongoose").model("Article");
const Edit = require("mongoose").model("Edit");
const User = require("mongoose").model("User");

module.exports = {
    createGet: (req, res) => {
        res.render("article/create");
    },
    createPost: (req, res) => {
        let articleData = req.body;
        if (!articleData.title || !articleData.content) {
            res.locals.globalError = "Title and content cannot be empty!";
            res.render('article/create', articleData);
            return;
        }

        Article.create({
            title: articleData.title,
            edits: []
        }).then((createdArticle) => {
            Edit.create({
                author: req.user._id,
                content: articleData.content,
                article: createdArticle._id
            }).then((createdEdit) => {
                createdArticle.edits.push(createdEdit._id);
                createdArticle.save();

                res.redirect(`/article/details/${createdArticle.id}`);
                return;
            })
        });
        
    },
    allArticlesGet: (req, res) => {
        Article.find({}).sort({title: 1}).exec().then((articles) => {
            res.render("article/all", {
                articles : articles
            });
        });
    },
    detailsGet: (req, res) => {
        let id = req.params.id;
        Article.findById(id).populate("edits").then((articleFound) => {
            let notHistoryView = true;
            let formatedContent = "";
            if (req.query.editId) {
                notHistoryView = false;
                let filteredEdits = articleFound.edits.filter(e => {
                    return e.id === req.query.editId;
                });
                if (filteredEdits.length !== 1) {
                    res.redirect("/articles/all")
                    return;
                }
                formatedContent = filteredEdits[0].content.replace(/\r\n/g, "<p></p>");
            } else {
                formatedContent = articleFound.edits.sort((a,b) => {
                    return b.creationDate - a.creationDate;
                })[0].content.replace(/\r\n/g, "<p></p>");
            }

            

            res.render("article/details", {
                _id: articleFound._id,
                content: formatedContent,
                title: articleFound.title,
                locked: articleFound.locked,
                notHistoryView: notHistoryView
            })
        }).catch((err) => {
            res.status(404);
            res.send('404 Not Found!');
            res.end();
        })
    },
    editGet: (req, res) => {
        let id = req.params.id;
        Article.findById(id).populate("edits").exec().then((articleFound) => {
            let content = articleFound.edits.sort((a,b) => {
                return b.creationDate - a.creationDate;
            })[0].content;

            if (articleFound.locked && !res.locals.isAdmin) {
                res.redirect("/article/all");
                return;
            }

            res.render("article/edit", {
                _id: articleFound._id,
                content: content,
                locked: articleFound.locked,
                title: articleFound.title
            })
            return;
        }).catch((err) => {
            res.status(404);
            res.send('404 Not Found!');
            res.end();
        })
    },
    editPost: (req, res) => {
        let editContent = req.body.content;
        if (!editContent || !req.body.articleId) {
            res.redirect(`/article/edit/${req.body.articleId}`);
            return;
        }

        Article.findById(req.body.articleId).populate("edits").exec().then((articleFound) => {
            if (articleFound.locked && !res.locals.isAdmin) {
                res.redirect("/article/all");
                return;
            }
            Edit.create({
                author: req.user._id,
                content: editContent,
                article: articleFound._id
            }).then((createdEdit) => {
                articleFound.edits.push(createdEdit._id);
                articleFound.save();

                res.redirect(`/article/details/${req.body.articleId}`);
                return;
            })
        })
    },
    historyGet: (req, res) => {
        let id = req.params.id;
        Article.findById(id).populate({
            path: 'edits',
            populate: {
                path: 'author'
            }
        }).exec().then((articleFound) => {

            let sortedEdits = articleFound.edits.sort((a, b) => {
                return b.creationDate - a.creationDate;
            });

            let historyItems = [];

            for (let index = 0; index < sortedEdits.length; index++) {
                const element = sortedEdits[index];

                let obj = {
                    articleId: articleFound._id,
                    editId: element._id,
                    editDate: element.creationDate,
                    editorName: element.author.username
                };
                historyItems.push(obj);
            }

            res.render("article/history", {
                title: articleFound.title,
                historyItems: historyItems
            })
            return;
        }).catch((err) => {
            res.status(404);
            res.send('404 Not Found!');
            res.end();
        })
    },
    latestGet: (req,res) => {
        Article.find({}).exec().then((results) => {
            let latestArticle = results.pop();

            res.redirect(`/article/details/${latestArticle.id}`);
        })
    },
    changeLock: (req, res) => {
        let id = req.params.id;
        Article.findById(id).exec().then((articleFound) => {
            articleFound.locked = !articleFound.locked;
            articleFound.save();

            res.redirect(`/article/details/${articleFound.id}`);
            return;

        }).catch((err) => {
            res.status(404);
            res.send('404 Not Found!');
            res.end();
        })
    },
    searchPost: (req, res) => {
        let queryTerm = req.body.queryTerm;
        Article.find({}).exec().then((results) => {
            let filteredResults = results.filter(r => {
                let title = r.title.toLowerCase();
                let queryTermLower = queryTerm.toLowerCase();
                let found = title.includes(queryTermLower);
                return found;
            })
            let searchResults = [];

            
            for (let index = 0; index < filteredResults.length; index++) {
                const ele = filteredResults[index];
                searchResults.push({
                    title: ele.title,
                    id: ele.id
                });
            }

            res.render('article/search', {
                queryTerm: queryTerm,
                searchResults: searchResults
            });
        })
    }
};

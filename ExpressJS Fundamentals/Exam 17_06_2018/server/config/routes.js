const controllers = require('../controllers');
const auth = require('./auth');

module.exports = (app) => {
    app.get('/', controllers.home.index);
    app.get('/index.html', controllers.home.index);

    app.get('/users/register', controllers.users.registerGet);
    app.post('/users/register', controllers.users.registerPost);
    app.get('/users/login', controllers.users.loginGet);
    app.post('/users/login', controllers.users.loginPost);
    app.post('/users/logout', controllers.users.logout);

    app.get("/article/create", auth.isAuthenticated, controllers.article.createGet);
    app.post("/article/create", auth.isAuthenticated, controllers.article.createPost);
    app.get("/article/all", controllers.article.allArticlesGet);
    app.get("/article/details/:id", controllers.article.detailsGet);
    app.get("/article/edit/:id", auth.isAuthenticated, controllers.article.editGet);
    app.post("/article/edit", auth.isAuthenticated, controllers.article.editPost);
    app.get("/article/history/:id", auth.isAuthenticated, controllers.article.historyGet);
    app.get("/article/latest", controllers.article.latestGet);
    app.get("/article/lock/:id", auth.isInRole("Admin"), controllers.article.changeLock);
    app.get("/article/unlock/:id", auth.isInRole("Admin"), controllers.article.changeLock);
    app.post("/article/search", controllers.article.searchPost);

    

    app.all('*', (req, res) => {
        res.status(404);
        res.send('404 Not Found!');
        res.end();
    });
};

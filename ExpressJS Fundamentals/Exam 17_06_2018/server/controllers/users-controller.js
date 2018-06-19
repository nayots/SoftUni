const encryption = require('../utilities/encryption');
const User = require('mongoose').model('User');

module.exports = {
    registerGet: (req, res) => {
        res.render('users/register');
    },
    registerPost: (req, res) => {
        let reqUser = req.body;
        // Add validations!
        if (!reqUser.username) {
            res.locals.globalError = "Username is required!"
            res.render('users/register', reqUser);
            return;
        }
        if (!reqUser.password) {
            res.locals.globalError = "Password is required!"
            res.render('users/register', reqUser);
            return;
        }
        if (reqUser.password !== reqUser.repeatPassword) {
            res.locals.globalError = "Passwords must match!"
            res.render('users/register', reqUser);
            return;
        }

        let salt = encryption.generateSalt();
        let hashedPassword = encryption.generateHashedPassword(salt, reqUser.password);

        User.create({
            username: reqUser.username,
            salt: salt,
            hashedPass: hashedPassword
        }).then(user => {
            req.logIn(user, (err, user) => {
                if (err) {
                    res.locals.globalError = err;
                    res.render('users/register', user);
                }

                res.redirect('/');
            });
        }).catch((err) => {
            if (err.name === 'MongoError' && err.code === 11000) { 
                res.locals.globalError = "Username is taken!";
                res.render('users/register');
            };
        });
    },
    loginGet: (req, res) => {
        res.render('users/login');
    },
    loginPost: (req, res) => {
        let reqUser = req.body;
        User
            .findOne({ username: reqUser.username }).then(user => {
                if (!user) {
                    res.locals.globalError = 'Invalid user data';
                    res.render('users/login');
                    return;
                }

                if (!user.authenticate(reqUser.password)) {
                    res.locals.globalError = 'Invalid user data';
                    res.render('users/login');
                    return;
                }

                req.logIn(user, (err, user) => {
                    if (err) {
                        res.locals.globalError = err;
                        res.render('users/login');
                    }

                    res.redirect('/');
                });
            });
    },
    logout: (req, res) => {
        req.logout();
        res.redirect('/');
    }
};

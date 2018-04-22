const UserController = (() => {
    function loginPost(ctx) {
        let username = ctx.params["username-login"];
        let password = ctx.params["password-login"];
        if (!password || !username) {
            NotificationService.showError("Fields cannot be empty.");
            ctx.redirect("#/home");
            return;
        }

        AuthService.login(username, password).then((res) =>{
            AuthService.saveSession(res);
            NotificationService.showInfo("Login successful.");
            ctx.redirect("#/home");
        }).catch(RequestService.handleError);
    }

    function registerPost(ctx) {        
        let username = ctx.params["username-register"];
        let password = ctx.params["password-register"];
        let repeatPass = ctx.params["password-register-check"];
        if (!password || !repeatPass || !username || username.length < 5) {
            NotificationService.showError("Fields cannot be empty and username must be 5 characters long.");
            ctx.redirect("#/home");
            return;
        }
        if (password !== repeatPass) {
            NotificationService.showError("Passwords dont match!");
            ctx.redirect("#/home");
            return;
        }

        AuthService.register(username, password, repeatPass).then((res) =>{
            AuthService.saveSession(res);
            NotificationService.showInfo("User registration successful.");
            ctx.redirect("#/home");
        }).catch(RequestService.handleError);
    }

    function logout(ctx) {
        ctx.cashier = sessionStorage.getItem("username");
        AuthService.logout()
            .then(() => {
                sessionStorage.clear();
                NotificationService.showInfo('Logout successful.');
                ctx.redirect('#/home');
            })
            .catch(RequestService.handleError);
    }

    return {
        loginPost,
        registerPost,
        logout
    }
})();
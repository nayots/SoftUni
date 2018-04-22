const HomeController = (() => {
    function landing(ctx) {
        let isAuth = AuthService.isAuth();
        ctx.isAuth = isAuth;
        if (isAuth) {
            ctx.cashier = sessionStorage.getItem("username");
            ctx.redirect("/#/receipts/editor");      
        } else {
            ctx.loadPartials({
                login: "Core/Views/User/login.hbs",
                register: "Core/Views/User/register.hbs",
                footer: "Core/Views/Shared/footer.hbs"
            }).then(function (context) {            
                this.partial("Core/Views/Home/landing.hbs");
            });
        }
    }
    return {
        landing
    }
})();
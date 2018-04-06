$(() => {
    const app = Sammy('#main', function () {
        this.use("Handlebars", "hbs");
        this.get("#/home", (ctx) => {
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            ctx.hasTeam = sessionStorage.getItem("teamId") !== "undefined" && sessionStorage.getItem("teamId") !== null;
            ctx.teamId = sessionStorage.getItem("teamId");
            ctx.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs"
            }).then(function (context) {
                this.partial("../templates/home/home.hbs");
            })
        })
        this.get("#/catalog", async (ctx) => {
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            ctx.hasNoTeam = sessionStorage.getItem("teamId") == "undefined";
            if (!ctx.hasNoTeam) {
                ctx.teams = await teamsService.loadTeams();
            }
            ctx.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                team: "../templates/catalog/team.hbs"
            }).then(function (context) {
                this.partial("../templates/catalog/teamCatalog.hbs");
            })
        })
        this.get("#/about", (ctx) => {
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            ctx.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs"
            }).then(function (context) {
                this.partial("../templates/about/about.hbs");
            })
        })
        this.get("#/logout", (ctx) => {
            auth.logout().then((res) => {
                sessionStorage.removeItem("authtoken");
                auth.showInfo("You logged out.")
                ctx.redirect("#/home");
            }).catch((error) => {
                auth.showError(error);
            })
        })
        this.get("#/login", (ctx) => {
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            ctx.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                loginForm: "../templates/login/loginForm.hbs"
            }).then(function (context) {
                this.partial("../templates/login/loginPage.hbs");
            })
        })
        this.post("#/login", (ctx) => {
            let username = ctx.params.username;
            let password = ctx.params.password;

            auth.login(username, password).then((res) => {
                auth.saveSession(res);
                ctx.redirect("#/home");
                auth.showInfo("Logged in.");
            }).catch((error) => {
                auth.showError(`Failed to log In. Error: ${error}`)
            })
        })
        this.get("#/register", (ctx) => {
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            ctx.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                registerForm: "../templates/register/registerForm.hbs"
            }).then(function (context) {
                this.partial("../templates/register/registerPage.hbs");
            })
        })
        this.post("#/register", (ctx) => {
            let username = ctx.params.username;
            let password = ctx.params.password;
            let repeatPassword = ctx.params.repeatPassword;
            if (password !== repeatPassword) {
                auth.showError("Passwords must match");
                ctx.redirect("#/register");
                return;
            }
            if (!password || !repeatPassword) {
                auth.showError("Fields cannot be empty!");
                ctx.redirect("#/register");
                return;
            }

            auth.register(username, password, repeatPassword).then((res) => {
                auth.saveSession(res);
                ctx.redirect("#/home");
                auth.showInfo("Registered and logged in.");
            }).catch((error) => {
                auth.showError(`Failed to register. Error: ${error}`)
            })
        })

        this.get("#/create", (ctx) => {
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            ctx.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                createForm: "../templates/create/createForm.hbs"
            }).then(function (context) {
                this.partial("../templates/create/createPage.hbs");
            })
        })
        this.post("#/create", (ctx) => {
            let name = ctx.params.name;
            let comment = ctx.params.comment;
            if (!name || !comment) {
                auth.showError("Fields cannot be empty");
                ctx.redirect("#/create");
                return;
            }

            teamsService.createTeam(name, comment).then((res) => {
                teamsService.joinTeam(res._id).then(res => {
                    sessionStorage.setItem("teamId", res.teamId);
                    ctx.redirect("#/catalog");
                    auth.showInfo("Team created and joined.");
                });
            }).catch((error) => {
                auth.showError(`Failed to create team. Error: ${error}`)
            })
        })

        this.get("#/catalog/:teamId", async (ctx) => {
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            let teamId = ctx.params.teamId.replace(":", "");
            if (!ctx.params.teamId) {
                ctx.redirect("#/catalog");
                return;
            }
            let teamDetails = await teamsService.loadTeamDetails(teamId);

            ctx.name = teamDetails.name;
            ctx.comment = teamDetails.comment;
            ctx.teamId = teamDetails._id;
            let members = await teamsService.loadTeamMembers(teamId);
            ctx.members = members;

            ctx.isAuthor = sessionStorage.getItem('userId') == teamDetails._acl.creator;
            ctx.isOnTeam = members.filter(m => m._id == sessionStorage.getItem('userId')).length > 0;

            ctx.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                teamMember: "../templates/catalog/teamMember.hbs",
                teamControls: "../templates/catalog/teamControls.hbs"
            }).then(function (context) {
                this.partial("../templates/catalog/details.hbs");
            })
        })

        this.get("#/leave", (ctx) => {
            teamsService.leaveTeam().then((res) => {
                sessionStorage.removeItem("teamId");
                auth.showInfo("You left the team.")
                ctx.redirect("#/catalog");
            }).catch((error) => {
                auth.showError(error);
            })
        })

        this.get("#/join/:id", (ctx) => {

            let teamId = ctx.params.id.replace(":", "");
            teamsService.joinTeam(teamId).then((res) => {
                sessionStorage.setItem("teamId", res.teamId);
                auth.showInfo("You joined the team.")
                ctx.redirect("#/catalog");
            }).catch((error) => {
                auth.showError(error);
            })
        })

        this.get("#/edit/:teamId", async (ctx) => {
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            let teamId = ctx.params.teamId.replace(":", "");
            if (!ctx.params.teamId) {
                ctx.redirect("#/catalog");
                return;
            }
            let teamDetails = await teamsService.loadTeamDetails(teamId);
            ctx.teamId = teamDetails._id;
            ctx.name = teamDetails.name;
            ctx.comment = teamDetails.comment;

            ctx.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                editForm: "../templates/edit/editForm.hbs"
            }).then(function (context) {
                this.partial("../templates/edit/editPage.hbs");
            })
        })

        this.post("#/edit/:teamId", (ctx) => {
            let teamId = ctx.params.teamId.replace(":", "");
            let name = ctx.params.name;
            let comment = ctx.params.comment;
            if (!name || !comment || !teamId) {
                auth.showError("Fields cannot be empty");
                ctx.redirect(`#/edit/:${teamId}`);
                return;
            }

            teamsService.edit(teamId, name, comment).then((res) => {
                ctx.redirect("#/catalog");
                auth.showInfo("Team edited.");
            }).catch((error) => {
                auth.showError(`Failed to edit team. Error: ${error}`)
            })
        })
    });

    app.run();
});
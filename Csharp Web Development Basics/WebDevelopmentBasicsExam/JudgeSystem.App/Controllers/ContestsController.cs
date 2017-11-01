namespace JudgeSystem.App.Controllers
{
    using JudgeSystem.App.Infrastructure;
    using JudgeSystem.App.Models.Contests;
    using JudgeSystem.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ContestsController : BaseController
    {
        private const string InvalidContestTitle = @"Name – must begin with uppercase letter and has length between 3 and 100 symbols (inclusive)";

        private IContestService contestService;

        public ContestsController(IContestService contestService)
        {
            this.contestService = contestService;
        }

        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            var sb = new StringBuilder();

            var items = contestService.All();

            var isAdmin = this.IsAdmin;
            var email = this.User.Name;

            foreach (var item in items)
            {
                sb.AppendLine(item.ToHtml(isAdmin, email));
            }

            this.ViewModel["contests"] = sb.ToString();

            return View();
        }

        public IActionResult Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateContestModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(InvalidContestTitle);
                return this.View();
            }

            this.contestService.Create(model.ContestName, this.User.Name);

            return Redirect("/contests/all");
        }

        public IActionResult Edit(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            if (!this.contestService.Exists(id) || !this.contestService.UserCanEditDelete(id, this.User.Name, this.IsAdmin))
            {
                return Redirect("/contests/all");
            }
            var contest = this.contestService.GetById(id);
            var contestName = contest.ContestName;
            var contestId = contest.Id;

            this.ViewModel["contest-name"] = contestName;
            this.ViewModel["contest-id"] = contestId.ToString();

            return View();
        }

        [HttpPost]
        public IActionResult Edit(EditContestModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }
            if (!this.contestService.Exists(model.ContestId) || !this.contestService.UserCanEditDelete(model.ContestId, this.User.Name, this.IsAdmin))
            {
                return Redirect("/contests/all");
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(InvalidContestTitle);
                return this.View();
            }

            this.contestService.Edit(model.ContestId, model.ContestName);

            return Redirect("/contests/all");
        }

        public IActionResult Delete(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            if (!this.contestService.Exists(id) || !this.contestService.UserCanEditDelete(id, this.User.Name, this.IsAdmin))
            {
                return Redirect("/contests/all");
            }
            var contest = this.contestService.GetById(id);
            var contestName = contest.ContestName;
            var contestId = contest.Id;

            this.ViewModel["contest-name"] = contestName;
            this.ViewModel["contest-id"] = contestId.ToString();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(DeleteContestModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }
            if (!this.contestService.Exists(model.ContestId) || !this.contestService.UserCanEditDelete(model.ContestId, this.User.Name, this.IsAdmin))
            {
                return Redirect("/contests/all");
            }

            this.contestService.Delete(model.ContestId);

            return Redirect("/contests/all");
        }
    }
}
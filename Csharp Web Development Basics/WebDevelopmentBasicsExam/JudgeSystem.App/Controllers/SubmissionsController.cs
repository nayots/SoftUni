using JudgeSystem.App.Infrastructure;
using JudgeSystem.App.Models;
using JudgeSystem.App.Services.Contracts;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Controllers
{
    public class SubmissionsController : BaseController
    {
        private IContestService contestService;
        private ISubmissionService submissionService;
        private IUserService userService;

        public SubmissionsController(IContestService contestService, ISubmissionService submissionService, IUserService userService)
        {
            this.contestService = contestService;
            this.submissionService = submissionService;
            this.userService = userService;
        }

        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            var contests = this.contestService.AllForSelect();

            var contestsHtml = new StringBuilder();

            foreach (var entry in contests)
            {
                contestsHtml.AppendLine(entry.ToHtmlSubm(false));
            }

            this.ViewModel["contests"] = contestsHtml.ToString();

            return View();
        }

        public IActionResult Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            var contests = this.contestService.AllForSelect();

            var sb = new StringBuilder();

            foreach (var contestEntry in contests)
            {
                if (contestEntry == contests.First())
                {
                    sb.AppendLine(contestEntry.ToHtml(true));
                }
                else
                {
                    sb.AppendLine(contestEntry.ToHtml(false));
                }
            }

            this.ViewModel["contests"] = sb.ToString();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateSubmissionModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToLogin();
            }

            Random rng = new Random();

            bool compiles = rng.Next(1, 100) > 70 ? true : false;

            var creatorid = this.userService.GetUserByEmail(this.User.Name).Id;

            this.submissionService.Create(creatorid, model.ExecutableCode, int.Parse(model.ContestId), compiles);

            return Redirect("/submissions/all");
        }
    }
}
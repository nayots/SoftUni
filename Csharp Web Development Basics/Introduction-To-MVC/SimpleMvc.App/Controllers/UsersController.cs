using Microsoft.EntityFrameworkCore;
using SimpleMvc.App.BindingModels;
using SimpleMvc.App.ViewModels;
using SimpleMvc.Data;
using SimpleMvc.Domain;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using SimpleMvc.Framework.Interfaces.Generic;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMvc.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User(model.Username, model.Password);

            using (var context = new NotesDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return View();
        }

        public IActionResult<AllUsernamesViewModel> All()
        {
            Dictionary<string, int> usernamesAndIds = null;

            using (var context = new NotesDbContext())
            {
                usernamesAndIds = context.Users.Select(u => new KeyValuePair<string, int>(u.Username, u.Id)).ToDictionary(d => d.Key, d => d.Value);
            }

            var viewModel = new AllUsernamesViewModel()
            {
                UsernamesAndIds = usernamesAndIds
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            User user = null;

            using (var context = new NotesDbContext())
            {
                user = context.Users.Include(u => u.Notes).First(u => u.Id == id);
            }

            var viewModel = new UserProfileViewModel()
            {
                UserId = user.Id,
                Username = user.Username,
                Notes = user.Notes
                .Select(n =>
                    new NoteViewModel()
                    {
                        Title = n.Title,
                        Content = n.Content
                    })
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new NotesDbContext())
            {
                var user = context.Users.Include(u => u.Notes).First(u => u.Id == model.UserId);
                var note = new Note(model.Title, model.Content);

                user.Notes.Add(note);
                context.SaveChanges();
            };

            return Profile(model.UserId);
        }
    }
}
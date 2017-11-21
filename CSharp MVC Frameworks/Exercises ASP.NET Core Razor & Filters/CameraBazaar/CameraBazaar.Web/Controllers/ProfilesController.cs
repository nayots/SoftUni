using CameraBazaar.Services.Contracts;
using CameraBazaar.Services.Models;
using CameraBazaar.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CameraBazaar.Web.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly ICameraService cameraService;
        private readonly IUserService userService;

        public ProfilesController(ICameraService cameraService, IUserService userService)
        {
            this.cameraService = cameraService;
            this.userService = userService;
        }

        public IActionResult Details(string id)
        {
            var model = new ProfileViewModel();

            if (this.userService.UserExistsById(id))
            {
                model.UserDetails = this.userService.GetUserProfile(id);
                model.Cameras = this.cameraService.GetCamerasDetailsForUser(id);

                return View(model);
            }

            return BadRequest();
        }

        public IActionResult Edit(string id)
        {
            if (this.userService.UserExistsById(id) && this.User.GetUserId() == id)
            {
                EditProfileModel editProfileModel = this.userService.GetProfileEditInfo(id);

                return View(editProfileModel);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit(EditProfileModel editProfileModel)
        {
            if (this.ModelState.IsValid)
            {
                if (this.User.GetUserId() == editProfileModel.UserId)
                {
                    this.userService.EditProfile(editProfileModel);

                    return RedirectToAction("Details", new { id = editProfileModel.UserId });
                }

                return Unauthorized();
            }

            return View(editProfileModel);
        }
    }
}
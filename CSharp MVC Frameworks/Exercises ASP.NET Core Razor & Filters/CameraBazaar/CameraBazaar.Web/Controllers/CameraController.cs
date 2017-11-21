using CameraBazaar.Data;
using CameraBazaar.Services.Contracts;
using CameraBazaar.Services.Models;
using CameraBazaar.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CameraBazaar.Web.Controllers
{
    public class CameraController : Controller
    {
        private readonly ICameraService cameraService;
        private readonly CameraBazaarDbContext db;

        public CameraController(ICameraService cameraService, CameraBazaarDbContext db)
        {
            this.cameraService = cameraService;
            this.db = db;
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.cameraService.UserIsBanned(this.User.GetUserId()))
            {
                return View(new AddCameraModel());
            }

            return View("Banned");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddCameraModel addCameraModel)
        {
            if (this.cameraService.UserIsBanned(this.User.GetUserId()))
            {
                return BadRequest();
            }

            if (this.ModelState.IsValid)
            {
                this.cameraService.AddCam(this.User.GetUserId(), addCameraModel);

                return RedirectToAction("Index", "Home");
            }

            return View(addCameraModel);
        }

        public IActionResult Details(int? id)
        {
            if (this.cameraService.CameraExists(id))
            {
                CameraFullDetailsModel cameraFullDetailsModel = this.cameraService.GetCameraFullDetails(id);

                return View(cameraFullDetailsModel);
            }

            return BadRequest();
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id != null && this.cameraService.CameraExists(id) && this.cameraService.UserCanEditCamera(this.User.GetUserId(), id.Value))
            {
                EditCameraModel editCameraModel = this.cameraService.GetCameraCompleteEditInfromatio(id.Value);

                return View(editCameraModel);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(EditCameraModel editCameraModel)
        {
            if (this.ModelState.IsValid && this.cameraService.CameraExists(editCameraModel.CameraId) && this.cameraService.UserCanEditCamera(this.User.GetUserId(), editCameraModel.CameraId))
            {
                this.cameraService.EditCamera(editCameraModel);

                return RedirectToAction("Index", "Home");
            }

            return View(editCameraModel);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id != null && this.cameraService.CameraExists(id) && this.cameraService.UserCanEditCamera(this.User.GetUserId(), id.Value))
            {
                EditCameraModel editCameraModel = this.cameraService.GetCameraCompleteEditInfromatio(id.Value);

                return View(editCameraModel);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Destroy(int? cameraId)
        {
            if (cameraId != null && this.cameraService.CameraExists(cameraId) && this.cameraService.UserCanEditCamera(this.User.GetUserId(), cameraId.Value))
            {
                this.cameraService.DeleteCamera(cameraId.Value);

                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }
    }
}
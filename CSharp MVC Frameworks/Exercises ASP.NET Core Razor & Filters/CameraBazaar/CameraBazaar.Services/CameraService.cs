using CameraBazaar.Data;
using CameraBazaar.Data.Models;
using CameraBazaar.Services.Contracts;
using CameraBazaar.Services.Extensions;
using CameraBazaar.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace CameraBazaar.Services
{
    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public void AddCam(string userId, AddCameraModel addCameraModel)
        {
            this.db.Cameras.Add(new Camera()
            {
                Make = addCameraModel.Make.Value,
                Model = addCameraModel.Model,
                Price = addCameraModel.Price.Value,
                Quantity = addCameraModel.Quantity,
                MinShutterSpeed = addCameraModel.MinShutterSpeed,
                MaxShutterSPeed = addCameraModel.MaxShutterSPeed,
                MinISO = addCameraModel.MinISO,
                MaxISO = addCameraModel.MaxISO,
                IsFullFrame = addCameraModel.IsFullFrame,
                VideoResolution = addCameraModel.VideoResolution,
                LightMetering = addCameraModel.LightMetering.Sum(s => (int)s),
                Description = addCameraModel.Description,
                ImageUrl = addCameraModel.ImageUrl,
                UserId = userId
            });

            this.db.SaveChanges();
        }

        public bool CameraExists(int? id)
        {
            if (id is null)
            {
                return false;
            }

            return this.db.Cameras.Any(c => c.Id == id);
        }

        public void DeleteCamera(int cameraId)
        {
            var cam = this.db.Cameras.First(c => c.Id == cameraId);

            this.db.Remove(cam);

            this.db.SaveChanges();
        }

        public void EditCamera(EditCameraModel editCameraModel)
        {
            var camera = this.db.Cameras.First(c => c.Id == editCameraModel.CameraId);

            camera.Make = editCameraModel.Make.Value;
            camera.Model = editCameraModel.Model;
            camera.Price = editCameraModel.Price.Value;
            camera.Quantity = editCameraModel.Quantity;
            camera.MinShutterSpeed = editCameraModel.MinShutterSpeed;
            camera.MaxShutterSPeed = editCameraModel.MaxShutterSPeed;
            camera.MinISO = editCameraModel.MinISO;
            camera.MaxISO = editCameraModel.MaxISO;
            camera.IsFullFrame = editCameraModel.IsFullFrame;
            camera.VideoResolution = editCameraModel.VideoResolution;
            camera.LightMetering = editCameraModel.LightMetering.Sum(l => (int)l);
            camera.Description = editCameraModel.Description;
            camera.ImageUrl = editCameraModel.ImageUrl;

            this.db.SaveChanges();
        }

        public IEnumerable<CameraShortDetailsModel> GetAllCamerasDetails()
        {
            var cameras = this.db.Cameras
                .Select(c => new CameraShortDetailsModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    ImageUrl = c.ImageUrl,
                    CameraId = c.Id,
                    InStock = c.Quantity > 0,
                    SellerId = c.UserId
                }).ToList();

            return cameras;
        }

        public EditCameraModel GetCameraCompleteEditInfromatio(int cameraId)
        {
            var cam = this.db.Cameras.First(c => c.Id == cameraId);

            EditCameraModel editCameraModel = new EditCameraModel()
            {
                Make = cam.Make,
                Model = cam.Model,
                Price = cam.Price,
                CameraId = cam.Id,
                Description = cam.Description,
                ImageUrl = cam.ImageUrl,
                IsFullFrame = cam.IsFullFrame,
                MaxISO = cam.MaxISO,
                MinISO = cam.MinISO,
                MaxShutterSPeed = cam.MaxShutterSPeed,
                MinShutterSpeed = cam.MinShutterSpeed,
                Quantity = cam.Quantity,
                VideoResolution = cam.VideoResolution,
                LightMetering = cam.LightMetering.GetMeterings()
            };

            return editCameraModel;
        }

        public CameraFullDetailsModel GetCameraFullDetails(int? id)
        {
            var camera = this.db.Cameras.First(c => c.Id == id.Value);
            this.db.Entry(camera).Reference(c => c.User).Load();

            var fullDetailsModel = new CameraFullDetailsModel()
            {
                Make = camera.Make,
                Model = camera.Model,
                Price = camera.Price,
                InStock = camera.Quantity > 0,
                SellerId = camera.UserId,
                SellerUsername = camera.User.UserName,
                ImgUrl = camera.ImageUrl,
                IsFullFrame = camera.IsFullFrame,
                MinShutterSpeed = camera.MinShutterSpeed.Value,
                MaxShutterSpeed = camera.MaxShutterSPeed.Value,
                MinISO = camera.MinISO.Value,
                MaxISO = camera.MaxISO.Value,
                VideoResolution = camera.VideoResolution,
                LightMetering = camera.LightMetering.GetMeterings(),
                Description = camera.Description
            };

            return fullDetailsModel;
        }

        public IEnumerable<CameraShortDetailsModel> GetCamerasDetailsForUser(string id)
        {
            var cameras = this.db.Cameras.Where(c => c.UserId == id)
                .Select(c => new CameraShortDetailsModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    ImageUrl = c.ImageUrl,
                    CameraId = c.Id,
                    InStock = c.Quantity > 0,
                    SellerId = c.UserId
                }).ToList();

            return cameras;
        }

        public bool UserIsBanned(string userId)
        {
            return this.db.Users.First(u => u.Id == userId).IsBanned;
        }

        public bool UserCanEditCamera(string userId, int cameraId)
        {
            return this.db.Cameras.First(c => c.Id == cameraId).UserId == userId;
        }
    }
}
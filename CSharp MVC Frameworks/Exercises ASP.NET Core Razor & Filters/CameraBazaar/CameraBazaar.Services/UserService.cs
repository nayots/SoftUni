using CameraBazaar.Data;
using CameraBazaar.Data.Models;
using CameraBazaar.Services.Contracts;
using CameraBazaar.Services.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CameraBazaar.Services
{
    public class UserService : IUserService
    {
        private readonly CameraBazaarDbContext db;
        private readonly UserManager<User> userManager;

        public UserService(CameraBazaarDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public void ChangeStatus(string username)
        {
            var user = this.db.Users.First(u => u.UserName == username);

            user.IsBanned = !user.IsBanned;

            this.db.SaveChanges();
        }

        public void EditProfile(EditProfileModel editProfileModel)
        {
            Task.Run(async () =>
            {
                var currentUser = this.db.Users.First(u => u.Id == editProfileModel.UserId);
                var emailToken = await this.userManager.GenerateChangeEmailTokenAsync(currentUser, editProfileModel.Email);

                await this.userManager.ChangeEmailAsync(currentUser, editProfileModel.Email, emailToken);

                var phoneToken = await this.userManager.GenerateChangePhoneNumberTokenAsync(currentUser, editProfileModel.Phone);

                await this.userManager.ChangePhoneNumberAsync(currentUser, editProfileModel.Phone, phoneToken);

                await this.userManager.ChangePasswordAsync(currentUser, editProfileModel.CurrentPassword, editProfileModel.Password);
            }).Wait();
        }

        public IEnumerable<UserSellerStatusModel> GetAllUsersInfo()
        {
            IEnumerable<UserSellerStatusModel> userSellerStatusModels = this.db.Users
                .Select(u => new UserSellerStatusModel()
                {
                    Username = u.UserName,
                    IsBanned = u.IsBanned
                }).ToList();

            return userSellerStatusModels;
        }

        public EditProfileModel GetProfileEditInfo(string id)
        {
            return this.db.Users.Where(u => u.Id == id)
                .Select(u => new EditProfileModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    Phone = u.PhoneNumber,
                    LastLogin = u.LastLogin
                }).First();
        }

        public UserDetailsModel GetUserProfile(string id)
        {
            var profile = this.db.Users.Where(u => u.Id == id)
                .Select(u => new UserDetailsModel()
                {
                    Username = u.UserName,
                    LastLogin = u.LastLogin,
                    UserId = u.Id,
                    Email = u.Email,
                    Phone = u.PhoneNumber,
                    InStockCameras = u.Cameras.Where(c => c.Quantity > 0).Count(),
                    OutOfStockCameras = u.Cameras.Where(c => c.Quantity <= 0).Count()
                }).FirstOrDefault();

            return profile;
        }

        public void SaveLoginDate(string username, DateTime logginTime)
        {
            var user = this.db.Users.First(u => u.UserName == username);

            user.LastLogin = logginTime;

            this.db.SaveChanges();
        }

        public bool UserExistsById(string id)
        {
            if (id is null)
            {
                return false;
            }

            return this.db.Users.Any(u => u.Id == id);
        }

        public bool UserExistsByUsername(string username)
        {
            if (username is null)
            {
                return false;
            }

            return this.db.Users.Any(u => u.UserName == username);
        }
    }
}
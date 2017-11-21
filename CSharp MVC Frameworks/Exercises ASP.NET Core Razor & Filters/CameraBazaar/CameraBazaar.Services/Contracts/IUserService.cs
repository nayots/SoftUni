using CameraBazaar.Services.Models;
using System;
using System.Collections.Generic;

namespace CameraBazaar.Services.Contracts
{
    public interface IUserService
    {
        UserDetailsModel GetUserProfile(string id);

        bool UserExistsById(string id);

        bool UserExistsByUsername(string username);

        EditProfileModel GetProfileEditInfo(string id);

        void EditProfile(EditProfileModel editProfileModel);

        void SaveLoginDate(string username, DateTime logginTime);

        IEnumerable<UserSellerStatusModel> GetAllUsersInfo();

        void ChangeStatus(string username);
    }
}
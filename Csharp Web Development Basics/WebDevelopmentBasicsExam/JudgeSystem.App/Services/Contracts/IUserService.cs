using JudgeSystem.App.Data.Models;

namespace JudgeSystem.App.Services.Contracts
{
    public interface IUserService
    {
        bool Create(string email, string password, string fullname);

        bool UserExists(string email, string password);

        User GetUserByEmail(string name);
    }
}
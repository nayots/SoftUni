using JudgeSystem.App.Data.Models;
using JudgeSystem.App.Models.Contests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Services.Contracts
{
    public interface IContestService
    {
        ICollection<ContestListModel> All();

        void Create(string contestName, string creatorEmail);

        bool Exists(int id);

        Contest GetById(int id);

        void Edit(int contestId, string contestName);

        bool UserCanEditDelete(int id, string name, bool isAdmin);

        void Delete(int contestId);

        ICollection<ContestSelectModel> AllForSelect();
    }
}
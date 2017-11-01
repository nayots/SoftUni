using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Services.Contracts
{
    public interface ISubmissionService
    {
        void Create(int creatorid, string executableCode, int contestId, bool compiles);
    }
}
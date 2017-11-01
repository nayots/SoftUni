using JudgeSystem.App.Data.Models;
using JudgeSystem.App.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace JudgeSystem.App.Models.Contests
{
    public class ContestSelectModel : IMapFrom<Contest>
    {
        public int Id { get; set; }

        public string ContestName { get; set; }
    }
}
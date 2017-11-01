using AutoMapper;
using JudgeSystem.App.Data.Models;
using JudgeSystem.App.Infrastructure.Mapping;

namespace JudgeSystem.App.Models.Contests
{
    public class ContestListModel : IMapFrom<Contest>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string ContestName { get; set; }

        public int Submissions { get; set; }

        public string CreatorEmail { get; set; }

        public void Configure(IMapperConfigurationExpression config)
        {
            config
                .CreateMap<Contest, ContestListModel>()
                .ForMember(gla => gla.Submissions, cfg => cfg.MapFrom(g => g.Submissions.Count))
                .ForMember(gla => gla.CreatorEmail, cfg => cfg.MapFrom(g => g.CreatorEmail));
        }
    }
}
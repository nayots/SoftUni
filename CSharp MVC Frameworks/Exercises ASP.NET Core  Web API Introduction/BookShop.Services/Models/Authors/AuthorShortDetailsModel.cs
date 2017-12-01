using AutoMapper;
using BookShop.Common.AutoMapper;
using BookShop.Data.Models;

namespace BookShop.Services.Models.Authors
{
    public class AuthorShortDetailsModel : IMapFrom<Author>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorShortDetailsModel>()
                .ForMember(am => am.Name, cfg => cfg.MapFrom(a => a.FirstName + " " + a.LastName));
        }
    }
}
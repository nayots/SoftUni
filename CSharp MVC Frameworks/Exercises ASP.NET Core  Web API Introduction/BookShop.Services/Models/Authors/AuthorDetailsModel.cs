using AutoMapper;
using BookShop.Common.AutoMapper;
using BookShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Services.Models.Authors
{
    public class AuthorDetailsModel : IMapFrom<Author>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Books { get; set; } = new List<string>();

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDetailsModel>()
                .ForMember(m => m.Books, cfg => cfg.MapFrom(a => a.Books.Select(b => b.Title)));
        }
    }
}
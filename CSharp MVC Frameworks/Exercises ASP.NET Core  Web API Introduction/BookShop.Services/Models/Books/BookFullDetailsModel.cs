using AutoMapper;
using BookShop.Common.AutoMapper;
using BookShop.Data.Models;
using BookShop.Services.Models.Authors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Services.Models.Books
{
    public class BookFullDetailsModel : IMapFrom<Book>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public AuthorShortDetailsModel Author { get; set; }

        public string Edition { get; set; }

        public int AgeRestriction { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Book, BookFullDetailsModel>()
                .ForMember(bd => bd.Categories, cfg => cfg.MapFrom(b => b.Categories.Select(c => c.Category.Name)));
        }
    }
}
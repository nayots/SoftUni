using BookShop.Common.AutoMapper;
using BookShop.Data.Models;

namespace BookShop.Services.Models.Categories
{
    public class CategoryInfoModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
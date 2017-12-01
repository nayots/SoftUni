using BookShop.Services.Models.Categories;
using System.Collections.Generic;

namespace BookShop.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryInfoModel> All();

        bool CategoryExists(int id);

        bool CategoryExists(string name);

        CategoryInfoModel GetbyId(int id);

        CategoryInfoModel Edit(int id, string name);

        void Delete(int id);

        CategoryInfoModel Create(string name);
    }
}
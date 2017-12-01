using AutoMapper.QueryableExtensions;
using BookShop.Data;
using BookShop.Data.Models;
using BookShop.Services.Contracts;
using BookShop.Services.Models.Categories;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BookShopDbContext db;

        public CategoryService(BookShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CategoryInfoModel> All()
        {
            return this.db.Categories.ProjectTo<CategoryInfoModel>().ToList();
        }

        public bool CategoryExists(int id)
        {
            return this.db.Categories.Any(c => c.Id == id);
        }

        public bool CategoryExists(string name)
        {
            return this.db.Categories.Any(c => c.Name == name);
        }

        public CategoryInfoModel Create(string name)
        {
            var category = new Category()
            {
                Name = name
            };

            this.db.Categories.Add(category);
            this.db.SaveChanges();

            return this.GetbyId(category.Id);
        }

        public void Delete(int id)
        {
            var category = this.db.Categories.First(c => c.Id == id);

            this.db.Remove(category);
            this.db.SaveChanges();
        }

        public CategoryInfoModel Edit(int id, string name)
        {
            var category = this.db.Categories.First(c => c.Id == id);

            category.Name = name;

            this.db.SaveChanges();

            return this.GetbyId(id);
        }

        public CategoryInfoModel GetbyId(int id)
        {
            return this.db.Categories.Where(c => c.Id == id).ProjectTo<CategoryInfoModel>().First();
        }
    }
}
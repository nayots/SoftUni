using MiniServer.Data.Contracts;
using MiniServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniServer.Data
{
    public class ProductRepository : IProductRepository
    {
        private bool disposed = false;
        private ShopDbContext context;

        public ProductRepository(ShopDbContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
        }

        public bool ProductExists(int id)
        {
            bool result = context.Products.Any(c => c.Id == id);

            return result;
        }

        public ICollection<Product> GetAllProducts()
        {
            var products = context.Products.ToList();

            return products;
        }

        public Product GetProductById(int id)
        {
            var product = context.Products.FirstOrDefault(c => c.Id == id);

            return product;
        }

        public ICollection<Product> GetProducts(string keyword)
        {
            var products = context.Products
                .Where(c => c.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();

            return products;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
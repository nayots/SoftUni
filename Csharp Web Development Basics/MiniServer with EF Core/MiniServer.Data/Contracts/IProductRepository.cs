using MiniServer.Models;
using System;
using System.Collections.Generic;

namespace MiniServer.Data.Contracts
{
    public interface IProductRepository : IDisposable
    {
        ICollection<Product> GetAllProducts();

        ICollection<Product> GetProducts(string keyword);

        void AddProduct(Product product);

        Product GetProductById(int id);

        bool ProductExists(int id);

        void Save();
    }
}
using NewsOutlet.Services.Models;
using System;
using System.Collections.Generic;

namespace NewsOutlet.Services.Contracts
{
    public interface INewsService
    {
        IEnumerable<NewsInfoModel> GetAllNewsOrdered();

        NewsInfoModel Create(string title, string content, DateTime publishDate);

        NewsInfoModel Update(int id, string title, string content, DateTime publishDate);

        NewsInfoModel GetBasicInfo(int id);

        bool Exists(int id);

        void Delete(int id);
    }
}
using AutoMapper.QueryableExtensions;
using NewsOutlet.Data;
using NewsOutlet.Data.Models;
using NewsOutlet.Services.Contracts;
using NewsOutlet.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsOutlet.Services
{
    public class NewsService : INewsService
    {
        private NewsOutletDbContext db;

        public NewsService(NewsOutletDbContext db)
        {
            this.db = db;
        }

        public NewsInfoModel Create(string title, string content, DateTime publishDate)
        {
            var news = new News()
            {
                Title = title,
                Content = content,
                PublishDate = publishDate
            };

            this.db.News.Add(news);

            this.db.SaveChanges();

            return this.GetBasicInfo(news.Id);
        }

        public bool Exists(int id)
        {
            return this.db.News.Any(n => n.Id == id);
        }

        public IEnumerable<NewsInfoModel> GetAllNewsOrdered()
        {
            return this.db.News
                    .ProjectTo<NewsInfoModel>()
                    .OrderByDescending(n => n.PublishDate)
                    .ToList();
        }

        public NewsInfoModel Update(int id, string title, string content, DateTime publishDate)
        {
            var news = this.db.News.FirstOrDefault(n => n.Id == id);

            news.Title = title;
            news.Content = content;
            news.PublishDate = publishDate;

            this.db.SaveChanges();

            return this.GetBasicInfo(news.Id);
        }

        public NewsInfoModel GetBasicInfo(int id)
        {
            return this.db.News.Where(n => n.Id == id).ProjectTo<NewsInfoModel>().FirstOrDefault();
        }

        public void Delete(int id)
        {
            var news = this.db.News.First(n => n.Id == id);

            this.db.Remove(news);

            this.db.SaveChanges();
        }
    }
}
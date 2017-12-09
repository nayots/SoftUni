using BookShop.Common.AutoMapper;
using NewsOutlet.Data.Models;
using System;

namespace NewsOutlet.Services.Models
{
    public class NewsInfoModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
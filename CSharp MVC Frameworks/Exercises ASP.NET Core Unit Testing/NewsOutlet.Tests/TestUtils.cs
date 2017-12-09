using AutoMapper;
using BookShop.Web.Infrastructure.AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsOutlet.Data;
using System;

namespace NewsOutlet.Tests
{
    public class TestUtils
    {
        private static bool mapperInitialized;

        public NewsOutletDbContext GetDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<NewsOutletDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var dbContext = new NewsOutletDbContext(dbContextOptions.Options);

            return dbContext;
        }

        public static void InitializeMapper()
        {
            if (mapperInitialized)
            {
                return;
            }

            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            mapperInitialized = true;
        }
    }
}
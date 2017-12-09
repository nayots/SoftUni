using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NewsOutlet.Data;
using NewsOutlet.Data.Models;
using NewsOutlet.Services;
using NewsOutlet.Services.Contracts;
using NewsOutlet.Services.Models;
using NewsOutlet.Web.Controllers;
using NewsOutlet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NewsOutlet.Tests.Controllers
{
    public class NewsControllerTests
    {
        [Fact]
        public void ListAllItemsReturnOkAndItemsAreSortedDescByPublishDate()
        {
            //Arrange
            TestUtils testUtils = new TestUtils();

            TestUtils.InitializeMapper();
            var db = testUtils.GetDbContext();

            this.PopulateDb(db);

            INewsService newsService = new NewsService(db);

            var sut = new NewsController(newsService);

            //Act

            var result = sut.All();

            //Assert

            result.GetType().Should()
                .Match(r => r == typeof(OkObjectResult));

            var returnedData = (sut.All() as OkObjectResult).Value as IEnumerable<NewsInfoModel>;

            returnedData.Should()
                .HaveCount(5)
                .And
                .Match(r => r.ElementAt(0).Id == 3 && r.ElementAt(4).Id == 2);
        }

        [Fact]
        public void CreateItemReturnsOk()
        {
            //Arrange
            TestUtils testUtils = new TestUtils();

            var mockService = new Mock<INewsService>();
            mockService.Setup(
                m => m.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(() =>
                new NewsInfoModel()
                {
                    Id = 1,
                    Title = "TestTitle",
                    Content = "Blabla",
                    PublishDate = new DateTime(2017, 12, 12)
                });

            var sut = new NewsController(mockService.Object);
            var model = new CreateEditNewsModel()
            {
                Title = "TestTitle",
                Content = "Blabla",
                PublishDate = new DateTime(2017, 12, 12)
            };

            //Act
            var result = sut.Create(model);

            //Assert

            Assert.IsType<OkObjectResult>(result);

            var resultData = (result as OkObjectResult).Value as NewsInfoModel;

            Assert.True(resultData.Title == model.Title
                &&
                resultData.Content == model.Content
                &&
                resultData.PublishDate == model.PublishDate);
        }

        [Fact]
        public void CreateNewItemWithBadDataReturnsBadRequest()
        {
            //Arrange
            var mockNewsService = new Mock<INewsService>();

            var sut = new NewsController(mockNewsService.Object);
            //Act

            var result = sut.Create(new CreateEditNewsModel()
            {
                Title = "",
                Content = "Blabla",
                PublishDate = DateTime.Now
            });

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void ModifyItemWithCorrectDataReturnsOkResponseWithItem()
        {
            //Arrange
            TestUtils testUtils = new TestUtils();

            TestUtils.InitializeMapper();
            var db = testUtils.GetDbContext();

            this.PopulateDb(db);

            INewsService newsService = new NewsService(db);

            var sut = new NewsController(newsService);
            var model = new CreateEditNewsModel()
            {
                Title = "TestTitleEdit",
                Content = "BlablaEdit",
                PublishDate = new DateTime(2017, 12, 12)
            };
            //Act

            var result = sut.Update(1, model);

            //Assert

            Assert.IsType<OkObjectResult>(result);

            var resultData = (result as OkObjectResult).Value as NewsInfoModel;

            Assert.True(resultData.Title == model.Title && resultData.Content == model.Content);
        }

        [Fact]
        public void ModifyItemWithBadDataReturnsBadRequestResponse()
        {
            //Arrange
            TestUtils testUtils = new TestUtils();

            TestUtils.InitializeMapper();
            var db = testUtils.GetDbContext();

            this.PopulateDb(db);

            INewsService newsService = new NewsService(db);

            var sut = new NewsController(newsService);
            var model = new CreateEditNewsModel()
            {
                Title = "",
                Content = "",
                PublishDate = new DateTime(2017, 12, 12)
            };
            //Act

            var result = sut.Update(999, model);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void DeleteItemWithExistingIdReturnsOkAndRemovesitemFromDatabase(int id)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();

            TestUtils.InitializeMapper();
            var db = testUtils.GetDbContext();

            this.PopulateDb(db);

            INewsService newsService = new NewsService(db);

            var sut = new NewsController(newsService);
            //Act

            var result = sut.Delete(id);
            bool itemExistsAfterDelete = newsService.Exists(id);

            //Assert

            Assert.IsType<OkObjectResult>(result);
            Assert.True(!itemExistsAfterDelete);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(999)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void DeleteItemWithNonExistingIdReturnsBadRequest(int id)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();

            TestUtils.InitializeMapper();
            var db = testUtils.GetDbContext();

            this.PopulateDb(db);

            INewsService newsService = new NewsService(db);

            var sut = new NewsController(newsService);
            //Act

            var result = sut.Delete(id);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void GetItemByIdReturnsOk(int id)
        {
            //Arrange
            TestUtils testUtils = new TestUtils();

            TestUtils.InitializeMapper();
            var db = testUtils.GetDbContext();

            this.PopulateDb(db);

            INewsService newsService = new NewsService(db);

            var sut = new NewsController(newsService);
            //Act
            var result = sut.GetById(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var resultData = (result as OkObjectResult).Value as NewsInfoModel;
            Assert.True(resultData.Id == id);
        }

        private void PopulateDb(NewsOutletDbContext db)
        {
            var news1 = new News()
            {
                Id = 1,
                Title = "News1",
                Content = "SOme news 1",
                PublishDate = DateTime.UtcNow.AddDays(2)
            };

            var news2 = new News()
            {
                Id = 2,
                Title = "News2",
                Content = "SOme news 2",
                PublishDate = DateTime.UtcNow.AddDays(1)
            };

            var news3 = new News()
            {
                Id = 3,
                Title = "News3",
                Content = "SOme news 3",
                PublishDate = DateTime.UtcNow.AddDays(8)
            };

            var news4 = new News()
            {
                Id = 4,
                Title = "News4",
                Content = "SOme news 4",
                PublishDate = DateTime.UtcNow.AddDays(4)
            };

            var news5 = new News()
            {
                Id = 5,
                Title = "News5",
                Content = "SOme news 5",
                PublishDate = DateTime.UtcNow.AddDays(7)
            };

            db.News.AddRange(news1, news2, news3, news4, news5);

            db.SaveChanges();
        }
    }
}
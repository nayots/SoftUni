namespace PhotographersDB.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotographersDB.PhotographersDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PhotographersDB.PhotographersDBContext";
        }

        protected override void Seed(PhotographersDB.PhotographersDBContext context)
        {
            var ph1 = new Photographer()
            {
                Username = "Pesho",
                Password = "adasd",
                RegisterDate = new DateTime(2000, 3, 23),
                BirthDate = new DateTime(1991, 12, 20),
                Email = "dasdas@abv.bg"
            };

            var ph2 = new Photographer()
            {
                Username = "Gosho",
                Password = "123abc",
                RegisterDate = new DateTime(2001, 1, 21),
                BirthDate = new DateTime(1991, 12, 13),
                Email = "ggdfgdfgdf@gmail.com"
            };

            var ph3 = new Photographer()
            {
                Username = "Gesho",
                Password = "kjkjj",
                RegisterDate = new DateTime(1989, 11, 25),
                BirthDate = new DateTime(1991, 12, 23),
                Email = "oldfart@aol.com"
            };

            context.Photographers.AddOrUpdate(x => x.Username, ph1);
            context.SaveChanges();
            context.Photographers.AddOrUpdate(x => x.Username, ph2);
            context.SaveChanges();
            context.Photographers.AddOrUpdate(x => x.Username, ph3);
            context.SaveChanges();

            var album1 = new Album()
            {
                Name = "Album1",
                BackgroundColor = "red",
                IsPublic = true
            };

            var album2 = new Album()
            {
                Name = "Album2",
                BackgroundColor = "blue",
                IsPublic = true
            };

            var album3 = new Album()
            {
                Name = "Album3",
                BackgroundColor = "orange",
                IsPublic = true
            };

            var album4 = new Album()
            {
                Name = "Album4",
                BackgroundColor = "green",
                IsPublic = true
            };

            context.Albums.AddOrUpdate(x => x.Name, album1);
            context.SaveChanges();
            context.Albums.AddOrUpdate(x => x.Name, album2);
            context.SaveChanges();
            context.Albums.AddOrUpdate(x => x.Name, album3);
            context.SaveChanges();
            context.Albums.AddOrUpdate(x => x.Name, album4);
            context.SaveChanges();

            PhotographerAlbum pa1 = new PhotographerAlbum()
            {
                Photographer_Id = ph1.Id,
                Album_Id = album1.Id,
                Role = Role.Owner
            };

            album1.Photographers.Add(pa1);

            PhotographerAlbum pa2 = new PhotographerAlbum()
            {
                Photographer_Id = ph1.Id,
                Album_Id = album2.Id,
                Role = Role.Owner
            };

            album2.Photographers.Add(pa2);

            PhotographerAlbum pa3 = new PhotographerAlbum()
            {
                Photographer_Id = ph2.Id,
                Album_Id = album3.Id,
                Role = Role.Owner
            };

            album3.Photographers.Add(pa3);

            PhotographerAlbum pa4 = new PhotographerAlbum()
            {
                Photographer_Id = ph3.Id,
                Album_Id = album4.Id,
                Role = Role.Viewer
            };

            album4.Photographers.Add(pa4);

            var picture1 = new Picture()
            {
                Caption = "someCaption1",
                FilePath = "c:\\Albums1",
                Title = "BestTitle1"
            };

            var picture2 = new Picture()
            {
                Caption = "someCaption2",
                FilePath = "c:\\Albums2",
                Title = "BestTitle2"
            };

            var picture3 = new Picture()
            {
                Caption = "someCaption3",
                FilePath = "c:\\Albums3",
                Title = "BestTitle3"
            };

            context.PhotographerAlbums.Add(pa1);
            context.PhotographerAlbums.Add(pa2);
            context.PhotographerAlbums.Add(pa3);
            context.PhotographerAlbums.Add(pa4);

            context.Pictures.AddOrUpdate(x => x.Caption, picture1);
            context.SaveChanges();
            context.Pictures.AddOrUpdate(x => x.Caption, picture2);
            context.SaveChanges();
            context.Pictures.AddOrUpdate(x => x.Caption, picture3);
            context.SaveChanges();

            var tag1 = new Tag()
            {
                Label = "#blessed"
            };
            context.Tags.AddOrUpdate(x => x.Label, tag1);
            context.SaveChanges();

            var tag2 = new Tag()
            {
                Label = "#nofiler"
            };
            context.Tags.AddOrUpdate(x => x.Label, tag2);
            context.SaveChanges();

            var tag3 = new Tag()
            {
                Label = "#wokeuplikethis"
            };
            context.Tags.AddOrUpdate(x => x.Label, tag3);
            context.SaveChanges();

            album1.Tags.Add(tag1);
            album1.Tags.Add(tag2);
            album2.Tags.Add(tag3);
            album2.Tags.Add(tag2);
            album3.Tags.Add(tag1);
            album4.Tags.Add(tag3);

            album1.Pictures.Add(picture1);
            album1.Pictures.Add(picture2);
            album2.Pictures.Add(picture1);
            album2.Pictures.Add(picture3);
            album3.Pictures.Add(picture3);
            album3.Pictures.Add(picture2);
            album4.Pictures.Add(picture1);
            context.SaveChanges();
        }
    }
}

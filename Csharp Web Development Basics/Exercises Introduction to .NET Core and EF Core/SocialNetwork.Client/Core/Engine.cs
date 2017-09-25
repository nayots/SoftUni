using Microsoft.EntityFrameworkCore;
using SocialNetwork.Client.Core.Utils;
using SocialNetwork.Data;
using SocialNetwork.Models;
using SocialNetwork.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Client.Core
{
    public class Engine
    {
        public void Run()
        {
            using (var db = new SocialNetworkContext())
            {
                SeeDDbIfEmpty(db);
                ListAllUsersWithFriendsCount(db);
                Console.WriteLine();
                ListActiveUsersWithFriends(db);
                Console.WriteLine();
                SeedDDBWithAlbums(db);
                ListAlbumsAndOwners(db);
                Console.WriteLine();
                ListPictureInMultipleAlbums(db);
                Console.WriteLine();
                ListAllUserAlbums(db);
                Console.WriteLine();
                RegisterUserTags(db);
                AddTagsToAlbums(db); //Run this a couple of times if you want albums to have more tags
                Console.WriteLine();
                ListAllAlbumsWithGivenTag(db);
                Console.WriteLine();
                ListUsersWithAlbumsWithMoreThanThreeTags(db);
                Console.WriteLine();
                ListUsersAndAlbumViewers(db);
                Console.WriteLine();
                ListSharedAlbums(db);
                Console.WriteLine();
                ListAlbumsSharedWithUser(db);
                Console.WriteLine();
                ListAllAlbumsWithUser(db);
                Console.WriteLine();
                ListUserAlbumInformation(db);
                Console.WriteLine();
                ListPublicAlbumViewers(db);
            }
        }

        private void ListPublicAlbumViewers(SocialNetworkContext db)
        {
            var users = db.Users
                .Where(u => u.Albums.Any(us => us.Role == Role.Viewer))
                .Select(u => new
                {
                    u.Username,
                    PublicAlbumsShared = u.Albums.Where(a => a.Role == Role.Viewer && a.Album.IsPublic == true).Count()
                }).ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Username} is an album viewer and has {user.PublicAlbumsShared} PUBLIC albums shared with him.");
            }
        }

        private void ListUserAlbumInformation(SocialNetworkContext db)
        {
            var testUsername = "Gosho";

            var userAlbumInfo = db.Users
                .Where(u => u.Username == testUsername)
                .Select(u => new
                {
                    OwnerOf = u.Albums.Where(ah => ah.Role == Role.Owner).Count(),
                    ViewerOf = u.Albums.Where(ah => ah.Role == Role.Viewer).Count()
                })
                .First();

            Console.WriteLine($"User {testUsername} is the owner of {userAlbumInfo.OwnerOf} albums and the viewer of {userAlbumInfo.ViewerOf}.");
        }

        private void ListAllAlbumsWithUser(SocialNetworkContext db)
        {
            var albums = db.Albums.
                Select(a => new
                {
                    AlbumName = a.Name,
                    Users = a.AlbumHolders.Select(ah => new
                    {
                        Username = ah.User.Username,
                        Role = ah.Role
                    }).OrderBy(u => u.Role).ThenBy(u => u.Username)
                })
                .ToList()
                .OrderBy(a => a.Users.First().Username)
                .ThenByDescending(a => a.Users.Where(u => u.Role == Role.Viewer).Count())
                .ToList();

            foreach (var alb in albums)
            {
                Console.WriteLine($"Album: {alb.AlbumName}");
                foreach (var user in alb.Users)
                {
                    Console.WriteLine($"--User: {user.Username}, role = {user.Role}");
                }
            }
        }

        private void ListAlbumsSharedWithUser(SocialNetworkContext db)
        {
            var testUsername = "Pesho";

            var sharedAlbums = db.Albums
                .Where(ah =>
                    ah.AlbumHolders
                        .Any(a => a.User.Username == testUsername && a.Role == Role.Viewer)
                )
                .Select(a => new
                {
                    AlbumName = a.Name,
                    PictureCount = a.Pictures.Count
                })
                .OrderByDescending(a => a.PictureCount)
                .ThenBy(a => a.AlbumName)
                .ToList();

            Console.WriteLine($"Albums shared with: {testUsername}");
            foreach (var alb in sharedAlbums)
            {
                Console.WriteLine($"-Album: {alb.AlbumName}");
                Console.WriteLine($"-Pictures: {alb.PictureCount}");
            }
        }

        private void ListSharedAlbums(SocialNetworkContext db)
        {
            var albums = db.Albums
                .Where(a => a.AlbumHolders.Where(ah => ah.Role == Role.Viewer).Count() > 2)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    SharedCount = a.AlbumHolders.Where(ah => ah.Role == Role.Viewer).Count(),
                    IsPublic = a.IsPublic
                })
                .OrderByDescending(a => a.SharedCount)
                .ThenBy(a => a.AlbumName)
                .ToList();

            foreach (var alb in albums)
            {
                Console.WriteLine($"Album: {alb.AlbumName}");
                Console.WriteLine($"-Shared with: {alb.SharedCount} people");
                Console.WriteLine($"-Access is {(alb.IsPublic ? "public" : "private")}");
            }
        }

        private void ListUsersAndAlbumViewers(SocialNetworkContext db)
        {
            var usrs = db.Users
                .Select(u => new
                {
                    u.Username,
                    FollowerIds = u.Followers.Select(f => f.SecondUserId),
                    AlbumsOwnedIds = u.Albums
                                        .Where(a => a.Role == Role.Owner)
                                        .Select(a => a.AlbumId)
                })
                .OrderBy(u => u.Username)
                .ToList();

            foreach (var us in usrs)
            {
                var sb = new StringBuilder();

                bool userNameAppended = false;

                foreach (var fol in us.FollowerIds)
                {
                    var follower = db.Users
                        .Include(u => u.Albums)
                        .First(f => f.Id == fol);

                    foreach (var alb in follower.Albums)
                    {
                        db.Entry(alb).Reference(u => u.Album).Load();
                    }

                    var albumNames = follower.Albums
                        .Where(a => us.AlbumsOwnedIds.Contains(a.AlbumId))
                        .Select(a => a.Album.Name)
                        .ToList();
                    if (albumNames.Count > 0)
                    {
                        if (userNameAppended == false)
                        {
                            sb.AppendLine($"User: { us.Username}");
                            userNameAppended = true;
                        }

                        sb.AppendLine($"-Follower: {follower.Username}");

                        string result = string.Join(", ", albumNames);

                        sb.AppendLine($"--Albums shared: {result}");
                    }
                }

                if (sb.Length > 0)
                {
                    Console.WriteLine(sb.ToString().Trim());
                }
            }
        }

        private void ListUsersWithAlbumsWithMoreThanThreeTags(SocialNetworkContext db)
        {
            Console.WriteLine($"Listing all users that have albums with more than 3 tags:");

            var users = db.Users
                .Where(u => u.Albums.Select(a => a.Album).Where(ua => ua.Tags.Count > 3).Count() > 0)
                .Select(u => new
                {
                    User = u.Username,
                    Albums = u.Albums.Select(ua => ua.Album).Select(a => new
                    {
                        AlbumName = a.Name,
                        Tags = a.Tags.Select(t => t.Tag.Title)
                    })
                })
                .ToList()
                .OrderByDescending(u => u.Albums.Count())
                .ThenByDescending(u => u.Albums.Sum(a => a.Tags.Count()))
                .ThenBy(u => u.User);

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.User}");
                foreach (var alb in user.Albums)
                {
                    Console.WriteLine($"-Album: {alb.AlbumName}");
                    Console.WriteLine($"--Tags: {string.Join(", ", alb.Tags)}");
                }
            }
        }

        private void ListAllAlbumsWithGivenTag(SocialNetworkContext db)
        {
            var specialTag = db.Tags.OrderBy(t => Guid.NewGuid()).Select(t => t.Title).First();

            Console.WriteLine($"Listing all albums with tag: {specialTag}");

            var albumsWithTag = db.Albums
                .Where(a => a.Tags.Any(at => at.Tag.Title == specialTag))
                .OrderByDescending(a => a.Tags.Count)
                .ThenBy(a => a.Name)
                .Select(a => new
                {
                    AlbumTitle = a.Name,
                    Owner = a.AlbumHolders.First(ah => ah.Role == Role.Owner).User.Username
                })
                .ToList();

            foreach (var alb in albumsWithTag)
            {
                Console.WriteLine($"Album: {alb.AlbumTitle}");
                Console.WriteLine($"-Owner: {alb.Owner}");
            }

            if (albumsWithTag.Count == 0)
            {
                Console.WriteLine($"No albums with tag \"{specialTag}\" available.");
            }
        }

        private void AddTagsToAlbums(SocialNetworkContext db)
        {
            string[] sampleTags = new string[] { "#TestTag1", "#TestTag2", "#TestTag3", "#TestTag4", "#TestTag5" };

            foreach (var tag in sampleTags)
            {
                if (!db.Tags.Any(t => t.Title == tag))
                {
                    db.Tags.Add(new Tag
                    {
                        Title = tag
                    });
                }
                db.SaveChanges();
            }

            Random rnd = new Random();

            var albums = db.Albums.Include(a => a.Tags).ToList();
            var dbTagIds = db.Tags.Select(t => t.Id).ToList();

            Console.WriteLine("Populating albums with tags...");

            foreach (var alb in albums)
            {
                int tagCount = rnd.Next(1, dbTagIds.Count);

                while (alb.Tags.Count < tagCount)
                {
                    var tagId = dbTagIds[rnd.Next(0, dbTagIds.Count)];

                    if (alb.Tags.Any(at => at.TagId == tagId))
                    {
                        continue;
                    }
                    else
                    {
                        alb.Tags.Add(new AlbumTag
                        {
                            TagId = tagId
                        });
                    }
                }
            }

            db.SaveChanges();

            Console.WriteLine("Done.");
        }

        private void RegisterUserTags(SocialNetworkContext db)
        {
            Console.WriteLine("Enter a tag value or leave empty to continue.");

            while (true)
            {
                Console.Write("Title of tag: ");
                string tagValue = Console.ReadLine();

                if (string.IsNullOrEmpty(tagValue) || string.IsNullOrWhiteSpace(tagValue))
                {
                    Console.WriteLine("Continuing..");
                    break;
                }
                else
                {
                    if (!TagValidator.ValidateTag(tagValue))
                    {
                        tagValue = TagTransformer.Transform(tagValue);
                    }

                    if (TagValidator.ValidateTag(tagValue))
                    {
                        var tag = new Tag
                        {
                            Title = tagValue
                        };

                        if (db.Tags.Any(t => t.Title == tagValue))
                        {
                            Console.WriteLine($"Database already contains such a tag: {tagValue}");
                        }
                        else
                        {
                            db.Tags.Add(tag);

                            db.SaveChanges();

                            Console.WriteLine($"Tag: {tagValue} was added to the database.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid tag.");
                    }
                }
            }
        }

        private void ListAllUserAlbums(SocialNetworkContext db)
        {
            var userId = db.Users.First().Id;

            var userAlbums = db.Users.Where(u => u.Id == userId)
                .Select(u => new
                {
                    u.Username,
                    AlbumInfo = u.Albums.Select(a => new
                    {
                        AlbumTitle = a.Album.Name,
                        Pictures = a.Album.Pictures
                            .Where(al => al.Album.IsPublic).Select(p => new
                            {
                                p.Picture.Title,
                                p.Picture.FilePath
                            })
                    }).OrderBy(a => a.AlbumTitle)
                })
                .ToList();

            foreach (var usr in userAlbums)
            {
                Console.WriteLine($"User: {usr.Username}");
                foreach (var album in usr.AlbumInfo)
                {
                    Console.WriteLine($"-Album name: {album.AlbumTitle}");
                    if (album.Pictures.Count() > 0)
                    {
                        foreach (var pic in album.Pictures)
                        {
                            Console.WriteLine($"--Picture title: {pic.Title}");
                            Console.WriteLine($"---File Path: {pic.FilePath} ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("--Private content!");
                    }
                }
            }
        }

        private void ListPictureInMultipleAlbums(SocialNetworkContext db)
        {
            var pictures = db.Pictures
                .Where(p => p.Albums.Count > 2)
                .Select(p => new
                {
                    p.Title,
                    AlbumsTitlesAndOwners = p.Albums.Select(a => new
                    {
                        a.Album.Name,
                        Holders = a.Album.AlbumHolders//a.Album.AlbumHolders.First(ah => ah.Role == Role.Owner).User.Username //This is not working because of reasons unknown =/
                    })
                })
                .OrderByDescending(p => p.AlbumsTitlesAndOwners.Count())
                .ThenBy(p => p.Title)
                .ToList();

            foreach (var pic in pictures)
            {
                Console.WriteLine($"Picture: {pic.Title}");
                foreach (var alb in pic.AlbumsTitlesAndOwners)
                {
                    var ownerName = GetOwnerFromHoldersCollection(db, alb.Holders);

                    Console.WriteLine($"--Album name: {alb.Name}");
                    Console.WriteLine($"---Album owner: {ownerName}");
                }
            }
        }

        private string GetOwnerFromHoldersCollection(SocialNetworkContext db, ICollection<UserAlbum> holders)
        {
            var userId = holders.Where(a => a.Role == Role.Owner).First().UserId;

            var ownerName = db.Users.First(u => u.Id == userId).Username;

            return ownerName;
        }

        private void ListAlbumsAndOwners(SocialNetworkContext db)
        {
            var albumOwners = db.Albums
                .Select(a => new
                {
                    a.Name,
                    OwnerName = a.AlbumHolders.First(ah => ah.Role == Role.Owner).User.Username,
                    PicturesCount = a.Pictures.Count()
                })
                .OrderByDescending(ao => ao.PicturesCount)
                .ThenBy(ao => ao.OwnerName)
                .ToList();

            foreach (var alb in albumOwners)
            {
                Console.WriteLine($"Album: {alb.Name}");
                Console.WriteLine($"--Owner: {alb.OwnerName}");
                Console.WriteLine($"--Picture count: {alb.PicturesCount}");
            }
        }

        private void SeedDDBWithAlbums(SocialNetworkContext db)
        {
            var HasNoAlbums = db.Albums.Count() == 0;

            if (HasNoAlbums)
            {
                Console.WriteLine("Seeding albums and pictures...");

                var user1 = db.Users.FirstOrDefault(u => u.Username == "Gosho");
                var user2 = db.Users.FirstOrDefault(u => u.Username == "Pesho");
                var user3 = db.Users.FirstOrDefault(u => u.Username == "Minko");
                var user4 = db.Users.FirstOrDefault(u => u.Username == "Bot5");
                var user5 = db.Users.FirstOrDefault(u => u.Username == "Bot6");
                var user6 = db.Users.FirstOrDefault(u => u.Username == "Bot7");

                var album1 = new Album
                {
                    Name = "AlbumLoL",
                    BackgroundColour = "Brown",
                    IsPublic = true
                };

                var album2 = new Album
                {
                    Name = "AlbumSmok",
                    BackgroundColour = "Black",
                    IsPublic = false
                };

                var album3 = new Album
                {
                    Name = "AlbumBok",
                    BackgroundColour = "Purple",
                    IsPublic = true
                };

                var album4 = new Album
                {
                    Name = "AlbumShliok",
                    BackgroundColour = "Rose",
                    IsPublic = true
                };

                var album5 = new Album
                {
                    Name = "AlbumTrop",
                    BackgroundColour = "Pink",
                    IsPublic = false
                };

                var pic1 = new Picture
                {
                    Title = "DSLR1.JPG",
                    Caption = "LoremIpsum1",
                    FilePath = @"C:\Lorem\Ipsum"
                };
                var pic2 = new Picture
                {
                    Title = "DSLR2.JPG",
                    Caption = "LoremIpsum2",
                    FilePath = @"C:\Lorem\Ipsum"
                };
                var pic3 = new Picture
                {
                    Title = "DSLR3.JPG",
                    Caption = "LoremIpsum3",
                    FilePath = @"C:\Lorem\Ipsum"
                };
                var pic4 = new Picture
                {
                    Title = "DSLR4.PNG",
                    Caption = "LoremIpsum4",
                    FilePath = @"C:\Lorem\Ipsum"
                };
                var pic5 = new Picture
                {
                    Title = "DSLR5.PNG",
                    Caption = "LoremIpsum5",
                    FilePath = @"C:\Lorem\Ipsum"
                };

                db.Albums.Add(album1);
                db.Albums.Add(album2);
                db.Albums.Add(album3);
                db.Albums.Add(album4);
                db.Albums.Add(album5);

                db.Pictures.Add(pic1);
                db.Pictures.Add(pic2);
                db.Pictures.Add(pic3);
                db.Pictures.Add(pic4);
                db.Pictures.Add(pic5);

                db.SaveChanges();

                album1.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user1.Id,
                    Role = Role.Owner
                });

                album1.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user2.Id,
                    Role = Role.Viewer
                });

                album1.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user3.Id,
                    Role = Role.Viewer
                });

                album1.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user4.Id,
                    Role = Role.Viewer
                });

                album1.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user5.Id,
                    Role = Role.Viewer
                });

                album1.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user6.Id,
                    Role = Role.Viewer
                });

                album2.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user1.Id,
                    Role = Role.Owner
                });
                album2.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user3.Id,
                    Role = Role.Viewer
                });

                album3.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user1.Id,
                    Role = Role.Owner
                });
                album3.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user3.Id,
                    Role = Role.Viewer
                });

                album4.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user2.Id,
                    Role = Role.Owner
                });
                album4.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user1.Id,
                    Role = Role.Viewer
                });

                album5.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user3.Id,
                    Role = Role.Owner
                });
                album5.AlbumHolders.Add(new UserAlbum
                {
                    UserId = user1.Id,
                    Role = Role.Viewer
                });

                db.SaveChanges();

                album1.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic1.Id
                });

                album1.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic2.Id
                });

                album1.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic3.Id
                });

                album1.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic4.Id
                });

                album1.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic5.Id
                });

                album4.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic1.Id
                });

                album4.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic3.Id
                });

                album2.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic3.Id
                });

                album3.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic3.Id
                });

                album5.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic1.Id
                });

                album5.Pictures.Add(new AlbumPicture
                {
                    PictureId = pic5.Id
                });

                db.SaveChanges();

                Console.WriteLine("Seeding albums and pictures done.");
            }
        }

        private void ListActiveUsersWithFriends(SocialNetworkContext db)
        {
            var activeUsers = db.Users
                .Where(u => u.IsDeleted == false && u.Followers.Count > 5)
                .Select(u => new
                {
                    u.Username,
                    FriendsCount = u.Followers.Count,
                    DaysPeriod = DateTime.Now.Subtract(u.RegisteredOn).Days,
                    RegistrationDate = u.RegisteredOn
                })
                .OrderBy(au => au.RegistrationDate)
                .ThenByDescending(au => au.FriendsCount)
                .ToList();

            foreach (var user in activeUsers)
            {
                Console.WriteLine($"User: {user.Username}");
                Console.WriteLine($"--Friends count: {user.FriendsCount}");
                Console.WriteLine($"--Member since: {user.DaysPeriod} days");
            }
        }

        private void ListAllUsersWithFriendsCount(SocialNetworkContext db)
        {
            var friendsInfo = db.Users
                .Select(u => new
                {
                    u.Username,
                    FriendsCount = u.Followers.Count,
                    u.IsDeleted
                })
                .OrderByDescending(fi => fi.FriendsCount)
                .ThenBy(fi => fi.Username)
                .ToList();

            foreach (var user in friendsInfo)
            {
                Console.WriteLine($"User: {user.Username}");
                Console.WriteLine($"--Friends count: {user.FriendsCount}");
                Console.WriteLine($"--Status: {(user.IsDeleted ? "Inactive" : "Active")}");
            }
        }

        private void SeeDDbIfEmpty(SocialNetworkContext db)
        {
            bool dbHasNoUsers = db.Users.Count() == 0;

            if (dbHasNoUsers)
            {
                Console.WriteLine("Seeding database...");

                var user1 = new User
                {
                    Username = "Gosho",
                    Password = "123@Gog",
                    Email = "dadsd.goshov@abv.bg",
                    RegisteredOn = new DateTime(2015, 10, 20),
                    Age = 20
                };

                var user2 = new User
                {
                    Username = "Pesho",
                    Password = "123@Gog",
                    Email = "Goppppsho.goshov@abv.bg",
                    RegisteredOn = new DateTime(2015, 9, 19),
                    Age = 30
                };

                var user3 = new User
                {
                    Username = "Minko",
                    Password = "123@Gog",
                    Email = "popopo.goshov@abv.bg",
                    RegisteredOn = new DateTime(2015, 3, 12),
                    Age = 50
                };

                var user4 = new User
                {
                    Username = "Dinko",
                    Password = "123@Gog",
                    Email = "dofofofo.goshov@abv.bg",
                    RegisteredOn = new DateTime(2015, 5, 16),
                    Age = 10
                };

                var user5 = new User
                {
                    Username = "Bot5",
                    Password = "bot5@Gog",
                    Email = "55555.goshov@abv.bg",
                    RegisteredOn = new DateTime(200, 1, 16),
                    Age = 1
                };

                var user6 = new User
                {
                    Username = "Bot6",
                    Password = "bot6@Gog",
                    Email = "66666.goshov@abv.bg",
                    RegisteredOn = new DateTime(2000, 2, 16),
                    Age = 2
                };

                var user7 = new User
                {
                    Username = "Bot7",
                    Password = "bot7@Gog",
                    Email = "77777.goshov@abv.bg",
                    RegisteredOn = new DateTime(2000, 3, 16),
                    Age = 3
                };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Users.Add(user3);
                db.Users.Add(user4);
                db.Users.Add(user5);
                db.Users.Add(user6);
                db.Users.Add(user7);

                db.SaveChanges();

                user1.Followers.Add(new UserFriend
                {
                    FirstUserId = user1.Id,
                    SecondUserId = user2.Id
                });

                user1.Followers.Add(new UserFriend
                {
                    FirstUserId = user1.Id,
                    SecondUserId = user3.Id
                });

                user1.Followers.Add(new UserFriend
                {
                    FirstUserId = user1.Id,
                    SecondUserId = user4.Id
                });

                user1.Followers.Add(new UserFriend
                {
                    FirstUserId = user1.Id,
                    SecondUserId = user5.Id
                });

                user1.Followers.Add(new UserFriend
                {
                    FirstUserId = user1.Id,
                    SecondUserId = user6.Id
                });

                user1.Followers.Add(new UserFriend
                {
                    FirstUserId = user1.Id,
                    SecondUserId = user7.Id
                });

                user2.Followers.Add(new UserFriend
                {
                    FirstUserId = user2.Id,
                    SecondUserId = user3.Id
                });

                user2.Followers.Add(new UserFriend
                {
                    FirstUserId = user2.Id,
                    SecondUserId = user4.Id
                });

                user3.Followers.Add(new UserFriend
                {
                    FirstUserId = user3.Id,
                    SecondUserId = user4.Id
                });

                db.SaveChanges();

                Console.WriteLine("Seeding done.");
            }
        }
    }
}
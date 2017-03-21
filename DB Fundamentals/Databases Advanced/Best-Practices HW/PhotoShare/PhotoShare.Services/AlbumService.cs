using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Services
{
    public class AlbumService
    {
        public void CreateUserAlbum(string username, string albumTitle, Color bgColor, string[] tags)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var album = new Album();

                album.BackgroundColor = bgColor;
                album.IsPublic = true;
                album.Name = albumTitle;


                List<Tag> tagsToAdd = new List<Tag>();

                foreach (var tag in tags)
                {
                    Tag t = context.Tags.FirstOrDefault(x => x.Name == tag);

                    tagsToAdd.Add(t);
                }

                if (tagsToAdd.Count > 0)
                {
                    album.Tags = tagsToAdd;
                }

                var user = context.Users.FirstOrDefault(u => u.Username == username);

                var albRole = new AlbumRole();

                Role role = Role.Owner;

                albRole.Album = album;
                albRole.User = user;
                albRole.Role = role;

                context.AlbumRoles.Add(albRole);
                context.SaveChanges();
            }
        }

        public void ShareAlbum(int albumId, string username, string permission)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var album = context.Albums.FirstOrDefault(a => a.Id == albumId);

                var user = context.Users.FirstOrDefault(u => u.Username == username);

                Role role = new Role();

                if (permission == "Owner")
                {
                    role = Role.Owner;
                }
                else
                {
                    role = Role.Viewer;
                }

                AlbumRole albRole = new AlbumRole();

                albRole.Album = album;
                albRole.User = user;
                albRole.Role = role;

                context.AlbumRoles.Add(albRole);

                context.SaveChanges();
            }
        }

        public List<string> GetAlbumOwners(int albumId)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                List<string> owners = new List<string>();

                owners = context.Albums
                    .FirstOrDefault(a => a.Id == albumId)
                    .AlbumRoles
                    .Where(r => r.Role == Role.Owner)
                    .Select(s => s.User.Username)
                    .ToList();

                return owners;
            }
        }

        public List<string> GetAlbumOwners(string albumTitle)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                List<string> owners = new List<string>();

                owners = context.Albums
                    .FirstOrDefault(a => a.Name == albumTitle)
                    .AlbumRoles
                    .Where(r => r.Role == Role.Owner)
                    .Select(s => s.User.Username)
                    .ToList();

                return owners;
            }
        }

        public bool AlbumExists(string albumTitle)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == albumTitle);
            }
        }

        public bool AlbumExists(int albumId)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Id == albumId);
            }
        }
    }
}

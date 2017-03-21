using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Services
{
    public class TagService
    {
        public void Add(string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Tags.Add(new Tag
                {
                    Name = tagName
                });

                context.SaveChanges();
            }
        }

        public bool TagExists(string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tagName);
            }
        }

        public void AddTagToAlbum(string albumName, string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var album = context.Albums.FirstOrDefault(a => a.Name == albumName);

                var tag = context.Tags.FirstOrDefault(t => t.Name == tagName);


                album.Tags.Add(tag);

                context.SaveChanges();
            }
        }

        public bool TagsExist(string[] tags)
        {
            if (tags.All(x => TagExists(x)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

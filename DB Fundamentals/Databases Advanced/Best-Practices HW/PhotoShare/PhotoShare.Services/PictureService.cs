using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Services
{
    public class PictureService
    {
        public void Upload(string albumTitle, string pictureTitle, string pictureFilePath)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var album = context.Albums.FirstOrDefault(a => a.Name == albumTitle);

                Picture pic = new Picture();

                pic.Title = pictureTitle;
                pic.Path = pictureFilePath;

                album.Pictures.Add(pic);

                context.Pictures.Add(pic);

                context.SaveChanges();
            }
        }
    }
}

namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Models;
    using PhotoShare.Services;
    using System;
    using System.Linq;

    public class CreateAlbumCommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        private readonly AlbumService albumService;
        private readonly UserService userService;
        private readonly TagService tagService;
        public CreateAlbumCommand(AlbumService albumService, UserService userService, TagService tagService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
        }
        public string Execute(string[] data)
        {
            string username = data[0];
            string albumTitle = data[1];
            string bgColor = data[2];
            string[] tags = data.Skip(3).ToArray();



            if (!this.userService.UserExists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (this.albumService.AlbumExists(albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            Color color;
            bool isColorValid = Enum.TryParse(bgColor, out color);
            if (!isColorValid)
            {
                throw new ArgumentException($"Color {bgColor} not found!");
            }


            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = tags[i].ValidateOrTransform();
            }

            if (!this.tagService.TagsExist(tags))
            {
                throw new ArgumentException("Invalid tags!");
            }

            this.albumService.CreateUserAlbum(username, albumTitle, color, tags);

            return "Album " + albumTitle + " successfully created!";
        }
    }
}

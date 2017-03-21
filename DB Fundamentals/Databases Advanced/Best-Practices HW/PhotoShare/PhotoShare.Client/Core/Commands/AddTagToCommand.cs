namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Services;
    using System;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Models;
    using System.Collections.Generic;

    public class AddTagToCommand
    {
        private readonly TagService tagService;
        private readonly AlbumService albumService;
        public AddTagToCommand(TagService tagService, AlbumService albumService)
        {
            this.tagService = tagService;
            this.albumService = albumService;
        }
        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {

            string albumName = data[0];
            string tagName = data[1].ValidateOrTransform();

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            if (!tagService.TagExists(tagName) || !albumService.AlbumExists(albumName))
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            User currentUser = AuthenticationService.GetCurrentUser();

            List<string> owners = albumService.GetAlbumOwners(albumName);

            if (!owners.Contains(currentUser.Username))
            {
                throw new InvalidOperationException("Invalid credentials");
            }



            tagService.AddTagToAlbum(albumName, tagName);

            return "Tag " + tagName + " added to " + albumName + "!";
        }
    }
}

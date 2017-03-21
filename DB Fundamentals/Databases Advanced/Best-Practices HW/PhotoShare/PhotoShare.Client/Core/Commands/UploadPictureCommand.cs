namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using PhotoShare.Services;
    using System;
    using System.Collections.Generic;

    public class UploadPictureCommand
    {
        private readonly AlbumService albumService;
        private readonly PictureService pictureService;
        public UploadPictureCommand(AlbumService albumService, PictureService pictureService)
        {
            this.albumService = albumService;
            this.pictureService = pictureService;
        }
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string pictureTitle = data[1];
            string pictureFilePath = data[2];

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            User currentUser = AuthenticationService.GetCurrentUser();

            List<string> owners = albumService.GetAlbumOwners(albumName);

            if (!owners.Contains(currentUser.Username))
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            if (!albumService.AlbumExists(albumName))
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            pictureService.Upload(albumName, pictureTitle, pictureFilePath);

            return "Picture " + pictureTitle + " added to " + albumName + "!";
        }
    }
}

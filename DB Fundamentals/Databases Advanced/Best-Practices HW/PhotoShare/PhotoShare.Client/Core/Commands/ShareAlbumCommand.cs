namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using PhotoShare.Services;
    using System;
    using System.Collections.Generic;

    public class ShareAlbumCommand
    {
        private readonly UserService userService;
        private readonly AlbumService albumService;
        public ShareAlbumCommand(UserService userService, AlbumService albumService)
        {
            this.userService = userService;
            this.albumService = albumService;
        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            int albumId = int.Parse(data[0]);
            string username = data[1];
            string permission = data[2];

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            User currentUser = AuthenticationService.GetCurrentUser();

            if (!albumService.AlbumExists(albumId))
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            if (!userService.UserExists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (permission != "Owner" && permission != "Viewer")
            {
                throw new ArgumentException($"Permission must be either \"Owner\" or \"Viewer\"!");
            }

           List<string> owners = albumService.GetAlbumOwners(albumId);

            if (!owners.Contains(currentUser.Username))
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            albumService.ShareAlbum(albumId, username, permission);

            string result = $"Username {username} added to album {albumId} ({permission})";

            return result;
        }
    }
}

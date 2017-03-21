namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using PhotoShare.Services;
    using System;
    using Utilities;

    public class AddTagCommand
    {
        private TagService tagService;
        public AddTagCommand(TagService tagService)
        {
            this.tagService = tagService;
        }
        // AddTag <tag>
        public string Execute(string[] data)
        {
            string tag = data[0].ValidateOrTransform();

            if (!AuthenticationService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials");
            }

            if (this.tagService.TagExists(tag))
            {
                throw new ArgumentException($"Tag {tag} exists!");
            }

            this.tagService.Add(tag);

            return tag + " was added successfully!";
        }
    }
}

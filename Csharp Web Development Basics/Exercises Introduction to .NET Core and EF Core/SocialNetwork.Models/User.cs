using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [RegularExpression(@"^(?=[^\s]*[a-z])(?=[^\s]*[A-Z])(?=[^\s]*\d)(?=[^\s]*[!@#$%^&*()_+<>?])[^\s]{6,50}$", ErrorMessage = "The password is not valid!")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9]+[.-_]?[a-zA-Z0-9]+)(@)[a-zA-Z0-9]+(\.[a-zA-Z0-9]{2,})+$", ErrorMessage = "The Email is not valid!")]
        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<UserFriend> Followers { get; set; } = new List<UserFriend>();

        public ICollection<UserFriend> Following { get; set; } = new List<UserFriend>();

        public ICollection<UserAlbum> Albums { get; set; } = new List<UserAlbum>();
    }
}
namespace PhotoShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    using Validation;

    public class User
    {
        private ICollection<User> friends;
        private ICollection<AlbumRole> albumRoles;

        public User()
        {
            this.friends = new HashSet<User>();
            this.albumRoles = new HashSet<AlbumRole>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        [Password(6, 50, ContainsDigit = true, ContainsLowercase = true, ErrorMessage = "Invalid password")]
        public string Password { get; set; }

        [Required]
        [Email]
        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }

        [NotMapped]
        public Image ProfileImage
        {
            get
            {
                var stream = new MemoryStream(this.ProfilePicture.Length);

                this.ProfilePicture
                    .ToList()
                    .ForEach(b => stream.WriteByte(b));
                
                return Image.FromStream(stream);
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";

        public virtual Town BornTown { get; set; }

        public virtual Town CurrentTown { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Age]
        public int? Age { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }

        public virtual ICollection<AlbumRole> AlbumRoles
        {
            get { return this.albumRoles; }
            set { this.albumRoles = value; }
        }

        public override string ToString()
        {
            return $"{this.Username} {this.Email} {this.Age} {this.FullName}";
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;


namespace UsersDB.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string Username { get; set; }

        [MinLength(6)]
        [MaxLength(50)]
        [RegularExpression(@"^.*(?=.{6,50})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+<>?]{1,}).*$")]
        public string Password { get; set; }

        [RegularExpression(@"^([A-Za-z0-9]+)([\w\.\-]*)([A-Za-z0-9]+)@([[A-Za-z0-9]+(\-*[A-Za-z0-9])*)((\.([A-Za-z0-9]){2,3})+)$")]
        [Required]
        public string Email { get; set; }
        
        [MaxLength(1000000)]
        public byte[] ProfilePicture { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisteredOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastTimeLoggedIn { get; set; }

        [Range(minimum:1, maximum:120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}

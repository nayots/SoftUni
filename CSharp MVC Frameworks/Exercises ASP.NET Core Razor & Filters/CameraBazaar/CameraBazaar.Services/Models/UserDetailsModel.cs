using System;

namespace CameraBazaar.Services.Models
{
    public class UserDetailsModel
    {
        public string Username { get; set; }

        public string UserId { get; set; }

        public DateTime? LastLogin { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int InStockCameras { get; set; }

        public int OutOfStockCameras { get; set; }
    }
}
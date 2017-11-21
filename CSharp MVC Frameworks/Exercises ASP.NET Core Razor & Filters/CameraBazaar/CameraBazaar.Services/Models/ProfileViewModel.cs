using System.Collections.Generic;

namespace CameraBazaar.Services.Models
{
    public class ProfileViewModel
    {
        public UserDetailsModel UserDetails { get; set; }

        public IEnumerable<CameraShortDetailsModel> Cameras { get; set; } = new List<CameraShortDetailsModel>();
    }
}
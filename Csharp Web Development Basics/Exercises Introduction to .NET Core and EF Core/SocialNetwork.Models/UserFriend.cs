namespace SocialNetwork.Models
{
    public class UserFriend
    {
        public int FirstUserId { get; set; }

        public User FirstUser { get; set; }

        public int SecondUserId { get; set; }

        public User SecondUser { get; set; }
    }
}
namespace FootballBetting.Models
{
    public class PlayerGame
    {
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
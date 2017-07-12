using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private IList<Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
    }

    public IList<Car> Participants
    {
        get { return this.participants; }
        protected set { this.participants = value; }
    }

    public int PrizePool
    {
        get { return this.prizePool; }
        protected set { this.prizePool = value; }
    }

    public string Route
    {
        get { return this.route; }
        protected set { this.route = value; }
    }

    public int Length
    {
        get { return this.length; }
        protected set { this.length = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        if (this.Participants.Count > 0)
        {
            sb.AppendLine($"{this.Route} - {this.Length}");
            var winners = this.Participants.OrderByDescending(p => this.GetPerformancePoints(p)).Take(3).ToList();

            int prize = 0;

            for (int i = 0; i < winners.Count; i++)
            {
                if (i == 0)
                {
                    prize = this.PrizePool * 50 / 100;
                }
                else if (i == 1)
                {
                    prize = this.PrizePool * 30 / 100;
                }
                else if (i == 2)
                {
                    prize = this.PrizePool * 20 / 100;
                }

                sb.AppendLine($"{i + 1}. {winners[i].Brand} {winners[i].Model} {this.GetPerformancePoints(winners[i])}PP - ${prize}");
            }
        }
        else
        {
            sb.AppendLine($"Cannot start the race with zero participants.");
        }

        return sb.ToString().Trim();
    }

    public abstract int GetPerformancePoints(Car car);
}
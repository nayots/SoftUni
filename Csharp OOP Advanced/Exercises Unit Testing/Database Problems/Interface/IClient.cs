using System.Collections.Generic;

namespace Exercises_Models.Interface
{
    public interface IClient
    {
        IList<ITweet> Tweets { get; set; }

        string Tweet(ITweet tweet);

        string ShowLastTweet();
    }
}
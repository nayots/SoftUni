using Exercises_Models.Interface;
using Exercises_Models.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace Exercises_Models.Tests
{
    [TestFixture]
    public class TweeterTests
    {
        private IClient tweeter;

        [SetUp]
        public void TestInit()
        {
            this.tweeter = new TweeterClient();
        }

        [Test]
        public void TweetNormalMessage()
        {
            this.tweeter.Tweet(new Tweet("Hello"));

            Assert.Pass();
        }

        [Test]
        public void TweetEmptyMessage()
        {
            Assert.Throws<ArgumentNullException>(() => this.tweeter.Tweet(new Tweet(string.Empty)));
        }

        [Test]
        public void TweetTooLongMessage()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.tweeter.Tweet(new Tweet(new string('a', 300))));
        }

        [Test]
        public void ClientRegistersTweet()
        {
            int countBefore = this.tweeter.Tweets.Count();

            this.tweeter.Tweet(new Tweet("Test"));

            Assert.AreEqual(countBefore + 1, this.tweeter.Tweets.Count);
        }

        [Test]
        public void ClientReturnsTweetMessage()
        {
            string result = string.Empty;

            result = this.tweeter.Tweet(new Tweet("Test"));

            Assert.AreEqual("Test", result);
        }

        [Test]
        public void DisplayLastTweet()
        {
            this.tweeter.Tweet(new Tweet("Test0"));
            this.tweeter.Tweet(new Tweet("Test1"));
            this.tweeter.Tweet(new Tweet("Test2"));
            this.tweeter.Tweet(new Tweet("Test3"));

            string result = this.tweeter.ShowLastTweet();

            Assert.AreEqual("Test3", result);
        }

        [Test]
        public void DisplayLastTweetWhenTweetsAreZeroThrowsExc()
        {
            Assert.Throws<InvalidOperationException>(() => this.tweeter.ShowLastTweet());
        }
    }
}
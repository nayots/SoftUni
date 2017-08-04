using Exercises_Models.Interface;
using System;

namespace Exercises_Models.Models
{
    public class Tweet : ITweet
    {
        public Tweet(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException();
            }

            if (message.Length > 255)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Message = message;
        }

        public string Message { get; set; }
    }
}
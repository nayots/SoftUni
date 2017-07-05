using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_OnlineRadioDatabase
{
    public class Song
    {
        private string artist;
        private string songName;
        private long minutes;
        private long seconds;
        private TimeSpan songLength;

        public Song(string artist, string songName, long minutes, long seconds)
        {
            this.Artist = artist;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.songLength = CalculateSongLength(this.Minutes, this.Seconds);
        }

        public TimeSpan SongLength
        {
            get
            {
                return this.songLength;
            }
        }

        private TimeSpan CalculateSongLength(long minutes, long seconds)
        {
            var secs = minutes * 60 + seconds;

            var result = TimeSpan.FromSeconds(secs);

            return result;
        }

        public long Seconds
        {
            get { return this.seconds; }
            private set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }

                this.seconds = value;
            }
        }

        public long Minutes
        {
            get { return this.minutes; }
            private set
            {
                if (value < 0 || value > 14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }

                this.minutes = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }

                this.songName = value;
            }
        }

        public string Artist
        {
            get { return this.artist; }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }

                this.artist = value;
            }
        }
    }
}
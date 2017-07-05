using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_OnlineRadioDatabase
{
    class Startup
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var tokens = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    string artistName = tokens[0];
                    string songName = tokens[1];
                    List<long> timeTokens = new List<long>();

                    try
                    {
                        timeTokens = tokens[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Invalid song length.");
                    }
                    long minutes = timeTokens[0];
                    long seconds = timeTokens[1];

                    Song song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine($"Songs added: {songs.Count}");
            TimeSpan totalTime = TimeSpan.FromSeconds(songs.Sum(s => s.SongLength.TotalSeconds));
            Console.WriteLine($"Playlist length: {totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s");
        }
    }
}
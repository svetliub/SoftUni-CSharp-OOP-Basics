using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numberOfSongs = int.Parse(Console.ReadLine());

        List<Song> songs = new List<Song>();

        for (int i = 0; i < numberOfSongs; i++)
        {
            try
            {
                string[] songTokens = Console.ReadLine().Split(';').ToArray();

                if (songTokens.Length < 3)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongException);
                }

                string artist = songTokens[0];
                string songName = songTokens[1];

                int[] length;

                try
                {
                    length = songTokens[2].Split(':', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                }
                catch
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongLengthException);
                }

                int minutes = length[0];
                int seconds = length[1];

                Song song = new Song(artist, songName, minutes, seconds);
                songs.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        int playListSeconds = songs.Sum(s => s.Seconds) % 60;
        int playListMinutes = (songs.Sum(s => s.Minutes) + songs.Sum(s => s.Seconds) / 60) % 60;
        int playListHours = (songs.Sum(s => s.Minutes) + songs.Sum(s => s.Seconds) / 60) / 60;

        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {playListHours}h {playListMinutes}m {playListSeconds}s");
    }
}
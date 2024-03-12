namespace SongPlaylist;

class Program
{
    static void Main(string[] args)
    {
        Playlist myPlaylist = new Playlist();

        myPlaylist.AddSong("Shape of You", "Ed Sheeran");
        myPlaylist.AddSong("Believer", "Imagine Dragons");
        myPlaylist.AddSong("Faded", "Alan Walker");

        Console.WriteLine("Playlist saat ini:");
        myPlaylist.PrintPlaylist();

        Console.WriteLine("\nMencari lagu 'Faded':");
        bool found = myPlaylist.FindSong("Faded");
        Console.WriteLine(found ? "Lagu ditemukan." : "Lagu tidak ditemukan.");

        Console.WriteLine("\nMenghapus lagu 'Believer':");
        myPlaylist.DeleteSong("Believer");
        myPlaylist.PrintPlaylist();
    }
}
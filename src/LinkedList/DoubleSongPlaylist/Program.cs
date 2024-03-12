namespace DoubleSongPlaylist;

class Program
{
    static void Main(string[] args)
    {
        SongPlaylist myPlaylist = new SongPlaylist();

        // Menambahkan beberapa lagu ke dalam playlist
        myPlaylist.AddSong("Shape of You");
        myPlaylist.AddSong("Believer");
        myPlaylist.AddSong("Faded");

        // Memainkan lagu saat ini
        myPlaylist.PrintCurrentSong();

        // Navigasi melalui playlist
        myPlaylist.PlayNext(); // Memainkan lagu selanjutnya
        myPlaylist.PlayPrevious(); // Kembali ke lagu sebelumnya
    }
}
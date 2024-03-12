using System;

namespace DoubleSongPlaylist;

public class SongPlaylist
{
    private SongNode current;

    public class SongNode
    {
        public string Title;
        public SongNode Prev;
        public SongNode Next;

        public SongNode(string title)
        {
            Title = title;
            Prev = null;
            Next = null;
        }
    }

    public SongPlaylist()
    {
        current = null;
    }

    // Menambahkan lagu baru ke playlist
    public void AddSong(string title)
    {
        SongNode newNode = new SongNode(title);
        if (current == null)
        {
            current = newNode;
            newNode.Next = newNode;
            newNode.Prev = newNode;
        }
        else
        {
            newNode.Prev = current;
            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            current.Next = newNode;
        }
    }

    // Memainkan lagu selanjutnya
    public void PlayNext()
    {
        if (current != null && current.Next != null)
        {
            current = current.Next;
            PrintCurrentSong();
        }
    }

    // Memainkan lagu sebelumnya
    public void PlayPrevious()
    {
        if (current != null && current.Prev != null)
        {
            current = current.Prev;
            PrintCurrentSong();
        }
    }

    // Mencetak lagu saat ini
    public void PrintCurrentSong()
    {
        if (current != null)
        {
            Console.WriteLine($"Memainkan sekarang: {current.Title}");
        }
        else
        {
            Console.WriteLine("Playlist kosong.");
        }
    }
}

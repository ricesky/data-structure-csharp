namespace SongPlaylist;

public class Playlist
{
    private SongNode head;

    public class SongNode
    {
        public string Title;
        public string Artist;
        public SongNode Next;

        public SongNode(string title, string artist)
        {
            Title = title;
            Artist = artist;
            Next = null;
        }
    }

    public void AddSong(string title, string artist)
    {
        SongNode newNode = new SongNode(title, artist);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            SongNode last = GetLastNode();
            last.Next = newNode;
        }
    }

    private SongNode GetLastNode()
    {
        SongNode temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        return temp;
    }

    public bool FindSong(string title)
    {
        SongNode current = head;
        while (current != null)
        {
            if (current.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void DeleteSong(string title)
    {
        SongNode current = head;
        SongNode previous = null;

        while (current != null && !current.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
        {
            previous = current;
            current = current.Next;
        }

        if (current == null)
        {
            Console.WriteLine("Lagu tidak ditemukan.");
            return;
        }

        if (previous == null)
        {
            // Lagu ada di kepala
            head = head.Next;
        }
        else
        {
            previous.Next = current.Next;
        }
    }

    public void PrintPlaylist()
    {
        SongNode current = head;
        while (current != null)
        {
            Console.WriteLine($"Judul: {current.Title}, Artis: {current.Artist}");
            current = current.Next;
        }
    }
}

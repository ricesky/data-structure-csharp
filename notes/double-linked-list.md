# Catatan Kuliah: Double Linked List

## Pengenalan Double Linked List

Double Linked List adalah variasi dari Linked List di mana setiap node memiliki dua referensi: satu menuju node berikutnya (next) dan satu lagi menuju node sebelumnya (prev). Struktur ini memungkinkan navigasi dua arah dalam list, yang meningkatkan fleksibilitas dalam operasi seperti penelusuran dan penghapusan.

## Nodes dan Nodes Chaining

Dalam Double Linked List, setiap node terdiri dari tiga komponen utama: data, referensi ke node berikutnya (next), dan referensi ke node sebelumnya (prev). Chaining terjadi dengan cara yang memungkinkan setiap node terhubung dengan node sebelum dan sesudahnya, menciptakan struktur yang dapat diakses dari kedua arah.

## Implementasi Node Double Linked List Menggunakan `class` di C#

Implementasi node untuk Double Linked List dalam C# dapat dilakukan dengan mendefinisikan `class` yang menyimpan data dan dua referensi ke node lainnya.

```csharp
public class DoublyNode
{
    public int Data;
    public DoublyNode Next;
    public DoublyNode Prev;

    public DoublyNode(int data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}
```

## Implementasi Node Double Linked List Menggunakan `struct` di C#

Sedangkan menggunakan `struct` mungkin tidak sesederhana dengan `class` karena `struct` di C# adalah tipe nilai dan umumnya digunakan untuk data yang lebih sederhana. Namun, Anda masih bisa mendefinisikannya dengan cara yang serupa.

```csharp
public struct DoublyNodeStruct
{
    public int Data;
    public DoublyNodeStruct? Next;
    public DoublyNodeStruct? Prev;

    public DoublyNodeStruct(int data, DoublyNodeStruct? next = null, DoublyNodeStruct? prev = null)
    {
        Data = data;
        Next = next;
        Prev = prev;
    }
}
```

## Operasi pada Double Linked List

### Menambahkan Item

- **AddFirst**: Menambahkan node baru sebagai head list. Kompleksitas: \(O(1)\).
- **AddLast**: Menambahkan node baru sebagai tail list. Kompleksitas: \(O(1)\) jika kita menyimpan referensi ke tail, \(O(n)\) jika tidak.
- **AddBefore**: Menambahkan node baru sebelum node tertentu. Kompleksitas: \(O(n)\).
- **AddAfter**: Menambahkan node baru setelah node tertentu. Kompleksitas: \(O(n)\).

Berikut adalah contoh kode program dalam bahasa C# yang menunjukkan cara menambahkan item ke dalam double linked list. Contoh ini mencakup fungsi untuk menambahkan node di awal list (`AddFirst`), di akhir list (`AddLast`), dan setelah node tertentu (`AddAfter`). Kode ini menggunakan `class` untuk mendefinisikan node dalam list:

```csharp
using System;

public class DoublyLinkedList
{
    public Node head;
    public Node tail;

    public class Node
    {
        public int data;
        public Node prev;
        public Node next;

        public Node(int d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }

    // Constructor
    public DoublyLinkedList()
    {
        head = null;
        tail = null;
    }

    // Menambahkan node di awal list
    public void AddFirst(int data)
    {
        Node newNode = new Node(data);
        newNode.next = head;
        newNode.prev = null;

        if (head != null)
        {
            head.prev = newNode;
        }

        head = newNode;

        if (tail == null)
        {
            tail = newNode;
        }
    }

    // Menambahkan node di akhir list
    public void AddLast(int data)
    {
        Node newNode = new Node(data);
        newNode.next = null;
        newNode.prev = tail;

        if (tail != null)
        {
            tail.next = newNode;
        }

        tail = newNode;

        if (head == null)
        {
            head = newNode;
        }
    }

    // Menambahkan node setelah node tertentu
    public void AddAfter(Node prevNode, int data)
    {
        if (prevNode == null)
        {
            Console.WriteLine("Node sebelumnya tidak boleh null");
            return;
        }

        Node newNode = new Node(data);
        newNode.next = prevNode.next;
        prevNode.next = newNode;
        newNode.prev = prevNode;

        if (newNode.next != null)
        {
            newNode.next.prev = newNode;
        }
        else
        {
            tail = newNode;
        }
    }

    // Menambahkan node sebelum node tertentu
    public void AddBefore(Node nextNode, int data)
    {
        if (nextNode == null)
        {
            Console.WriteLine("Node berikutnya tidak boleh null");
            return;
        }

        Node newNode = new Node(data);
        newNode.prev = nextNode.prev;
        nextNode.prev = newNode;
        newNode.next = nextNode;

        if (newNode.prev != null)
        {
            newNode.prev.next = newNode;
        }
        else
        {
            head = newNode;
        }
    }

    // Fungsi untuk mencetak list dari head ke tail
    public void PrintList()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList dll = new DoublyLinkedList();
        dll.AddLast(1); // Menambahkan 1 di akhir
        dll.AddLast(3); // Menambahkan 3 di akhir
        dll.AddFirst(0); // Menambahkan 0 di awal

        // Asumsikan kita ingin menambahkan 2 sebelum 3
        dll.AddBefore(dll.tail, 2); // Menambahkan 2 sebelum 3

        Console.WriteLine("Double Linked List setelah menambahkan node:");
        dll.PrintList();
        // Output seharusnya: 0 1 2 3
    }
}

```

Dalam contoh di atas, `DoublyLinkedList` adalah kelas yang mengelola double linked list, dan `Node` adalah kelas bantuan yang mendefinisikan elemen individu dalam list. Metode `AddFirst` menambahkan node baru di awal list, `AddLast` menambahkan di akhir, dan `AddAfter` menambahkan node baru setelah node tertentu yang ditunjuk. Metode `AddBefore` menambahkan sebuah node baru sebelum node tertentu (`nextNode`). Ini mencari node yang ada sebelum `nextNode`, menyesuaikan referensi `prev` dan `next` yang sesuai untuk memasukkan node baru ke dalam list. Jika node yang dimasukkan berada di posisi awal list (sehingga `nextNode` adalah `head`), maka node baru tersebut menjadi `head` baru dari list. Metode `PrintList` digunakan untuk mencetak isi dari list dari awal sampai akhir. 

### Enumerasi Double Linked List

- **Enumerate**: Iterasi dari head ke tail atau sebaliknya. Kompleksitas: \(O(n)\).

Untuk melakukan enumerasi atas elemen dalam double linked list dari head ke tail dan sebaliknya (dari tail ke head), kita bisa menambahkan dua metode tambahan pada kelas `DoublyLinkedList` yang sudah kita definisikan sebelumnya. Metode pertama akan mencetak elemen dari head ke tail, dan metode kedua dari tail ke head. Kode sebelumnya sudah mencakup metode untuk mencetak dari head ke tail, jadi kita hanya perlu menambahkan metode untuk enumerasi dari tail ke head.

Berikut adalah kode lengkap dengan penambahan metode `PrintListReverse` untuk mencetak elemen dari tail ke head:

```csharp
using System;

public class DoublyLinkedList
{
    private Node head;
    private Node tail;

    public class Node
    {
        public int data;
        public Node prev;
        public Node next;

        public Node(int d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }

    // Constructor dan metode lainnya...

    // Metode untuk mencetak list dari head ke tail
    public void PrintList()
    {
        Node temp = head;
        Console.WriteLine("Enumerasi dari head ke tail:");
        while (temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }
        Console.WriteLine();
    }

    // Metode baru untuk mencetak list dari tail ke head
    public void PrintListReverse()
    {
        Node temp = tail;
        Console.WriteLine("Enumerasi dari tail ke head:");
        while (temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.prev;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList dll = new DoublyLinkedList();
        dll.AddFirst(10); // Menambahkan 10 di awal
        dll.AddFirst(20); // Menambahkan 20 di awal, menjadi head baru
        dll.AddLast(5);  // Menambahkan 5 di akhir, menjadi tail
        dll.AddAfter(dll.head.next, 15); // Menambahkan 15 setelah node kedua (20)

        dll.PrintList(); // Menampilkan list dari head ke tail
        dll.PrintListReverse(); // Menampilkan list dari tail ke head
    }
}
```

Dalam implementasi ini, `PrintList` akan mencetak elemen dari head ke tail, seperti yang telah dijelaskan sebelumnya. Metode baru, `PrintListReverse`, dimulai dari node `tail` dan bergerak mundur melalui list dengan mengikuti referensi `prev` dari setiap node sampai mencapai `null`, yang menandakan telah mencapai awal list. Ini memungkinkan kita untuk melihat isi list dalam urutan terbalik tanpa perlu memodifikasi struktur list itu sendiri.

### Mencari Item

- **Find**: Mencari item berdasarkan data. Dapat dimulai dari head atau tail, tergantung kondisi. Kompleksitas: \(O(n)\).

Untuk mencari item dalam double linked list berdasarkan datanya, kita dapat menambahkan dua metode pencarian: satu untuk pencarian dari head (`FindFromHead`) dan satu lagi dari tail (`FindFromTail`). Metode ini akan mencari item dengan data yang ditentukan dan mengembalikan `true` jika item ditemukan, atau `false` jika tidak.

Berikut ini adalah penambahan metode pencarian pada kelas `DoublyLinkedList` yang sudah kita definisikan:

```csharp
using System;

public class DoublyLinkedList
{
    private Node head;
    private Node tail;

    public class Node
    {
        public int data;
        public Node prev;
        public Node next;

        public Node(int d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }

    // Constructor dan metode lainnya...

    // Metode untuk mencari item dari head
    public bool FindFromHead(int searchData)
    {
        Node current = head;
        while (current != null)
        {
            if (current.data == searchData)
            {
                return true; // Item ditemukan
            }
            current = current.next;
        }
        return false; // Item tidak ditemukan
    }

    // Metode untuk mencari item dari tail
    public bool FindFromTail(int searchData)
    {
        Node current = tail;
        while (current != null)
        {
            if (current.data == searchData)
            {
                return true; // Item ditemukan
            }
            current = current.prev;
        }
        return false; // Item tidak ditemukan
    }
}

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList dll = new DoublyLinkedList();
        dll.AddFirst(20);
        dll.AddLast(40);
        dll.AddFirst(10);
        dll.AddLast(50);

        int searchData = 40;
        bool foundFromHead = dll.FindFromHead(searchData);
        bool foundFromTail = dll.FindFromTail(searchData);

        Console.WriteLine($"Mencari {searchData} dari head: " + (foundFromHead ? "Ditemukan." : "Tidak ditemukan."));
        Console.WriteLine($"Mencari {searchData} dari tail: " + (foundFromTail ? "Ditemukan." : "Tidak ditemukan."));
    }
}
```

Dalam contoh di atas, `FindFromHead` dan `FindFromTail` memungkinkan pencarian data di double linked list dari kedua arah. Kedua metode ini memanfaatkan struktur double linked list yang memungkinkan navigasi dari kedua arah, meningkatkan fleksibilitas dalam menangani kasus di mana mungkin lebih efisien untuk memulai pencarian dari tail daripada head, atau sebaliknya, tergantung pada kondisi atau distribusi data dalam list.

### Menghapus Item

- **Delete**: Menghapus node tertentu dari list. Node yang dihapus dapat diakses langsung jika referensinya diketahui, meminimalisir kebutuhan untuk traversal. Kompleksitas: \(O(1)\) untuk penghapusan langsung, \(O(n)\) untuk mencari terlebih dahulu.

Untuk menghapus node tertentu dari double linked list dalam C#, kita dapat menambahkan metode `DeleteNode`. Metode ini akan mengambil sebuah referensi langsung ke node yang ingin dihapus, memanfaatkan struktur double linked list untuk meminimalisir traversal yang diperlukan. Berikut adalah kode lengkap dengan penambahan metode `DeleteNode`:

```csharp
using System;

public class DoublyLinkedList
{
    private Node head;
    private Node tail;

    public class Node
    {
        public int data;
        public Node prev;
        public Node next;

        public Node(int d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }

    // Constructor dan metode lainnya...

    // Metode untuk menghapus node tertentu
    public void DeleteNode(Node nodeToDelete)
    {
        // Jika list kosong atau nodeToDelete adalah null, tidak ada yang perlu dilakukan
        if (head == null || nodeToDelete == null)
        {
            return;
        }

        // Jika node yang dihapus adalah head
        if (nodeToDelete == head)
        {
            head = nodeToDelete.next;
        }

        // Jika node yang dihapus bukan head dan memiliki node sebelumnya (prev)
        if (nodeToDelete.prev != null)
        {
            nodeToDelete.prev.next = nodeToDelete.next;
        }

        // Jika node yang dihapus memiliki node setelahnya (next)
        if (nodeToDelete.next != null)
        {
            nodeToDelete.next.prev = nodeToDelete.prev;
        }

        // Jika node yang dihapus adalah tail
        if (nodeToDelete == tail)
        {
            tail = nodeToDelete.prev;
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList dll = new DoublyLinkedList();
        dll.AddFirst(10);
        dll.AddFirst(20);
        dll.AddFirst(30);

        Console.WriteLine("Sebelum penghapusan:");
        dll.PrintList();

        // Misalkan kita ingin menghapus node dengan data 20
        DoublyLinkedList.Node nodeToDelete = dll.head.next; // Mendapatkan referensi ke node yang akan dihapus
        dll.DeleteNode(nodeToDelete);

        Console.WriteLine("Setelah penghapusan:");
        dll.PrintList();
    }
}
```

Dalam contoh ini, `DeleteNode` menghapus node yang diberikan dari list dengan menyesuaikan referensi `prev` dan `next` dari node sebelum dan setelah node yang dihapus. Ini memastikan integritas list tetap terjaga. Metode ini efektif karena langsung bekerja dengan referensi node yang diketahui, tanpa perlu melakukan traversal list untuk menemukan node yang akan dihapus, sehingga operasi penghapusan menjadi lebih efisien.

## Contoh Studi Kasus: Playlist Lagu

Implementasi Double Linked List sangat cocok untuk mengelola playlist lagu, di mana setiap node menyimpan informasi tentang lagu (judul, artis) dan aplikasi dapat dengan mudah menambah, mencari, dan menghapus lagu, serta navigasi antar lagu dalam urutan maupun terbalik.

Untuk studi kasus playlist lagu yang menggunakan double linked list di C#, kita akan memperluas implementasi `DoublyLinkedList` dengan menambahkan fungsionalitas untuk navigasi lagu dalam urutan terbalik. Kita akan menambahkan metode untuk memainkan lagu selanjutnya (`PlayNext`) dan lagu sebelumnya (`PlayPrevious`), serta metode untuk mencetak lagu saat ini (`PrintCurrentSong`). Ini menunjukkan bagaimana navigasi dua arah dalam double linked list dapat dimanfaatkan dalam aplikasi nyata seperti playlist lagu.

```csharp
using System;

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
```

Dalam implementasi ini, `SongPlaylist` menggunakan `SongNode` yang memiliki referensi ke `Prev` dan `Next`, memungkinkan navigasi dua arah. Ketika lagu ditambahkan, dia ditautkan ke dalam struktur circular, di mana lagu terakhir yang ditambahkan selalu mengikuti `current`. Metode `PlayNext` dan `PlayPrevious` memanfaatkan sifat dua arah dari double linked list untuk memindahkan `current` ke lagu selanjutnya atau sebelumnya, sesuai dengan arah navigasi. `PrintCurrentSong` digunakan untuk menampilkan judul lagu yang sedang diputar.

Ini adalah contoh sederhana yang menunjukkan bagaimana double linked list dapat digunakan untuk mengelola dan navigasi sebuah playlist lagu dengan kemampuan untuk bergerak maju dan mundur melalui list lagu.

## Kesimpulan

Double Linked List menawarkan fleksibilitas yang lebih besar dibandingkan Single Linked List, terutama dalam hal navigasi dan beberapa operasi khusus seperti penghapusan dan penambahan di posisi tertentu dengan lebih efisien. Memahami struktur dan operasi dasarnya penting bagi pengembang untuk memanfaatkannya dalam berbagai aplikasi, termasuk pengelolaan data yang kompleks dan dinamis.
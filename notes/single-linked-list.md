# Catatan Kuliah: Linked List

## Pengenalan Linked List

Linked List adalah struktur data yang terdiri dari sekumpulan node di mana setiap node memiliki dua komponen: data dan referensi (atau link) ke node berikutnya dalam urutan. Berbeda dengan array, data dalam linked list tidak harus disimpan di memori yang berdekatan, memungkinkan penambahan atau penghapusan elemen dengan lebih efisien tanpa perlu memindahkan seluruh elemen lain.

## Nodes dan Nodes Chaining

Dalam konteks Linked List, sebuah node adalah elemen dasar yang menyimpan dua informasi: data (nilai dari elemen tersebut) dan referensi ke node lainnya (biasanya disebut sebagai "next" untuk Single Linked List dan ditambah "prev" untuk Double Linked List). Chaining terjadi ketika setiap node merujuk ke node berikutnya, menciptakan sebuah rangkaian atau chain.

## Single dan Double Linked List

- **Single Linked List** memiliki node dengan satu referensi ke node berikutnya. Ini memungkinkan perjalanan elemen hanya dalam satu arah, dari awal (head) ke akhir (tail).
  
- **Double Linked List** melangkah lebih jauh dengan memiliki node dengan dua referensi: satu ke node berikutnya dan satu lagi ke node sebelumnya. Hal ini memungkinkan navigasi dua arah, memberikan fleksibilitas lebih dalam operasi seperti penelusuran atau penghapusan.

## Single Linked List
  
## Implementasi Node Single Linked List menggunakan C# dengan Struct

Struktur Node dapat diimplementasikan menggunakan `struct` di C# untuk memberikan representasi yang lebih ringan dibandingkan dengan class. Berikut adalah contoh sederhana untuk Single Linked List:

```csharp
public struct Node
{
    public int data;
    public Node? next;

    public Node(int data)
    {
        this.data = data;
        this.next = null;
    }
}

public class LinkedList
{
    private Node? head;

    public LinkedList()
    {
        this.head = null;
    }

    // Metode lainnya akan ditambahkan di sini.
}
```

## Implementasi Node Single Linked List menggunakan C# dengan Class

Mari kita buat contoh implementasi linked list dalam C# menggunakan `class`.

```csharp
using System;

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        this.Data = data;
        this.Next = null;
    }
}

public class LinkedList
{
    private Node head;

    public LinkedList()
    {
        this.head = null;
    }

    // Metode lainnya akan ditambahkan di sini.
}
```

Kelas `Node` digunakan untuk merepresentasikan setiap elemen dalam linked list, menyimpan data dan referensi ke node berikutnya. Contoh ini memberikan landasan dasar untuk bekerja dengan linked list di C# menggunakan `class`, dan dapat diadaptasi atau diperluas berdasarkan kebutuhan spesifik.

## Operasi pada Linked List

### Menambahkan Item

Untuk menambahkan item, kita bisa menambahkannya di depan (menjadi head baru), di tengah (setelah node tertentu), atau di akhir list (menjadi tail).

Berikut adalah contoh kode program dalam bahasa C# yang menunjukkan bagaimana menambahkan item di depan, di tengah, dan di akhir Linked List. Kita akan menggunakan struktur `Node` yang sama seperti sebelumnya dan menambahkan metode baru untuk menambahkan item di tengah list.

```csharp
using System;

public class LinkedList
{
    private Node head;

    public class Node
    {
        public int data;
        public Node next;

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    public LinkedList()
    {
        head = null;
    }

    // Menambahkan item di depan (menjadi head baru)
    public void AddFirst(int data)
    {
        Node newNode = new Node(data);
        newNode.next = head;
        head = newNode;
    }

    // Menambahkan item di tengah list setelah node dengan data tertentu
    public void AddAfter(int after, int data)
    {
        Node current = head;
        while (current != null && current.data != after)
        {
            current = current.next;
        }

        if (current != null)
        {
            Node newNode = new Node(data);
            newNode.next = current.next;
            current.next = newNode;
        }
        else
        {
            Console.WriteLine($"Node dengan data {after} tidak ditemukan.");
        }
    }

    // Menambahkan item di akhir list
    public void AddLast(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            return;
        }

        Node last = GetLastNode();
        last.next = newNode;
    }

    private Node GetLastNode()
    {
        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        return temp;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();

        linkedList.AddLast(3); // Menambahkan 3 di akhir list
        linkedList.AddFirst(1); // Menambahkan 1 di awal list
        linkedList.AddAfter(1, 2); // Menambahkan 2 setelah 1, di tengah list
    }
}
```

Dalam contoh ini, kita menambahkan tiga metode utama untuk menangani penambahan item:

- `AddFirst(int data)`: Menambahkan node baru sebagai elemen pertama dari list (di depan).
- `AddAfter(int after, int data)`: Menambahkan node baru setelah node yang memiliki data sesuai dengan parameter `after`. Jika node dengan data tersebut tidak ditemukan, metode akan menampilkan pesan bahwa node tidak ditemukan.
- `AddLast(int data)`: Menambahkan node baru sebagai elemen terakhir dari list (di akhir).

### Enumerasi Linked List

Enumerasi atau iterasi dari head ke tail untuk melakukan operasi seperti pencetakan semua elemen.

Untuk melakukan enumerasi atas item-item yang ada dalam Linked List di C#, kita akan membuat metode `PrintAllNodes`. Metode ini melakukan iterasi melalui setiap node dalam list dan mencetak nilai data mereka. Kita akan menggunakan pendekatan iteratif sederhana. Di bawah ini adalah contoh kode program yang telah dimodifikasi untuk menunjukkan cara melakukan enumerasi atas item-item dalam Linked List:

```csharp
using System;

public class LinkedList
{
    // Kode sebelumnya...

    // Metode untuk melakukan enumerasi atas item-item dalam Linked List
    public void PrintAllNodes()
    {
        Console.WriteLine("Isi Linked List:");
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddLast(10);
        linkedList.AddFirst(5);
        linkedList.AddLast(15);

        linkedList.PrintAllNodes();
        // Output akan menampilkan isi Linked List: 5, 10, 15
    }
}
```

Dalam kode ini, `PrintAllNodes` metode melakukan enumerasi atas seluruh node dalam Linked List dengan cara iteratif. Metode ini memulai dari `head` dan melanjutkan sampai tidak ada node selanjutnya (`next` bernilai `null`), mencetak nilai data dari setiap node.

Pendekatan ini sederhana dan langsung untuk menunjukkan cara melakukan enumerasi atas item-item dalam Linked List di C#. Dengan menggunakan teknik ini, kita dapat dengan mudah melihat dan memverifikasi isi dari Linked List kita.

### Mencari Item

Melakukan pencarian untuk menemukan apakah item tertentu ada dalam list, biasanya dengan melewati setiap node dari head hingga tail.

Untuk menambahkan fungsionalitas pencarian dalam Linked List pada contoh kode sebelumnya, kita dapat mendefinisikan metode `Find` yang mencari item dalam list dan mengembalikan sebuah boolean untuk menunjukkan apakah item tersebut ditemukan. Berikut adalah kode lengkap dengan metode pencarian ditambahkan:

```csharp
using System;

public class LinkedList
{
    // kode sebelumnya...

    // Menemukan item dalam list
    public bool Find(int data)
    {
        Node current = head;
        while (current != null)
        {
            if (current.data == data)
            {
                return true; // Data ditemukan
            }
            current = current.next;
        }
        return false; // Data tidak ditemukan
    }

    // kode setelahnya...
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddLast(3);
        linkedList.AddFirst(1);
        linkedList.AddAfter(1, 2);

        Console.WriteLine("Isi Linked List:");
        linkedList.PrintAllNodes();

        int searchData = 2;
        bool found = linkedList.Find(searchData);
        Console.WriteLine(found ? $"Data {searchData} ditemukan dalam list." : $"Data {searchData} tidak ditemukan dalam list.");
    }
}
```

Dalam kode di atas, metode `Find(int data)` menelusuri Linked List mulai dari `head` hingga menemukan node yang memiliki data yang sesuai dengan nilai yang dicari. Jika item ditemukan, metode mengembalikan `true`; jika tidak, metode mengembalikan `false`.

Contoh penggunaan metode `Find` diperlihatkan di `Main`, di mana setelah menambahkan beberapa item ke dalam list, kita mencari item dengan nilai tertentu dan menampilkan hasilnya.


### Menghapus Item

Untuk menghapus, kita perlu menemukan node yang akan dihapus, kemudian mengubah referensi dari node sebelumnya untuk melompati node yang dihapus dan langsung merujuk ke node berikutnya.

Berikut adalah contoh kode program dalam bahasa C# yang menambahkan fungsionalitas untuk menghapus item dari Linked List. Fungsi `Delete` yang akan kita tambahkan bertugas untuk mencari dan menghapus node dengan data tertentu dari list. Jika node dengan data tersebut ditemukan, maka node tersebut akan dihapus dari list.

```csharp
using System;

public class LinkedList
{
    // Kode sebelumnya...

    // Menghapus item dari list
    public void Delete(int data)
    {
        Node current = head;
        Node previous = null;

        // Jika head adalah node yang akan dihapus
        if (current != null && current.data == data)
        {
            head = current.next; // Pindahkan head
            return;
        }

        // Cari node yang akan dihapus, sambil menjaga referensi node sebelumnya
        while (current != null && current.data != data)
        {
            previous = current;
            current = current.next;
        }

        // Jika node tidak ditemukan
        if (current == null)
        {
            Console.WriteLine($"Data {data} tidak ditemukan dalam list.");
            return;
        }

        // Melepas node dari list
        previous.next = current.next;
    }

    // Kode setelahnya...
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddLast(3);
        linkedList.AddFirst(1);
        linkedList.AddLast(4);
        linkedList.AddAfter(1, 2);

        Console.WriteLine("Isi Linked List sebelum penghapusan:");
        linkedList.PrintAllNodes();

        // Menghapus item
        linkedList.Delete(3);
        Console.WriteLine("\nIsi Linked List setelah penghapusan:");
        linkedList.PrintAllNodes();
    }
}
```

Dalam kode di atas, metode `Delete(int data)` mencari node dengan data yang sesuai. Jika node ditemukan, maka node tersebut akan dihapus dari list. Fungsi ini menangani tiga kasus:
- Node yang dihapus adalah `head`.
- Node yang dihapus ada di tengah atau akhir list.
- Node yang dihapus tidak ditemukan di list.

Metode `PrintAllNodes` digunakan untuk menampilkan isi dari list sebelum dan setelah penghapusan untuk memverifikasi bahwa operasi penghapusan telah berhasil dilakukan.


### Sorted List

Linked List dapat dijaga dalam keadaan tersortir saat penambahan, dengan membandingkan elemen yang akan ditambahkan dengan elemen yang sudah ada dan menempatkannya di posisi yang benar.

Untuk membuat sorted Linked List di C#, kita perlu memodifikasi metode penambahan item sehingga setiap kali item ditambahkan, list tetap terurut. Hal ini dapat dilakukan dengan mencari posisi yang tepat untuk menambahkan node baru berdasarkan nilai data, memastikan urutan dari nilai terkecil ke terbesar (atau sebaliknya, tergantung pada kebutuhan).

Berikut ini adalah contoh kode program dalam bahasa C# untuk membuat sorted Linked List yang menambahkan elemen dalam urutan naik:

```csharp
using System;

public class SortedLinkedList
{
    private Node head;

    public class Node
    {
        public int data;
        public Node next;

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    public SortedLinkedList()
    {
        head = null;
    }

    // Metode untuk menambahkan item dalam urutan terurut
    public void Add(int data)
    {
        Node newNode = new Node(data);

        // Jika list kosong atau data baru harus ditempatkan sebelum head saat ini
        if (head == null || head.data >= data)
        {
            newNode.next = head;
            head = newNode;
        }
        else
        {
            // Cari node sehingga node.next.data lebih besar dari data
            Node current = head;
            while (current.next != null && current.next.data < data)
            {
                current = current.next;
            }

            // Masukkan newNode setelah node yang ditemukan
            newNode.next = current.next;
            current.next = newNode;
        }
    }

    // Metode untuk mencetak semua node dalam list
    public void PrintAllNodes()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SortedLinkedList sortedList = new SortedLinkedList();

        // Menambahkan elemen dalam urutan acak, namun akan tersimpan dalam urutan terurut
        sortedList.Add(5);
        sortedList.Add(1);
        sortedList.Add(3);
        sortedList.Add(2);
        sortedList.Add(4);

        Console.WriteLine("Elemen dalam Sorted Linked List:");
        sortedList.PrintAllNodes();
        // Output akan menampilkan: 1, 2, 3, 4, 5
    }
}
```

Pada kode di atas, metode `Add` diimplementasikan untuk menambahkan elemen dalam urutan terurut. Jika list kosong atau nilai elemen baru lebih kecil dari `head`, elemen baru akan ditambahkan di depan. Jika tidak, kode melakukan iterasi melalui list untuk menemukan posisi yang tepat sehingga elemen baru disisipkan sebelum elemen yang lebih besar dan setelah elemen yang lebih kecil atau sama dengan nilai tersebut.

Kode ini menciptakan sorted Linked List yang menjaga elemen-elemennya dalam urutan naik tanpa memerlukan pengurutan ulang setelah setiap penambahan. Ini adalah pendekatan yang efisien untuk menjaga urutan elemen dalam Linked List ketika urutan penambahan elemen tidak dapat diprediksi.

## Contoh Studi Kasus

Sebagai studi kasus, bayangkan kita menggunakan Linked List untuk mengelola sebuah playlist lagu. Setiap node menyimpan informasi tentang lagu (misalnya, judul dan artis) dan referensi ke lagu berikutnya dalam playlist. Operasi seperti menambahkan lagu baru, menghapus lagu, atau menemukan lagu tertentu menjadi intuitif dengan struktur Linked List, memanfaatkan kelebihan seperti penambahan dan penghapusan yang efisien.

Untuk studi kasus ini, kita akan mengadaptasi struktur Linked List yang telah kita bahas sebelumnya untuk mengelola sebuah playlist lagu. Setiap node dalam list akan menyimpan informasi tentang sebuah lagu, termasuk judul dan artis, serta referensi ke lagu berikutnya dalam playlist. Kita akan menambahkan operasi untuk menambahkan lagu baru, menghapus lagu berdasarkan judul, dan mencari lagu tertentu dalam playlist.

```csharp
using System;

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
```

Dalam implementasi ini:
- Kelas `Playlist` mengelola linked list lagu, dengan setiap node (`SongNode`) menyimpan informasi tentang judul dan artis lagu.
- Metode `AddSong` menambahkan lagu baru ke akhir playlist.
- Metode `FindSong` mencari lagu dalam playlist berdasarkan judul dan mengembalikan `true` jika lagu tersebut ditemukan.
- Metode `DeleteSong` menghapus lagu dari playlist berdasarkan judul.
- Metode `PrintPlaylist` mencetak seluruh lagu dalam playlist, menampilkan judul dan artis dari setiap lagu.

Kode di atas menunjukkan bagaimana struktur data linked list dapat digunakan untuk mengelola playlist lagu, memanfaatkan keefektifan linked list dalam menambahkan, menghapus, dan mencari elemen.

## Analisis Asimptotik

Analisis asimptotik dengan menggunakan notasi Big O memberikan pemahaman tentang bagaimana kompleksitas waktu (dan kadang-kompleksitas ruang) dari operasi dalam struktur data, seperti Linked List, berskala relatif terhadap ukuran input. Berikut ini adalah analisis untuk operasi-operasi dasar pada Linked List:

### Menambahkan Item
- **AddFirst (menambah di awal)**: Kompleksitasnya adalah \(O(1)\). Operasi ini memerlukan waktu yang sama tidak peduli seberapa besar list, karena hanya membutuhkan penyesuaian pointer head.
- **AddLast (menambah di akhir)**: Kompleksitasnya adalah \(O(n)\) di mana \(n\) adalah jumlah elemen dalam list. Dalam kasus terburuk, kita harus melewati seluruh list untuk menemukan elemen terakhir. Namun, jika kita menyimpan referensi tambahan ke elemen terakhir list, kompleksitas dapat ditekan menjadi \(O(1)\).
- **AddAfter (menambah setelah elemen tertentu)**: Kompleksitas waktu rata-rata adalah \(O(n)\) karena dalam kasus terburuk, elemen yang dituju berada di akhir list, yang mengharuskan kita melakukan traversal dari head.

### Mencari Item
- **Find**: Kompleksitas waktu adalah \(O(n)\) karena dalam kasus terburuk kita harus melewati seluruh list untuk menemukan item yang diinginkan.

### Menghapus Item
- **Delete**: Seperti pencarian, menghapus item memiliki kompleksitas \(O(n)\) karena kita perlu terlebih dahulu menemukan node yang akan dihapus. Proses ini mungkin memerlukan traversal list dari awal hingga node yang diinginkan ditemukan.

### Enumerasi (Iterasi) atas List
- **PrintAllNodes atau iterasi**: Kompleksitas waktu adalah \(O(n)\) di mana \(n\) adalah jumlah elemen dalam list. Ini karena setiap elemen harus dikunjungi sekali.

### Menambahkan dalam Urutan Terurut
- **Add dalam SortedLinkedList**: Kompleksitasnya adalah \(O(n)\) karena dalam kasus terburuk, kita perlu menemukan posisi yang tepat untuk memasukkan elemen baru, yang bisa jadi di akhir list.

## Kesimpulan

Linked List menawarkan fleksibilitas yang signifikan untuk operasi penambahan dan penghapusan dibandingkan dengan array yang memiliki ukuran tetap atau memerlukan pergeseran elemen. Baik Single maupun Double Linked List memiliki peranan penting dalam struktur data, dengan masing-masing memiliki kelebihannya. Pemahaman tentang operasi dasar dan penggunaan kasus yang tepat dapat memaksimalkan keefektifan penggunaan Linked List dalam pemrograman.

Dalam konteks Linked List, banyak operasi memiliki kompleksitas waktu \(O(n)\) karena kebutuhan untuk traversal atau iterasi melalui list untuk menemukan posisi tertentu (misalnya, elemen terakhir, elemen sebelum elemen yang akan dihapus, atau posisi penyisipan tertentu). Operasi yang tidak memerlukan traversal, seperti menambahkan item di awal list, memiliki kompleksitas waktu konstan \(O(1)\). Memahami kompleksitas ini penting untuk mengoptimalkan performa aplikasi, terutama saat bekerja dengan dataset besar.
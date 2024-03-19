# Catatan Kuliah: Queue

## Pengenalan Queue
Queue adalah struktur data tipe FIFO (First In, First Out), di mana elemen pertama yang ditambahkan ke dalam queue akan menjadi elemen pertama yang diambil kembali. Ini sering digunakan dalam pemrograman untuk mengelola data dalam skenario seperti pelayanan pelanggan, manajemen proses pada sistem operasi, dan dalam algoritma breadth-first search pada graf.

## Operasi Utama pada Queue
- **Enqueue**: Menambahkan elemen ke bagian belakang queue.
- **Dequeue**: Mengambil dan menghapus elemen dari depan queue.
- **Peek/Front**: Mengakses elemen di depan queue tanpa menghapusnya.
- **IsEmpty**: Memeriksa apakah queue kosong.

Untuk mengimplementasikan queue tanpa menggunakan kelas `Queue<T>` bawaan .NET Framework, kita bisa menggunakan array atau linked list. Berikut adalah dua pendekatan umum untuk implementasi queue:

## Menggunakan Array

Implementasi queue menggunakan array memerlukan penanganan indeks untuk head (depan) dan tail (belakang) queue. Ketika elemen di-enqueue, ia ditambahkan ke posisi tail dan ketika elemen di-dequeue, elemen dari posisi head diambil. Ini memerlukan penggeseran elemen atau penggunaan teknik circular array untuk mengoptimalkan penggunaan memori.

### Struktur Dasar
```csharp
public class ArrayQueue<T>
{
    private T[] array;
    private int size;
    private int head; // Indeks untuk elemen depan
    private int tail; // Indeks untuk elemen belakang

    public ArrayQueue(int capacity)
    {
        array = new T[capacity];
        size = 0;
        head = 0;
        tail = 0;
    }

    public void Enqueue(T item)
    {
        if (size == array.Length)
        {
            throw new InvalidOperationException("Queue is full");
        }
        
        array[tail] = item;
        tail = (tail + 1) % array.Length;
        size++;
    }

    public T Dequeue()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = array[head];
        head = (head + 1) % array.Length;
        size--;
        return item;
    }

    public T Peek()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return array[head];
    }

    public bool IsEmpty()
    {
        return size == 0;
    }
}
```

## Menggunakan Linked List

Implementasi queue menggunakan linked list lebih fleksibel dalam hal pengelolaan memori karena tidak memerlukan pengalokasian ruang sejak awal seperti pada array. Setiap elemen baru dimasukkan sebagai node baru di akhir linked list, dan elemen yang di-dequeue diambil dari depan linked list.

### Struktur Dasar
```csharp
public class LinkedListQueue<T>
{
    private class Node
    {
        public T Data;
        public Node Next;

        public Node(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }

    private Node head;
    private Node tail;

    public LinkedListQueue()
    {
        head = null;
        tail = null;
    }

    public void Enqueue(T item)
    {
        Node newNode = new Node(item);
        if (tail != null)
        {
            tail.Next = newNode;
        }
        tail = newNode;
        if (head == null)
        {
            head = newNode;
        }
    }

    public T Dequeue()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = head.Data;
        head = head.Next;
        if (head == null)
        {
            tail = null;
        }
        return item;
    }

    public T Peek()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return head.Data;
    }

    public bool IsEmpty()
    {
        return head == null;
    }
}
```

Kedua pendekatan ini, baik menggunakan array maupun linked list, memiliki kelebihan dan kekurangannya masing-masing. Menggunakan array bisa lebih cepat dalam hal akses dan modifikasi elemen, tetapi memerlukan ukuran maksimal yang ditentukan sejak awal. Sedangkan linked list lebih fleksibel dalam penggunaan memori dan tidak memerlukan ukuran tetap, tetapi mungkin sedikit lebih lambat karena overhead dari alokasi objek node tambahan.

## Penggunaan Queue Bawaan Framework .NET
.NET Framework menyediakan implementasi queue melalui kelas `Queue<T>`, yang mendukung operasi-operasi queue standar dan bisa digunakan dengan tipe data apa saja.

Contoh penggunaan:
```csharp
Queue<string> queue = new Queue<string>();
queue.Enqueue("elemen pertama");
queue.Enqueue("elemen kedua");
string first = queue.Peek(); // first = "elemen pertama"
string removed = queue.Dequeue(); // removed = "elemen pertama"
```

## Analisis Asimptotik
Memahami kompleksitas waktu dan ruang dari operasi queue penting untuk memastikan efisiensi aplikasi.

### Kompleksitas Waktu
- **Enqueue**: \(O(1)\) - Menambahkan elemen ke belakang queue biasanya dilakukan dalam waktu konstan.
- **Dequeue**: \(O(1)\) - Menghapus elemen dari depan queue juga dilakukan dalam waktu konstan.
- **Peek/Front**: \(O(1)\) - Mengakses elemen depan tanpa menghapusnya merupakan operasi waktu konstan.
- **IsEmpty**: \(O(1)\) - Memeriksa apakah queue kosong merupakan operasi waktu konstan.

### Kompleksitas Ruang
- **Queue**: \(O(n)\) - Membutuhkan ruang yang sebanding dengan jumlah elemen yang disimpan di dalamnya. Untuk setiap elemen baru, diperlukan ruang tambahan.

Penggunaan queue yang efisien dalam skenario yang tepat dapat meningkatkan performa dan organisasi data dalam aplikasi. Memilih struktur data yang tepat berdasarkan analisis asimptotik adalah kunci untuk mengoptimalkan solusi pada masalah pemrograman.
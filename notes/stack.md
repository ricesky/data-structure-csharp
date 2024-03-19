# Catatan Kuliah: Stack

## Pengenalan Stack

Stack adalah struktur data linear yang mengikuti prinsip Last In First Out (LIFO). Artinya, elemen terakhir yang ditambahkan ke dalam stack akan menjadi elemen pertama yang diambil saat penghapusan atau akses. Stack sering digunakan dalam berbagai algoritma dan proses pemrograman, seperti evaluasi ekspresi, algoritma backtracking, dan untuk mengelola eksekusi fungsi.

## Operasi Utama pada Stack

Stack mendukung beberapa operasi utama, antara lain:

- **Push**: Menambahkan elemen ke bagian atas stack.
- **Pop**: Menghapus dan mengembalikan elemen dari bagian atas stack.
- **Peek**: Mengembalikan elemen dari bagian atas stack tanpa menghapusnya.
- **IsEmpty**: Mengecek apakah stack kosong.

## Representasi Stack

Stack dapat diimplementasikan menggunakan array atau linked list, tergantung pada kebutuhan dan preferensi. Implementasi menggunakan linked list memberikan fleksibilitas dalam alokasi memori, sementara array memberikan akses yang cepat dan efisien.

## Implementasi Stack

Stack dapat diimplementasikan menggunakan array atau linked list. Masing-masing memiliki kelebihan dan kekurangan tergantung pada kasus penggunaannya.

### Implementasi dengan Array

Implementasi stack dengan array melibatkan penciptaan array dengan ukuran tertentu. Indeks top digunakan untuk melacak elemen paling atas.

```csharp
public class Stack
{
    private int[] elements;
    private int top;
    private int max;

    public Stack(int size)
    {
        elements = new int[size];
        top = -1;
        max = size;
    }

    public void Push(int item)
    {
        if (top == max - 1)
        {
            Console.WriteLine("Stack penuh");
        }
        else
        {
            elements[++top] = item;
        }
    }

    public int Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack kosong");
            return -1;
        }
        else
        {
            return elements[top--];
        }
    }

    public int Peek()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack kosong");
            return -1;
        }
        else
        {
            return elements[top];
        }
    }

    public bool IsEmpty()
    {
        return top == -1;
    }
}
```

### Implementasi dengan Linked List

Implementasi stack dengan linked list lebih fleksibel karena tidak terbatas oleh ukuran awal. Elemen baru ditambahkan ke kepala linked list, yang berfungsi sebagai bagian atas stack.

```csharp
public class StackNode
{
    public int data;
    public StackNode next;

    public StackNode(int data)
    {
        this.data = data;
        this.next = null;
    }
}

public class Stack
{
    private StackNode top;

    public Stack()
    {
        this.top = null;
    }

    public void Push(int item)
    {
        StackNode newNode = new StackNode(item);
        newNode.next = top;
        top = newNode;
    }

    public int Pop()
    {
        if (top == null)
        {
            Console.WriteLine("Stack kosong");
            return -1;
        }
        else
        {
            int item = top.data;
            top = top.next;
            return item;
        }
    }

    public int Peek()
    {
        if (top == null)
        {
            Console.WriteLine("Stack kosong");
            return -1;
        }
        else
        {
            return top.data;
        }
    }

    public bool IsEmpty()
    {
        return top == null;
    }
}
```

## Penggunaan Stack dalam .NET Framework

.NET Framework menyediakan implementasi stack melalui kelas `Stack<T>` yang tersedia dalam namespace `System.Collections.Generic`. Kelas ini memberikan implementasi stack yang tipe datanya aman (type-safe) dan dinamis.

### Contoh Penggunaan `Stack<T>`:

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<string> stack = new Stack<string>();

        // Push beberapa string ke dalam stack
        stack.Push("Apple");
        stack.Push("Banana");
        stack.Push("Cherry");

        // Melihat elemen teratas stack tanpa menghapus
        Console.WriteLine($"Top item: {stack.Peek()}");

        // Menghapus dan mencetak setiap item
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}
```


Dalam contoh di atas, kita menggunakan `Stack<T>` untuk menumpuk beberapa string dan kemudian mengeluarkannya lagi. Setiap elemen diakses dan dihapus dari stack dalam urutan terbalik dari cara mereka ditambahkan, menunjukkan sifat LIFO dari stack.

## Analisis Asimptotik
Analisis asimptotik penting untuk memahami efisiensi waktu dan ruang dari operasi stack dalam konteks yang lebih besar, terutama saat digunakan dalam algoritma atau aplikasi yang kompleks.

### Kompleksitas Waktu
- **Push**: \(O(1)\) - Menambahkan elemen ke atas stack dilakukan dalam waktu konstan karena tidak memerlukan traversal atau perubahan pada elemen lain.
- **Pop**: \(O(1)\) - Menghapus elemen dari atas stack juga dilakukan dalam waktu konstan dengan alasan yang sama.
- **Peek**: \(O(1)\) - Melihat elemen atas stack dilakukan dalam waktu konstan karena langsung mengakses elemen terakhir tanpa perlu melalui elemen lain.
- **IsEmpty**: \(O(1)\) - Memeriksa apakah stack kosong juga merupakan operasi waktu konstan karena biasanya hanya memerlukan pengecekan satu variabel (misalnya, ukuran stack atau pointer ke elemen atas).

### Kompleksitas Ruang
- **Stack**: \(O(n)\) - Membutuhkan ruang seproporsional dengan jumlah elemen yang disimpan. Untuk setiap elemen baru yang ditambahkan, memerlukan tambahan ruang untuk menyimpannya.

## Kasus Penggunaan Stack

Stack banyak digunakan dalam berbagai aplikasi pemrograman, antara lain:

- **Balik Kata**: Menggunakan stack untuk membalik urutan karakter dalam sebuah string.
- **Manajemen Subrutin**: Untuk mengelola pemanggilan dan pengembalian fungsi atau prosedur.
- **Evaluasi Ekspresi**: Digunakan dalam algoritma untuk mengevaluasi ekspresi matematika, seperti ekspresi infix, postfix, dan prefix.
- **Undo Mechanism**: Dalam aplikasi seperti editor teks untuk mengelola aksi yang dapat dibatalkan oleh pengguna.
- **Navigasi Halaman**: Dalam aplikasi web atau mobile untuk mengelola riwayat navigasi halaman.

## Kesimpulan

Stack adalah struktur data yang sangat berguna dengan berbagai aplikasi praktis dalam pemrograman komputer. Memahami cara kerja stack dan kapan harus menggunakannya dapat membantu merancang solusi yang lebih efisien untuk berbagai masalah pemrograman. Implementasi `Stack<T>` di .NET Framework menyediakan cara yang efisien dan mudah untuk menggunakan stack dalam aplikasi .NET, dengan dukungan untuk tipe data generik yang memberikan keamanan tipe dan fleksibilitas.
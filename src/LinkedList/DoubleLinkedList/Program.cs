namespace DoubleLinkedList;

class Program
{
    static void Main(string[] args)
    {
        // Part 1
        DoublyLinkedList dll = new DoublyLinkedList();
        dll.AddLast(1); // Menambahkan 1 di akhir
        dll.AddLast(3); // Menambahkan 3 di akhir
        dll.AddFirst(0); // Menambahkan 0 di awal

        // Asumsikan kita ingin menambahkan 2 sebelum 3
        dll.AddBefore(dll.tail, 2); // Menambahkan 2 sebelum 3

        Console.WriteLine("Double Linked List setelah menambahkan node:");
        dll.PrintList();
        // Output seharusnya: 0 1 2

        // Part 2
        DoublyLinkedList dll2 = new DoublyLinkedList();
        dll2.AddFirst(10); // Menambahkan 10 di awal
        dll2.AddFirst(20); // Menambahkan 20 di awal, menjadi head baru
        dll2.AddLast(5);  // Menambahkan 5 di akhir, menjadi tail
        dll2.AddAfter(dll2.head.next, 15); // Menambahkan 15 setelah node kedua (20)

        dll2.PrintList(); // Menampilkan list dari head ke tail
        dll2.PrintListReverse(); // Menampilkan list dari tail ke head

        // Part 3
        DoublyLinkedList dll3 = new DoublyLinkedList();
        dll3.AddFirst(20);
        dll3.AddLast(40);
        dll3.AddFirst(10);
        dll3.AddLast(50);

        int searchData = 40;
        bool foundFromHead = dll3.FindFromHead(searchData);
        bool foundFromTail = dll3.FindFromTail(searchData);

        Console.WriteLine($"Mencari {searchData} dari head: " + (foundFromHead ? "Ditemukan." : "Tidak ditemukan."));
        Console.WriteLine($"Mencari {searchData} dari tail: " + (foundFromTail ? "Ditemukan." : "Tidak ditemukan."));

        // Part 4

        DoublyLinkedList dll4 = new DoublyLinkedList();
        dll4.AddFirst(10);
        dll4.AddFirst(20);
        dll4.AddFirst(30);

        Console.WriteLine("Sebelum penghapusan:");
        dll4.PrintList();

        // Misalkan kita ingin menghapus node dengan data 20
        DoublyLinkedList.Node nodeToDelete = dll4.head.next; // Mendapatkan referensi ke node yang akan dihapus
        dll4.DeleteNode(nodeToDelete);

        Console.WriteLine("Setelah penghapusan:");
        dll4.PrintList();
    }
}
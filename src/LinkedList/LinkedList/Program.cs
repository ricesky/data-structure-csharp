namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {

        // Part 1
        LinkedList linkedList = new LinkedList();

        linkedList.AddLast(3); // Menambahkan 3 di akhir list
        linkedList.AddFirst(1); // Menambahkan 1 di awal list
        linkedList.AddAfter(1, 2); // Menambahkan 2 setelah 1, di tengah list

        //Part 2
        LinkedList linkedList2 = new LinkedList();
        linkedList2.AddLast(10);
        linkedList2.AddFirst(5);
        linkedList2.AddLast(15);

        linkedList2.PrintAllNodes();
        // Output akan menampilkan isi Linked List: 5, 10, 15

        //Part 3
        LinkedList linkedList3 = new LinkedList();
        linkedList3.AddLast(3);
        linkedList3.AddFirst(1);
        linkedList3.AddAfter(1, 2);

        Console.WriteLine("Isi Linked List:");
        linkedList3.PrintAllNodes();

        int searchData = 2;
        bool found = linkedList3.Find(searchData);
        Console.WriteLine(found ? $"Data {searchData} ditemukan dalam list." : $"Data {searchData} tidak ditemukan dalam list.");

        //Part 4
        LinkedList linkedList4 = new LinkedList();
        linkedList4.AddLast(3);
        linkedList4.AddFirst(1);
        linkedList4.AddLast(4);
        linkedList4.AddAfter(1, 2);

        Console.WriteLine("Isi Linked List sebelum penghapusan:");
        linkedList4.PrintAllNodes();

        // Menghapus item
        linkedList4.Delete(3);
        Console.WriteLine("\nIsi Linked List setelah penghapusan:");
        linkedList4.PrintAllNodes();
    }
}
namespace SortedLinkedList;

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
namespace SortedLinkedList;

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

public class SortedLinkedList
{
    private Node head;

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

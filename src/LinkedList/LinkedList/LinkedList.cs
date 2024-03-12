namespace LinkedList;

public class Node
{
    public int data;
    public Node next;

    public Node(int data)
    {
        this.data = data;
        this.next = null;
    }
}
public class LinkedList
{
    private Node head;

    public LinkedList()
    {
        this.head = null;
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

}

using System;

namespace DoubleLinkedList;

public class DoublyLinkedList
{
    public Node? head;
    public Node? tail;

    public class Node
    {
        public int data;
        public Node? prev;
        public Node? next;

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

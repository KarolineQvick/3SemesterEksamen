using System;

class Node
{
    public string data;
    public Node next;

    public Node(string value)
    {
        data = value;
        next = null;
    }
}

class SortedLinkedList
{
    private Node head;

    public SortedLinkedList()
    {
        head = null;
    }

    // Tilføjer en strengværdi til den sorteret liste
    // Tidskompleksitet: O(n) i værste fald, hvor n er antallet af elementer i listen.
    public void Add(string value)
    {
        Node newNode = new Node(value);

        if (head == null || string.Compare(value, head.data) < 0)
        {
            // Hvis listen er tom eller den nye værdi er mindre end hovedets data,
            // bliver den nye node hovedet og peger på den tidligere første node
            newNode.next = head;
            head = newNode;
        }
        else
        {
            Node current = head;

            while (current.next != null && string.Compare(value, current.next.data) >= 0)
            {
                // Finder det sted i listen, hvor den nye værdi skal indsættes
                current = current.next;
            }

            // Indsætter den nye node mellem den aktuelle node og den næste node
            newNode.next = current.next;
            current.next = newNode;
        }
    }

    // Udskriver alle elementer i listen
    // Tidskompleksitet: O(n), hvor n er antallet af elementer i listen. //linær tid
    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        SortedLinkedList sortedList = new SortedLinkedList();

        // Tilføj elementer til den sorteret liste
        sortedList.Add("orange");   // Listen: orange
        sortedList.Add("apple");    // Listen: apple orange
        sortedList.Add("banana");   // Listen: apple banana orange
        sortedList.Add("kiwi");     // Listen: apple banana kiwi orange
        sortedList.Add("grape");    // Listen: apple banana grape kiwi orange

        // Udskriv den sorteret liste
        sortedList.PrintList();
    }
}

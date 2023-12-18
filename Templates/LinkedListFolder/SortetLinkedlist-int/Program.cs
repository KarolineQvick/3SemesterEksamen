using System;

class Node
{
    public int data;
    public Node next;

    public Node(int value)
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

    public void Add(int value)
    {
        Node newNode = new Node(value);

        if (head == null || value < head.data)
        {
            // Hvis listen er tom eller det nye element er mindre end hovedets data,
            // bliver det nye element hovedet og peger på den tidligere første node
            newNode.next = head;
            head = newNode;
        }
        else
        {
            Node current = head;

            while (current.next != null && value >= current.next.data)
            {
                // Finder det sted i listen, hvor det nye element skal indsættes
                current = current.next;
            }

            // Indsætter det nye element mellem den aktuelle node og den næste node
            newNode.next = current.next;
            current.next = newNode;
        }
    }

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
        sortedList.Add(5);
        sortedList.Add(2);
        sortedList.Add(8);
        sortedList.Add(1);
        sortedList.Add(4);

        // Udskriv den sorteret liste
        sortedList.PrintList();
    }
}


/*Hvis listen er tom eller det nye element er mindre end hovedets data, bliver det nye element hovedet og peger på den tidligere første node. Dette sikrer, at det mindste element altid er i starten af listen.
Hvis listen ikke er tom og det nye element er større eller lig med den aktuelle nodes data, bevæger vi os fremad i listen, indtil vi når det rette sted for det nye element.
Når vi har fundet det rette sted, indsættes det nye element mellem den aktuelle node og den næste node ved at opdatere referencerne.*/
using System;

class Node
{
    public int data;  // Datafeltet for noden
    public Node next; // Referencen til den næste node i listen

    public Node(int value)
    {
        data = value;
        next = null;
    }
}

class LinkedList
{
    private Node head; // Hovedet (første node) i listen

    public LinkedList()
    {
        head = null; // Initialiserer listen som tom ved at sætte hovedet til null
    }

    // Tilføjer et nyt element forrest i listen
    public void AddFront(int value)
    {
        Node newNode = new Node(value); // Opretter en ny node med den givne værdi
        newNode.next = head; // Den nye node peger på den nuværende første node (hvis der er nogen)
        head = newNode; // Opdaterer hovedet til at være den nye node
    }

    // Tilføjer et nyt element bagerst i listen
    public void AddBack(int value)
    {
        Node newNode = new Node(value); // Opretter en ny node med den givne værdi

        if (head == null)
        {
            // Hvis listen er tom, bliver den nye node hovedet
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next; // Finder den sidste node i listen
            }
            current.next = newNode; // Den sidste node peger nu på den nye node
        }
    }

    // Fjerner den første forekomst af et element i listen
    public void Remove(int value)
    {
        if (head == null)
            return; // Hvis listen er tom, er der ikke noget at fjerne

        if (head.data == value)
        {
            // Hvis hovedet indeholder den ønskede værdi, bliver hovedet flyttet til den næste node
            head = head.next;
            return;
        }

        Node current = head;
        while (current.next != null)
        {
            if (current.next.data == value)
            {
                // Hvis den næste node indeholder den ønskede værdi, fjernes den ved at opdatere referencerne
                current.next = current.next.next;
                return;
            }
            current = current.next;
        }
    }

    // Tjekker om et element er til stede i listen
    public bool Contains(int value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.data == value)
                return true;
            current = current.next;
        }
        return false;
    }

    // Udskriver alle elementer i listen
    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.data + " "); // Udskriver datafeltet for den aktuelle node
            current = current.next; // Flytter til den næste node
        }
        Console.WriteLine();
    }

    // Tilføjer et element på et bestemt indeks i listen
    public void AddAtIndex(int index, int value)
    {
        if (index == 0)
        {
            // Hvis indekset er 0, betyder det at elementet skal tilføjes forrest i listen
            AddFront(value);
        }
        else
        {
            Node newNode = new Node(value); // Opretter en ny node med den givne værdi

            Node current = head;
            int currentIndex = 0;

            // Finder den node, der skal være umiddelbart før den nye node
            while (current != null && currentIndex < index - 1)
            {
                current = current.next;
                currentIndex++;
            }

            if (current != null)
            {
                // Indsætter den nye node ved at opdatere referencerne
                newNode.next = current.next;
                current.next = newNode;
            }
            else
            {
                // Hvis indekset er uden for grænserne for listen, afbrydes metoden uden at foretage nogen ændringer
                Console.WriteLine("Ugyldigt indeks");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList myList = new LinkedList();

        // Tilføj elementer forrest i listen
        myList.AddFront(1);
        myList.AddFront(2);
        myList.AddFront(3);

        // Tilføj elementer bagerst i listen
        myList.AddBack(4);
        myList.AddBack(5);

        // Fjern et element fra listen
        myList.Remove(2);

        // Udskriv listen
        myList.PrintList();

        // Tjek om listen indeholder bestemte værdier
        Console.WriteLine("Indeholder listen 3? " + myList.Contains(3));
        Console.WriteLine("Indeholder listen 6? " + myList.Contains(6));

        // Tilføj et element på et bestemt indeks
        myList.AddAtIndex(2, 10);

        // Udskriv listen igen
        myList.PrintList();
    }
}

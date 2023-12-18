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

    public void InsertFromArray(int[] array)
    {
        // Sorterer arrayet i stigende rækkefølge
        Array.Sort(array);

        // Indsætter de sorteret elementer i linked listen
        for (int i = 0; i < array.Length; i++)
        {
            Add(array[i]);
        }
    }

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
}

class Program
{
    static void Main()
    {
        int[] array = { 5, 2, 8, 1, 4 };

        SortedLinkedList sortedList = new SortedLinkedList();
        sortedList.InsertFromArray(array);

        sortedList.PrintList(); // Udskriver den sorteret linked liste

        // Resultat: 1 2 4 5 8
    }
}

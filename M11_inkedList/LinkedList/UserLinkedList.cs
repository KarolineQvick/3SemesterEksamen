namespace LinkedList
{
    // En indre klasse, der repræsenterer en enkelt knude i listen
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }

        public User Data; // Data gemt i knuden
        public Node Next; // Reference til den næste knude i listen
    }

    // En klasse, der repræsenterer en brugerlinket liste
    class UserLinkedList
    {
        private Node first = null!; // Referencen til den første knude i listen (initialiseret som null)

        // Tilføjer en bruger i starten af listen
        public void AddFirst(User user)
        {
            Node node = new Node(user, first);
            first = node; // Opdaterer referencen til den første knude
        }

        // Fjerner og returnerer den første bruger i listen
        public User RemoveFirst()
        {
            Node temp = first;
            first = first.Next; // Opdaterer referencen til den første knude
            return temp.Data;
        }

        // Fjerner en bestemt bruger fra listen
        public void RemoveUser(User user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (!found && node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    found = true;
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = node.Next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        // Returnerer den første bruger i listen
        public User GetFirst()
        {
            return first.Data;
        }

        // Returnerer den sidste bruger i listen
        public User GetLast()
        {
            if (first == null)
            {
                return null!;
            }

            Node temp = first;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            return temp.Data;
        }

        // Tæller antallet af brugere i listen
        public int CountUsers()
        {
            int count = 0;
            Node current = first;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        // Kontrollerer om listen indeholder en bestemt bruger
        public bool Contains(User user)
        {
            Node current = first;

            while (current != null)
            {
                if (current.Data == user)
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        // Returnerer en strengrepræsentation af listen
        public override String ToString()
        {
            Node node = first;
            String result = "";

            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }

            return result.Trim();
        }
    }
}

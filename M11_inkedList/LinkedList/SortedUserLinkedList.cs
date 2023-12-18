namespace SortedLinkedList
{
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class SortedUserLinkedList
    {
        private Node first = null!;


          public void Add(User user)
        {
            if (first == null)
            {
                Node temp = new Node(user, null!);
                first = temp;
                return;
            }
            Node current = first;
            Node prev = null!;
     

                while (current != null && string.Compare(current.Data.Name.ToLower(), user.Name.ToLower()) < 0)
                {
           
                    prev = current;
                    current = current.Next;
                if (current == null)
                {
                    break;
                }
                }
            

            Node node = new Node(user, current);
            prev.Next = node;
            
        }
    }
}

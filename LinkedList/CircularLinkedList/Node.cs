namespace LinkedList.CircularLinkedList;

public class Node
{
    public Node(char data)
    {
        Data = data;
		Next = null;
    }

    public char Data { get; set; }
    public Node? Next { get; set; }
}

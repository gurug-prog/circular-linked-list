using Xunit;

namespace LinkedList.CircularLinkedList.Tests;

public class CircularLinkedListTests
{
    private readonly ICircularLinkedList _list;

    public CircularLinkedListTests()
    {
        _list = new CircularLinkedList();
    }

    [Fact]
    public void Test1()
    {
        _list.Append('a');

        // Assert
    }
}

using Xunit;

namespace LinkedList.CircularLinkedList.Tests;

public class CircularLinkedListTests
{
    private readonly ICircularLinkedList _list;

    public CircularLinkedListTests()
    {
        _list = new CircularLinkedList();
    }

    private void FillTestValuesIntoList(char[] testValues)
    {
        foreach (var el in testValues)
        {
            _list.Append(el);
        }
    }

    [Fact]
    public void TestAppend_ResultElementWasAppended()
    {
        var element = 'a';
        var lenExpected = 1;

        _list.Append(element);

        Assert.Equal(lenExpected, _list.Length());
    }

    [Theory]
    [InlineData(0, new char[]{ 'a', 'b', 'c', 'd' })]
    [InlineData(2, new char[]{ 'b', 'o', 'o', 'm', '!' })]
    public void TestDelete_ResultElementWasDeleted(int index, char[] testValues)
    {
        FillTestValuesIntoList(testValues);
        var lenExpected = testValues.Length - 1;

        _list.Delete(index);

        Assert.Equal(lenExpected, _list.Length());
    }

    [Theory]
    [InlineData(new char[]{ 'c', 'l', 'e', 'a', 'r' })]
    public void TestClear_ResultListWasCleared(char[] testValues)
    {
        FillTestValuesIntoList(testValues);
        var lenExpected = 0;

        _list.Clear();

        Assert.Equal(lenExpected, _list.Length());
    }

    [Theory]
    [InlineData('f', 3, new char[]{'b', 'u', 'f', 'f'})]
    [InlineData('y', 1, new char[]{'x', 'y', 'z'})]
    [InlineData('h', 4, new char[]{'H', 'i', ',', 't', 'h', 'e', 'r', 'e'})]
    [InlineData('z', 0, new char[]{'z'})]
    public void TestGet_ResultMathesElement
        (char expectedEl, int index, char[] testValues)
    {
        FillTestValuesIntoList(testValues);

        var actualEl = _list.Get(index);

        Assert.Equal(expectedEl, actualEl);
    }
}

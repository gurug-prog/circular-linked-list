using Xunit;

namespace LinkedList.CircularLinkedList.Tests;

public class CircularLinkedListTests
{
    private readonly ICircularLinkedList _list;

    public CircularLinkedListTests()
    {
        _list = new CircularLinkedList();
    }

    private void FillTestValuesIntoList(ICircularLinkedList list, char[] testValues)
    {
        foreach (var el in testValues)
        {
            list.Append(el);
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
        FillTestValuesIntoList(_list, testValues);
        var lenExpected = testValues.Length - 1;

        _list.Delete(index);

        Assert.Equal(lenExpected, _list.Length());
    }

    [Fact]
    public void TestDelete_ResultOperationExceptionThrowed()
    {
        Assert.Throws<System.InvalidOperationException>(
            () => _list.Delete(100)
        );
    }

    [Theory]
    [InlineData(new char[]{ 'c', 'l', 'e', 'a', 'r' })]
    public void TestClear_ResultListWasCleared(char[] testValues)
    {
        FillTestValuesIntoList(_list, testValues);
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
        FillTestValuesIntoList(_list, testValues);

        var actualEl = _list.Get(index);

        Assert.Equal(expectedEl, actualEl);
    }

    [Theory]
    [InlineData('f', 2, new char[]{'b', 'u', 'f', 'f'})]
    [InlineData('x', 2, new char[]{'x', 'y', 'z'})]
    [InlineData('e', 6, new char[]{'H', 'i', ',', 't', 'h', 'e', 'r', 'e'})]
    [InlineData('z', 0, new char[]{'z'})]
    public void TestDeleteAll_ResultAllMatchingElementsDeleted
        (char element, int lenExpected, char[] testValues)
    {
        FillTestValuesIntoList(_list, testValues);

        _list.DeleteAll(element);

        Assert.Equal(lenExpected, _list.Length());
    }

    [Theory]
    [InlineData('l', new char[]{'x', 'y', 'z'})]
    [InlineData('d', new char[]{'H', 'i', ',', 't', 'h', 'e', 'r', 'e'})]
    [InlineData('a', new char[]{'z'})]
    public void TestDeleteAll_ResultNothingChanged
    (char element, char[] testValues)
    {
        FillTestValuesIntoList(_list, testValues);

        _list.DeleteAll(element);

        Assert.Equal(testValues.Length, _list.Length());
    }

    [Fact]
    public void TestDeleteAll_ResultOperationExceptionThrowed()
    {
        var element = 'a';
        Assert.Throws<System.InvalidOperationException>(
            () => _list.DeleteAll(element)
        );
    }

    [Theory]
    [InlineData(new char[]{'z', 'x', 'c'}, new char[]{'S', 'F'})]
    [InlineData(new char[]{'a', 'b'}, new char[0])]
    public void TestExtend_ResultListExtended
        (char[] origElements, char[] extElements)
    {
        var expectedLen = origElements.Length + extElements.Length;
        FillTestValuesIntoList(_list, origElements);
        var extList = new CircularLinkedList();
        FillTestValuesIntoList(extList, extElements);
        var extListStartLen = extList.Length();
        
        _list.Extend(extList);

        Assert.Equal(expectedLen, _list.Length());
        Assert.Equal(extListStartLen, extList.Length());
    }

    [Theory]
    [InlineData(new char[]{'h', 'e', 'l', 'l'})]
    [InlineData(new char[]{'a'})]
    [InlineData(new char[]{})]
    public void TestClone_ResultListCloneMatchesOriginal(char[] elements)
    {
        FillTestValuesIntoList(_list, elements);

        var listCopy = _list.Clone();

        Assert.Equal(_list.Length(), listCopy.Length());
        for (int i = 0; i < listCopy.Length(); i++)
        {
            Assert.Equal(_list.Get(i), listCopy.Get(i));
        }
    }

    [Theory]
    [InlineData('p', 3, new char[]{'z', 'x', 'c', 'B', 'K', 'B'})]
    [InlineData('x', 2, new char[]{'h', 'e', 'l', 'l'})]
    [InlineData('y', 4, new char[]{'a', 'b', 'c', 'm', 'f'})]
    public void TestInsert_ResultCharInsertedOnCorrectPlace
        (char element, int index, char[] testValues)
    {
        FillTestValuesIntoList(_list, testValues);

        _list.Insert(element, index);

        Assert.Equal(element, _list.Get(index));
    }

    [Theory]
    [InlineData('x', 1, new char[]{'z', 'x', 'x', 'x', 'K', 'B'})]
    [InlineData('d', 0, new char[]{'d', 'e', 'l', 'd'})]
    [InlineData('m', 3, new char[]{'a', 'b', 'c', 'm', 'f'})]
    public void TestFindFirst_ResultFirstMatchingIndex
        (char element, int expectedIndex, char[] testValues)
    {
        FillTestValuesIntoList(_list, testValues);

        var actualIndex = _list.FindFirst(element);

        Assert.Equal(expectedIndex, actualIndex);
    }

    [Theory]
    [InlineData('x', 3, new char[]{'z', 'x', 'x', 'x', 'K', 'B'})]
    [InlineData('d', 2, new char[]{'d', 'e', 'd', '0'})]
    [InlineData('f', 4, new char[]{'a', 'a', 'q', 'q', 'f'})]
    public void TestFindLast_ResultLastMatchingIndex
        (char element, int expectedIndex, char[] testValues)
    {
        FillTestValuesIntoList(_list, testValues);

        var actualIndex = _list.FindLast(element);

        Assert.Equal(expectedIndex, actualIndex);
    }

    [Theory]
    [InlineData(new char[]{'a', 's', 'd', 'y', 'u', 'L'})]
    [InlineData(new char[]{'1', '2', '3', '4'})]
    [InlineData(new char[]{'u', 'l', 'M', 'N', 'p'})]
    public void TestReverse_ResultReversedListMatchesOriginal(char[] testValues)
    {
        FillTestValuesIntoList(_list, testValues);

        _list.Reverse();

        for (int i = 0; i < _list.Length(); i++)
        {
            var reverseIndex = testValues.Length - i - 1;
            Assert.Equal(_list.Get(i), testValues[reverseIndex]);
        }
    }
}

namespace LinkedList.CircularLinkedList;

public interface ICircularLinkedList
{
	int Length();
    void Append(char element);
    void Insert(char element, int index);
    char Delete(int index);
    void DeleteAll(char element);
    char Get(int index);
    ICircularLinkedList Clone();
    void Reverse();
    int FindFirst(char element);
    int FindLast(char element);
    void Clear();
    void Extend(ICircularLinkedList elements);
}

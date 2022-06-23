namespace LinkedList.CircularLinkedList;

public class CircularLinkedList : ICircularLinkedList
{
	private Node? _head;
	private Node? _tail;
	private int _count;

	public CircularLinkedList()
	{
		_head = null;
		_tail = null;
		_count = 0;
	}

	public void Append(char element)
	{
		var node = new Node(element);
		if (_tail != null)
		{
			node.Next = _head;
			_tail.Next = node;
			_tail = node;
		}
		else
		{
			node.Next = node;
			_head = node;
			_tail = node;
		}

		_count++;
	}

	public void Clear()
	{
		_head = _tail = null;
		_count = 0;
	}

	public ICircularLinkedList Clone()
	{
		var listCopy = new CircularLinkedList();

		for (int i = 0; i < this.Length(); i++)
		{
			listCopy.Append(this.Get(i));
		}

		return listCopy;
	}

	public char Delete(int index)
	{
		if (this.Length() == 0)
		{
			throw new InvalidOperationException("Cannot delete element from empty list.");
		}

		if (index < 0)
		{
			throw new IndexOutOfRangeException("Index must be positive.");
		}
		else if (index >= _count)
		{
			throw new IndexOutOfRangeException("Index must be within 0 and (len - 1) of list index.");
		}

		var currNode = _head;
		var prevNode = _tail;

		for (int i = 0; i < index; i++)
		{
			if (i == index)
			{
				prevNode!.Next = currNode!.Next;
				currNode.Next = null;
			}
			prevNode = prevNode!.Next;
			currNode = currNode!.Next;
		}

		_count--;
		return currNode!.Data;
	}

	public void DeleteAll(char element)
	{
		if (this.Length() == 0)
		{
			throw new InvalidOperationException("Cannot delete element from empty list.");
		}

		var currNode = _head;

		for (int i = 0; i < _count; i++)
		{
			if (currNode!.Data == element)
			{
				this.Delete(i);
				i--;
			}

			currNode = currNode!.Next;
		}
	}

	public void Extend(ICircularLinkedList elements)
	{
		throw new NotImplementedException();
	}

	public int FindFirst(char element)
	{
		throw new NotImplementedException();
	}

	//
	//
	//
	//
	public int FindLast(char element)
	{
		throw new NotImplementedException();
	}

	public char Get(int index)
	{
		if (this.Length() == 0)
		{
			throw new InvalidOperationException("Cannot get element from empty list.");
		}

		if (index < 0)
		{
			throw new IndexOutOfRangeException("Index must be positive.");
		}
		else if (index >= _count)
		{
			throw new IndexOutOfRangeException("Index must be within 0 and (len - 1) of list index.");
		}

		var currNode = _head;
		for (int i = 0; i < index; i++) currNode = currNode!.Next;

		return currNode!.Data;
	}

	public void Insert(char element, int index)
	{
		throw new NotImplementedException();
	}

	public int Length()
	{
		return _count;
	}

	
	//
	//
	//
	//
	public void Reverse()
	{
		throw new NotImplementedException();
	}
}

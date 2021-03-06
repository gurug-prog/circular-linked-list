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
		for (int i = 0; i < elements.Length(); i++)
		{
			this.Append(elements.Get(i));
		}
	}

	public int FindFirst(char element)
	{
		var currNode = _head;
		for (int i = 0; i < this.Length(); i++)
		{
			if (currNode!.Data == element)
			{
				return i;
			}
			currNode = currNode!.Next;
		}

		return -1;
	}

	public int FindLast(char element)
	{
		var currNode = _head;
		var resultIndex = -1;

		for (int i = 0; i < this.Length(); i++)
		{
			if (currNode!.Data == element)
			{
				resultIndex = i;
			}
			currNode = currNode!.Next;
		}

		return resultIndex;
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
		if (index < 0)
		{
			throw new IndexOutOfRangeException("Index must be positive.");
		}
		else if (index >= _count)
		{
			throw new IndexOutOfRangeException("Index must be within 0 and (len - 1) of list index.");
		}

		var node = new Node(element);
		var currNode = _head;

		for (int i = 0; i < index; i++)
		{
			if (i == index - 1)
			{
				var nextNode = currNode!.Next;
				currNode.Next = node;
				node.Next = nextNode;
			}
			currNode = currNode!.Next;
		}
	}

	public int Length()
	{
		return _count;
	}

	public void Reverse()
	{
		var currNode = _head;
		var prevNode = _tail;
		this._head = this._tail;
		this._tail = currNode;

		for (int i = 0; i < this.Length(); i++)
		{
			var nextNode = currNode!.Next;
			currNode!.Next = prevNode!;
			prevNode = currNode;
			currNode = nextNode;
		}
	}
}

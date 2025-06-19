using System.Collections;

namespace G08_20251406;

class MyLinkedList<T> : ICollection<T>
{
    public MyNode<T>? First { get; private set; }

    public MyNode<T>? Last { get; private set; }

    public MyLinkedList()
    {
        First = null;
        Last = null;
        Count = 0;
    }

    public MyNode<T> AddFirst(T value)
    {
        MyNode<T> newNode = new MyNode<T>(value);
        AddFirst(newNode);
        return newNode;
    }

    public void AddFirst(MyNode<T> node)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));

        node.Next = null;
        node.Previous = null;

        if (First != null)
        {
            node.Next = First;
            First.Previous = node;
        }
        else
        {
            Last = node;
        }
        First = node;
        Count++;
    }

    public MyNode<T> AddLast(T value)
    {
        MyNode<T> newNode = new MyNode<T>(value);
        AddLast(newNode);
        return newNode;
    }

    public void AddLast(MyNode<T> node)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));

        node.Next = null;
        node.Previous = null;

        if (Last != null)
        {
            Last.Next = node;
            node.Previous = Last;
        }
        else
        {
            First = node;
        }

        Last = node;
        Count++;
    }

    public MyNode<T> AddAfter(MyNode<T> node, T value)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        MyNode<T> newNode = new MyNode<T>(value);
        AddAfter(node, newNode);
        return newNode;
    }

    public void AddAfter(MyNode<T> node, MyNode<T> newNode)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        ArgumentNullException.ThrowIfNull(newNode, nameof(newNode));

        newNode.Next = node.Next;
        newNode.Previous = node;
        if (node.Next != null)
        {
            node.Next.Previous = newNode;
        }
        else
        {
            Last = newNode;
        }
        node.Next = newNode;
        Count++;
    }

    public MyNode<T> AddBefore(MyNode<T> node, T value)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        MyNode<T> newNode = new MyNode<T>(value);
        AddBefore(node, newNode);
        return newNode;
    }

    public void AddBefore(MyNode<T> node, MyNode<T> newNode)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        ArgumentNullException.ThrowIfNull(newNode, nameof(newNode));
        newNode.Next = node;
        newNode.Previous = node.Previous;
        if (node.Previous != null)
        {
            node.Previous.Next = newNode;
        }
        else
        {
            First = newNode;
        }
        node.Previous = newNode;
        Count++;
    }

    public MyNode<T>? Find(T value)
    {
        throw new NotImplementedException();
    }

    public MyNode<T>? FindLast(T value)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T value)
    {
        throw new NotImplementedException();
    }

    public void Remove(MyNode<T> node)
    {
        throw new NotImplementedException();
    }

    public void RemoveFirst()
    {
        throw new NotImplementedException();
    }

    public void RemoveLast()
    {
        throw new NotImplementedException();
    }

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    void ICollection<T>.Add(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
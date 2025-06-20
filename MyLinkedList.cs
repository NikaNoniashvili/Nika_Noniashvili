using ConsoleApp2;
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

    public MyNode<T>? AddFirst(T value)
    {
        MyNode<T> newNode = new MyNode<T>(value);
        AddFirst(newNode);
        return newNode;
    }

    public void AddFirst(MyNode<T>? node)
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

    public MyNode<T>? AddLast(T value)
    {
        MyNode<T>? newNode = new MyNode<T>(value);
        AddLast(newNode);
        return newNode;
    }

    public void AddLast(MyNode<T>? node)
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

    public MyNode<T>? AddAfter(MyNode<T>? node, T value)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        MyNode<T>? newNode = new MyNode<T>(value);
        AddAfter(node, newNode);
        return newNode;
    }

    public void AddAfter(MyNode<T>? node, MyNode<T>? newNode)
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

    public MyNode<T>? AddBefore(MyNode<T>? node, T value)
    {
        ArgumentNullException.ThrowIfNull(node, nameof(node));
        MyNode<T> newNode = new MyNode<T>(value);
        AddBefore(node, newNode);
        return newNode;
    }

    public void AddBefore(MyNode<T>? node, MyNode<T>? newNode)
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
        MyNode<T>? current = First;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current;
            }
            else
            {
                current = current.Next;
            }
        }
        return null;
    }

    public MyNode<T>? FindLast(T value)
    {
        MyNode<T>? current = First;
        MyNode<T>? find = null;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                find = current;
            }
            current = current.Next;
        }
        return find;
    }

    public bool Remove(T value)
    {
        MyNode<T> current = Find(value);

        if (current == null)
        {
            return false;
        }
        Remove(current);
        return true;
    }

    public void Remove(MyNode<T>? node)
    {
        if (node.Previous != null)
        {
            node.Previous.Next = node.Next;
        }

        if (node.Next != null)
        {
            node.Next.Previous = node.Previous;
        }

        if (node == First)
        {
            First = node.Next;
        }

        if (node == Last)
        {
            Last = node.Previous;
        }
        node.Next = null;
        node.Previous = null;
        Count--;
    }

    public void RemoveFirst()
    {
        MyNode<T> removeNode = First;

        if (First.Next != null)
        {
            First = First.Next;
            First.Previous = null;
        }
        Count--;
    }

    public void RemoveLast()
    {
        MyNode<T> removeNode = Last;

        if (Last.Previous != null)
        {
            Last = Last.Previous;
            Last.Next = null;
        }
        Count --;
    }

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public void Clear()
    {
        First = null;
        Last = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        MyNode<T>? current = First;

        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                return true;
            }
            else
            {
                current = current.Next;
            }
        }
        return false;
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
        return new MyEnumerator<T>(First);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
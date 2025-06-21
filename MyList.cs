using ConsoleApp2;
using System.Collections;

namespace G08_20251406;

class MyList<T> : MyCollectionBase<T>, IList<T>
{
    public void Add(T item)
    {
        AddItem(item);
    }

    public void Insert(int index, T item)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
        for (int i = _count; i > index; i--)
        {
            _items[i] = _items[i - 1];
        }
        _items[index] = item;
        _count++;
    }

    public void RemoveList(T item)
    {
        Remove(item);
    }

    public void RemoveAt(int index)
    {
        for (int i = index; i < _items.Length - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Array.Resize(ref _items, _items.Length - 1);
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    public int IndexOf(T item, int startIndex)
    {
        for (int i = startIndex; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    public void ContainsList(T item)
    {
        Contains(item);
    }

    public T? this[int index]
    {
        get
        {
            return _items[index];
        }

        set
        {
            _items[index] = value;
        }
    }
}
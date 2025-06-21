using System.Collections;

namespace ConsoleApp2;

abstract class MyCollectionBase<T> : ICollection<T>
{
    public T?[] _items;
    public int _count;

    public MyCollectionBase()
    {
        _items = new T[4];
        _count = 0;
    }

    void ICollection<T>.Add(T item)
    {
        AddItem(item);
    }

    protected void AddItem(T value)
    {
        if (_items.Length == _count)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        _count++;
        _items[_count - 1] = value;
    }

    protected bool Remove(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
            {
                _items[i] = _items[_count - 1];
                _items[_count - 1] = default(T);
                _count--;
                return true;
            }
        }
        return false;
    }

    public void Clear()
    {
        _items = new T[4];
        _count = 0;
    }

    protected bool Contains(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
            {
                return true;
            }
        }
        return false;
    }

    protected void CopyTo(T[] array, int arrayIndex)
    {
        for (int i = 0; i < _count; i++)
        {
            array[arrayIndex + i] = _items[i];
        }
    }

    public void TrimToSize()
    {
        if (Count < 4)
        {
            Array.Resize(ref _items, 4);
            return;
        }
        Array.Resize(ref _items, Count);
    }

    public void CheckNull()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("empty");
        }
    }

    public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(_items);

    public int Count => _count;

    bool ICollection<T>.IsReadOnly => false;

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    bool ICollection<T>.Contains(T item)
    {
        return Contains(item);
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        CopyTo(array, arrayIndex);
    }

    bool ICollection<T>.Remove(T item)
    {
        return Remove(item);
    }
}

using G08_20251406;
using System.Collections;

namespace ConsoleApp2;

class MyEnumerator<T> : IEnumerator<T>
{
    private T?[] _members;
    private int _position = -1;

    public MyEnumerator(T[] members)
    {
        _members = members;
    }

    public T Current => _members[_position];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        _position++;
        return (_position < _members.Length);
    }

    public void Reset()
    {
        _position = -1;
    }
}

class StackEnumerator<T> : IEnumerator<T>
{
    private T?[] _items;
    private int _position;
    private int _count;
    public StackEnumerator(T?[] items, int count)
    {
        _items = items;
        _count = count;
        _position = count;
    }

    public T Current => _items[_position];

    object IEnumerator.Current => Current;

    public void Dispose()
    {

    }
    public bool MoveNext()
    {
        if (_position == 0)
        {
            return false;
        }
        _position--;
        return true;
    }
    public void Reset()
    {
        _position = _count;
    }
}

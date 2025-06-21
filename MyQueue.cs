using System.Collections;

namespace ConsoleApp2;

class MyQueue<T> : MyCollectionBase<T>
{
    public T Dequeue()
    {
        CheckNull();
        T value = _items[0];
        for (int i = 1; i < _count; i++)
        {
            _items[i - 1] = _items[i];
        }
        _items[_count - 1] = default(T);
        _count--;
        return value;
    }

    public void Enqueue(T item) => AddItem(item);

    public T Peek()
    {
        CheckNull();
        return _items[0];
    }
}


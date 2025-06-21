using ConsoleApp2;

namespace G08_20251406;

class MyStack<T> : MyCollectionBase<T>
{
    public T Pop()
    {
        CheckNull();
        T? value = _items[_count - 1];
        _items[_count - 1] = default(T);
        _count--;
        return value;
    }

    public void Push(T value) => AddItem(value);

    public T Peek()
    {
        CheckNull();
        return _items[_count - 1];
    }
    public IEnumerator<T> GetEnumerator() => new StackEnumerator<T>(_items, _count);
}
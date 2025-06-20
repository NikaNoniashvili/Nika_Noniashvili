

using G08_20251406;
using System.Collections;

namespace ConsoleApp2;

class MyEnumerator<T> : IEnumerator<T>
{
    public MyNode<T> current;
    public MyNode<T> First;

    public MyEnumerator(MyNode<T> first)
    {
        First = first;
        current = null;
    }

    public T Current => current.Value;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (current == null)
        {
            current = First;
        }
        else
        {
            current = current.Next;
        }

        return current != null;
    }

    public void Reset()
    {
        current = null;
    }
}

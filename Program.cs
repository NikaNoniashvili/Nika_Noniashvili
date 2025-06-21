using System.Collections;

namespace ConsoleApp57
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.TrimToSize();
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------");

            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.TrimToSize();
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }

    class MyQueue<T> : IEnumerable<T>
    {
        public int Count { get; set; }
        private T?[] _items;
        public MyQueue()
        {
            _items = new T?[4];
            Count = 0;
        }

        public void Enqueue(T? value)
        {
            if (_items.Length == Count)
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
            Count++;
            _items[Count - 1] = value;
        }

        public T? Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T? value = _items[0];
            for (int i = 1; i < Count; i++)
            {
                _items[i - 1] = _items[i];
            }
            _items[Count - 1] = default(T);
            Count--;
            return value;
        }
        public T? Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return _items[0];
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

        public IEnumerator<T> GetEnumerator()
        {
            return new MyQueueEnumerator<T>(_items, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyQueueEnumerator<T>(_items, Count);
        }
    }

    class MyStack<T> : IEnumerable<T>
    {
        private T?[] _items;

        public MyStack()
        {
            _items = new T?[4];
            Count = 0;
        }

        public void Push(T? value)
        {
            if (_items.Length == Count)
            {
                Array.Resize(ref _items, _items.Length * 2);
            }

            Count++;
            _items[Count - 1] = value;
        }

        public T? Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T? value = _items[Count - 1];
            _items[Count - 1] = default(T);
            Count--;
            return value;
        }

        public T? Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _items[Count - 1];
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

        public IEnumerator<T> GetEnumerator()
        {
            return new MyStackEnumerator<T>(_items, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyStackEnumerator<T>(_items, Count);
        }

        public int Count { get; private set; }
    }

    class MyStackEnumerator<T> : IEnumerator<T>
    {
        private T?[] _items;
        private int _position;
        private int _count;
        public MyStackEnumerator(T?[] items, int count)
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

    class MyQueueEnumerator<T> : IEnumerator<T>
    {
        private T?[] _items;
        private int _count;
        private int _position;
        public MyQueueEnumerator(T?[] items, int count)
        {
            _items = items;
            _count = count;
            _position = -1;
        }
        public T? Current => _items[_position];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (_position == _count - 1)
            {
                return false;
            }
            _position++;
            return true;
        }
        public void Reset()
        {
            _position = -1;
        }
    }
}
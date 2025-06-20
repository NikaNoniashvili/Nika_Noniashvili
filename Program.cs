namespace G08_20251406;

internal class Program
{
    static void Main()
    {
        MyLinkedList<int> list = new MyLinkedList<int>();
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);
        list.AddFirst(4);
        list.AddLast(5);
        list.AddLast(6);
        list.AddAfter(list.First, 7);
        list.AddAfter(list.First, 8);
        list.AddBefore(list.Last, 9);
        list.AddBefore(list.Last, 10);
        list.Find(2);
        list.FindLast(3);
        list.Remove(7);
        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveLast();
        list.Clear();
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);
        list.Contains(2);


        MyNode<int> current = list.First;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }
}
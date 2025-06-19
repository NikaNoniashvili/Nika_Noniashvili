namespace G08_20251406;

class MyNode<T>
{
    public MyNode(T? value)
    {
        Value = value;
    }

    public T? Value { get; set; }
    public MyNode<T>? Next { get; set; }
    public MyNode<T>? Previous { get; set; }

    public override string? ToString()
    {
        return Value?.ToString();
    }
}
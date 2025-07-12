namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        string path = @"D:\StreamSum.txt";
        StreamHelper streamHelper = new StreamHelper(path);
        int? result = streamHelper.FileCountWords();
        Console.WriteLine(result);
    }
}
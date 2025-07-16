namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        string path = @"D:\Stream File.txt";

        StreamHelper streamHelper = new StreamHelper(path);
        string result = streamHelper.FileReader();
        Console.WriteLine(result);
    }
}
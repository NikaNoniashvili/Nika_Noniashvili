namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        string path = @"D:\File.txt";

        StreamHelper streamHelper = new StreamHelper(path);
        streamHelper.FileCountEachWords();
    }
}
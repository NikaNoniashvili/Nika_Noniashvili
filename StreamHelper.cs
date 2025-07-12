namespace ConsoleApp2;

class StreamHelper
{
    public string? Path { get; set; }

    public StreamHelper(string path)
    {
        Path = path;
    }

    public void FileCheck()
    {
        if (!File.Exists(Path))
        {
            throw new ArgumentNullException($"File not found: {Path}");
        }
    }

    public string? FileSum()
    {
        FileCheck();
        int? sum = 0;
        string? line;
        int number;

        StreamReader reader = new StreamReader(Path);

        while ((line = reader.ReadLine()) != null)
        {
            if (int.TryParse(line, out number))
            {
                sum += number;
            }
        }
        reader.Close();
        return $"{sum}";
    }

    public int? FileLinesCount()
    {
        FileCheck();
        int? count = 0;
        StreamReader reader = new StreamReader(Path);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            count++;
        }
        reader.Close();
        return count;
    }

    public string? FileReader()
    {
        FileCheck();
        StreamReader reader = new StreamReader(Path);
        string text = reader.ReadToEnd();
        reader.Close();
        return text;
    }

    public string? FileReaderLine()
    {
        FileCheck();
        FileStream fileStream = new FileStream(Path, FileMode.Open);
        StreamReader streamReader = new StreamReader(fileStream);
        string? line = streamReader.ReadLine();
        streamReader.Close();
        return line;
    }

    public string? FileReaderLastLine()
    {
        FileCheck();
        StreamReader reader = new StreamReader(Path);
        string? lastLine = null;
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            lastLine = line;
        }
        reader.Close();
        return lastLine;
    }

    public void FileWriterOpenOrCreate()
    {
        StreamWriter writer = new StreamWriter(Path);
        while (true)
        {
            Console.Write("dasamateblat daaweret enter sxva shemtxvevashi exit : ");
            string key = Console.ReadLine().ToUpper();

            if (key == "EXIT")
            {
                break;
            }
            else
            {
                Console.Write("Enter text in file : ");
                writer.WriteLine(Console.ReadLine());
            }
        }
        writer.Close();
    }

    public void FileWriterOpenOrCreate(string text)
    {
        StreamWriter writer = new StreamWriter(Path);
        writer.WriteLine(text);
        writer.Close();
    }

    public void FileWriterAppend()
    {
        FileCheck();
        string path = Path;
        FileStream fileStream = new FileStream(Path, FileMode.Append);
        StreamWriter writer = new StreamWriter(fileStream);


        while (true)
        {
            Console.Write("dasamateblat daaweret enter sxva shemtxvevashi exit : ");
            string key = Console.ReadLine().ToUpper();

            if (key == "EXIT")
            {
                break;
            }
            else
            {
                Console.Write("Enter text in file : ");
                writer.WriteLine(Console.ReadLine());
            }
        }
        writer.Close();
        fileStream.Close();
    }

    public void FileWriterAppend(string text)
    {
        FileCheck();
        FileStream fileStream = new FileStream(Path, FileMode.Append);
        StreamWriter writer = new StreamWriter(fileStream);
        writer.WriteLine(text);
        writer.Close();
        fileStream.Close();
    }

    public void FileGadatanaTxt(string file)
    {
        FileCheck();
        StreamReader reader = new StreamReader(Path);
        StreamWriter writer = new StreamWriter(file);

        int number = 1;
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            if (line != "" || line == "")
            {
                writer.WriteLine($"{number}. {line}");
                number++;
            }
            else
            {
                writer.WriteLine();
            }
        }
        reader.Close();
        writer.Close();
    }

    public int? FileCountSymbols()
    {
        FileCheck();
        StreamReader reader = new StreamReader(Path);
        int count = 0;
        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char symbol = line[i];
                if (symbol != ' ' && symbol != '\n' && symbol != '\r' && symbol != '\t')
                {
                    count++;
                }
            }
        }
        reader.Close();
        return count;
    }

    public int? FileCountWords()
    {
        FileCheck();
        StreamReader reader  = new StreamReader(Path);
        int count = 0;
        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            bool word = false;
            for (int i = 0; i < line.Length; i++)
            {
                char symbol = line[i];
                if (symbol != ' ' && symbol != '\n' && symbol != '\r' && symbol != '\t')
                {
                    if (!word)
                    {
                        count++;
                        word = true;
                    }
                }
                else
                {
                    word = false;
                }
            }
        }
        reader.Close();
        return count;
    }
}

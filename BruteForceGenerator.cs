namespace ConsoleApp126;

static class BruteForceGenerator
{
    public static void Generate(string filePath, int minLength, int maxLength, bool digits = true, bool letters = true)
    {
        ValidateParameters(filePath, minLength, maxLength, digits, letters);
        EnsureDirectoryExists(filePath);

        var alphabet = BuildAlphabet(digits, letters);
        if (alphabet.Length == 0) return;

        long attempts = 0;
        const long progressInterval = 10000;

        var writer = new StreamWriter(filePath, append: false);

        for (int length = minLength; length <= maxLength; length++)
        {
            GenerateForLength(length, alphabet, writer, ref attempts, progressInterval);
        }

        writer.Flush(); 
        writer.Close();  
    }

    private static void GenerateForLength(int length, char[] alphabet, StreamWriter writer, ref long attempts, long progressInterval)
    {
        char[] current = new char[length];
        GenerateRecursive(current, 0, alphabet, writer, ref attempts, progressInterval);
    }

    private static void GenerateRecursive(char[] current, int position, char[] alphabet, StreamWriter writer, ref long attempts, long progressInterval)
    {
        if (position == current.Length)
        {
            writer.WriteLine(new string(current));
            attempts++;
            if (attempts % progressInterval == 0)
            {
                Console.Write(".");
            }
            return;
        }

        for (int i = 0; i < alphabet.Length; i++)
        {
            current[position] = alphabet[i];
            GenerateRecursive(current, position + 1, alphabet, writer, ref attempts, progressInterval);
        }
    }

    private static char[] BuildAlphabet(bool digits, bool letters)
    {
        var alphabet = new List<char>();
        if (digits)
        {
            for (char c = '0'; c <= '9'; c++)
                alphabet.Add(c);
        }
        if (letters)
        {
            for (char c = 'a'; c <= 'z'; c++)
                alphabet.Add(c);
            for (char c = 'A'; c <= 'Z'; c++)
                alphabet.Add(c);
        }
        return alphabet.ToArray();
    }

    private static void ValidateParameters(string filePath, int minLength, int maxLength, bool digits, bool letters)
    {
        if (filePath == null)
            throw new ArgumentNullException(nameof(filePath));
        if (minLength < 1)
            throw new ArgumentOutOfRangeException(nameof(minLength), "minLength must be at least 1.");
        if (maxLength < minLength)
            throw new ArgumentOutOfRangeException(nameof(maxLength), "maxLength must be greater than or equal to minLength.");
        if (!digits && !letters)
            throw new ArgumentException("At least one of 'digits' or 'letters' must be true.");
    }

    private static void EnsureDirectoryExists(string filePath)
    {
        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }
}
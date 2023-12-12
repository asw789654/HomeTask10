using System.Text.RegularExpressions;

List<string> text = new List<string>();
List<string> forbiddenWords = new List<string>();
try
{
    using (StreamReader forbiddenWordsReader = new StreamReader("forbidden_words.txt"))
    {
        foreach (string word in forbiddenWordsReader.ReadLine().Split(' '))
        {
            forbiddenWords.Add(word);
        }
    }
    Console.WriteLine("Введите название файла: ");
    string fileName = Console.ReadLine();
    using (StreamReader mainTextReader = new StreamReader(fileName + ".txt"))
    {
        while (!mainTextReader.EndOfStream)
        {
            text.Add(mainTextReader.ReadLine());
        }
    }
    for (int i = 0; i < text.Count; i++)
    {
        foreach (string word in forbiddenWords)
        {
            text[i] = Regex.Replace(text[i], word, new string('*', word.Length), RegexOptions.IgnoreCase);
        }
        Console.WriteLine(text[i]);
    }
}
catch (Exception exeption)
{
    Console.WriteLine(exeption.Message);
}


char[] separators = new char[] { '.', '?', '!', ' ', ';', ':', ',' };
using (StreamReader reader = new StreamReader("MyTxt.txt"))
{
    using (StreamWriter writer = new StreamWriter("Result.txt", false))
    {
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            List<string> words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            var allWordsCount = words.GroupBy(x => x).Select(x => new { Word = x.Key, Count = x.Count() });
            var result = allWordsCount.MaxBy(x => x.Count);
            Console.WriteLine(result.Word + ' ' + result.Count);
            writer.WriteLine(result.Word + ' ' + result.Count);
        }
    }
}
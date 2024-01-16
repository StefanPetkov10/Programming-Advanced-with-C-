namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            HashSet<string> words = new HashSet<string>(File.ReadAllLines(wordsFilePath), StringComparer.OrdinalIgnoreCase);


            Dictionary<string, int> wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (string line in File.ReadLines(textFilePath))
            {
                string[] wordsInLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in wordsInLine)
                {
                    if (words.Contains(word))
                    {
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                        else
                        {
                            wordCounts[word] = 1;
                        }
                    }
                }
            }

            var sortedWordCounts = wordCounts.OrderByDescending(pair => pair.Value);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var entry in sortedWordCounts)
                {
                    writer.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }
        }
    }
}
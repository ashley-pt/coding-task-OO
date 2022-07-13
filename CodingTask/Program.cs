using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file name:");
            String path = Console.ReadLine();

            Program P1 = new Program();

            Dictionary<String, Int32> countOfWords = P1.countWords(P1.readFile(path));
            if(countOfWords.Count == 0)
            {
                Console.WriteLine("File is empty");
            }
            else
            {
                foreach (KeyValuePair<String, Int32> kv in countOfWords)
                {
                    Console.WriteLine(kv.Value + ": " + kv.Key);
                }
            }
            
        }

        public List<String> readFile(String file)
        {
            List<String> words = new List<string>();

            String contents = File.ReadAllText(file);
            if(contents.Length != 0)
            {
                String cleanContents = Regex.Replace(contents, @"[^\w\s]", "").ToLower();
                List<String> lines = cleanContents.Split("\n").ToList();

                foreach (String line in lines)
                {
                    words.AddRange(line.Split(" ").ToList());
                }
            }
            
            return words;
        }

        public Dictionary<String, Int32> countWords(List<String> words)
        {
            Dictionary<String, Int32> wordCount = new Dictionary<string, int>();

            foreach(String word in words)
            {
                if(wordCount.ContainsKey(word))
                {
                    Int32 number = wordCount[word];
                    wordCount[word] = number + 1;
                } 
                else
                {
                    wordCount.Add(word, 1);
                }
            }

            return wordCount;
        }
 
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.StepwiseWord
{
    class StepwiseWordSolution
    {
        private static void Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    Console.WriteLine(GetWordInStepwiseForm(singleLine.Split(' ')));
                }
            }
        }

        private static string GetWordInStepwiseForm(string[] words)
        {
            return String.Join(" ", GetLongestWord(words).Select((t, i) => new String('*', i) + t).ToList());
        }

        private static IEnumerable<char> GetLongestWord(string[] words)
        {
            string longestWord = String.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0) longestWord = words[0];
                else
                {
                    if (words[i].Length > longestWord.Length) longestWord = words[i];
                }
            }

            return longestWord.ToCharArray();
        }

        static IEnumerable<string> ReadFile(string filePath)
        {
            string[] fileLines = { };

            try
            {
                fileLines = File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

            return fileLines.ToList();
        }
    }
}

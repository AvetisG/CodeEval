using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.MixedContent
{
    class MixedContentSolution
    {
        static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    var individualWords = singleLine.Split(',');

                    Console.WriteLine(SeparateDigitsFromStrings(individualWords));
                }
            }
        }

        private static string SeparateDigitsFromStrings(string[] individualWords)
        {
            var strings = new List<string>();
            var numbers = new List<string>();
            
            for (int i = 0; i < individualWords.Length; i++)
            {
                if (IsDigit(individualWords[i]))
                {
                    numbers.Add(individualWords[i]);
                }
                else
                {
                    strings.Add(individualWords[i]);
                }
            }

            if (strings.Any() && numbers.Any()) return String.Join(",", strings) + "|" + String.Join(",", numbers);
            if (strings.Any() && !numbers.Any()) return String.Join(",", strings);
            return String.Join(",", numbers);
        }

        private static bool IsDigit(string individualWord)
        {
            int n;
            return  int.TryParse(individualWord, out n);
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

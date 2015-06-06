using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.ReadMore
{
    class ReadMoreSolution
    {
        static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    if (singleLine != String.Empty)
                    {
                        Console.WriteLine(singleLine.Length <= 55 ? singleLine : GetShortenedString(singleLine) + "... <Read More>");
                    }
                }
            }
        }

        private static string GetShortenedString(string singleLine)
        {
            var shortenedLine = singleLine.Substring(0, 40);

            if (!shortenedLine.Contains(" ")) return shortenedLine;
            
            List<string> array = shortenedLine.Split(' ').ToList();

            array.RemoveAt(array.Count - 1);

            return array.Count() > 1 ? String.Join(" ", array) : String.Join("", array);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.FindAWriter
{
    class FindAWriterSolution
    {
        private static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    var mixedString = singleLine.Split('|')[0];
                    var keys = singleLine.Split('|')[1].Split(' ').Select(a => a).Where(a => a != String.Empty);

                    Console.WriteLine(DecypherTheName(mixedString, keys));
                }
            }
        }

        private static string DecypherTheName(string mixedString, IEnumerable<string> keys)
        {
            return keys.Aggregate(String.Empty, (current, key) => current + mixedString[Convert.ToInt16(key) - 1]);
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

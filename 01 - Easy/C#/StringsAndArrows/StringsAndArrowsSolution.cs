using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.StringsAndArrows
{
    class StringsAndArrowsSolution
    {
        private static void Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
					Console.WriteLine(CountArrows(singleLine.ToCharArray()));
                }
            }
        }

        private static int CountArrows(char[] singleLine)
        {
            if (singleLine.Length < 5) return 0;

            var trackLength = singleLine.Length;
            var arrowCount = 0;

            for (int i = 0; i < singleLine.Length; i++)
            {
                if (trackLength - i >= 5)
                {
                    if ((singleLine[i] == '>' && singleLine[i + 1] == '>' && singleLine[i + 2] == '-' && singleLine[i + 3] == '-' && singleLine[i + 4] == '>')
                        || singleLine[i] == '<' && singleLine[i + 1] == '-' && singleLine[i + 2] == '-' && singleLine[i + 3] == '<' && singleLine[i + 4] == '<')
                    {
                        arrowCount++;
                    }
                }
            }

            return arrowCount;
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

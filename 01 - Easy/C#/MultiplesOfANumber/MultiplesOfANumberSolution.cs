using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.MultiplesOfANumber
{
    class MultiplesOfANumberSolution
    {
        private static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    var limit = Convert.ToInt16(singleLine.Split(',')[0]);
                    var n = Convert.ToInt16(singleLine.Split(',')[1]);

                    Console.WriteLine(FindMultiple(limit, n));
                }
            }
        }

        private static int FindMultiple(int limit, int s)
        {
            int increment = s;

            while (s < limit)
            {
                s = s + increment;
            }
            return s;
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

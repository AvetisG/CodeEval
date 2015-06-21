using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.HappyNumbers
{
    class HappyNumbersSolution
    {
        private static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    Console.WriteLine(DetectHappyNumber(singleLine.ToCharArray()));
                }
            }
        }

        private static int DetectHappyNumber(char[] numberArray)
        {
            int sum = 0;
            List<int> cycleTracker = new List<int>();

            while (sum != 1)
            {
                sum = numberArray.Aggregate(0, (current, number) => current + Convert.ToInt32(Math.Pow((int) Char.GetNumericValue(number), 2)));

                if (cycleTracker.Contains(sum))
                {
                    sum = 0;
                    break;
                }

                cycleTracker.Add(sum);

                numberArray = sum.ToString().ToCharArray();
            }

            return sum;
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

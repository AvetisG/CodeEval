using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.MinimumDistance
{
    class MinimumDistanceSolution
    {
        static void Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    if (singleLine != String.Empty)
                    {
                        var addresses =
                            singleLine.Split()
                                .Select(a => Convert.ToInt32(a))
                                .Skip(1)
                                .Take(singleLine.Length)
                                .OrderBy(a => a);

                        Console.WriteLine(GetMinimumDistance(addresses));
                    }
                }
            }
        }

        private static long GetMinimumDistance(IOrderedEnumerable<int> addresses)
        {
            long minimumDistanceSum = long.MaxValue;
            var minimumDistance = addresses.First();
            var maximumDistance = addresses.Last();

            for (int i = minimumDistance; i <= maximumDistance; i++)
            {
                long distance = GetDistanceFromPoint(addresses, i);

                if (distance < minimumDistanceSum) minimumDistanceSum = distance;
            }

            return minimumDistanceSum;
        }

        private static long GetDistanceFromPoint(IEnumerable<int> addresses, int i)
        {
            return addresses.Aggregate<int, long>(0, (current, address) => current + Math.Abs(address - i));
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


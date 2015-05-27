using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.SwapNumbers
{
    class SwapNumbersSolution
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
                        var alphanumericArray = singleLine.Split(' ');

                        var alphanumericArraySwapped = alphanumericArray.Select(
                            alphanumbericValue => alphanumbericValue.Last() + alphanumbericValue.Substring(1, alphanumbericValue.Length - 2) + alphanumbericValue.First()).ToList();

                        Console.WriteLine(String.Join(" ", alphanumericArraySwapped));
                    }
                }
            }
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

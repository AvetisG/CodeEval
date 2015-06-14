using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.NModM
{
    class NModMSolution
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
                        Console.WriteLine(GetNModM(Convert.ToInt32(singleLine.Split(',')[0]), Convert.ToInt32(singleLine.Split(',')[1])));
                    }
                }
            }
        }

        private static int GetNModM(int N, int M)
        {
            return N - (N / M) * M;
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

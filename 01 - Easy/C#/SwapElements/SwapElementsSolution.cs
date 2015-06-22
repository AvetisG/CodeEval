using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.SwapElements
{
    class SwapElementsSolution
    {
        private static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    var stringToBeManipulated = singleLine.Split(':')[0];
                    var howToManipulateString = singleLine.Split(':')[1];

                    Console.WriteLine(SwapTheElements(
                        stringToBeManipulated.Split(' ').Select(a => a).Where(a => !a.Equals(String.Empty)).ToList(), 
                        howToManipulateString.Split(',').Select(a => a.Trim()))
                        );
                }
            }
        }

        private static string SwapTheElements(IList<string> stringToBeManiulated, IEnumerable<string> swapParameters)
        {
            foreach (var swapParameter in swapParameters)
            {
                var firstSwap = Convert.ToInt32(swapParameter.Split('-')[0]);
                var secondSwap = Convert.ToInt32(swapParameter.Split('-')[1]);

                var temp = stringToBeManiulated[secondSwap];
                stringToBeManiulated[secondSwap] = stringToBeManiulated[firstSwap];
                stringToBeManiulated[firstSwap] = temp;
            }

            return String.Join(" ", stringToBeManiulated);
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

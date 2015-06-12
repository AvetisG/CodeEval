using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.SwapCase
{
    class SwapCaseSolution
    {
        private static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    Console.WriteLine(SwapTheCase(singleLine));
                }
            }
        }

        private static string SwapTheCase(string singleLine)
        {
            var swapped = new StringBuilder();
            var array = singleLine.ToCharArray();

            foreach (Char element in array)
            {
                if (Char.IsLetter(element) && Char.IsLower(element)) swapped.Append(element.ToString().ToUpper());
                if (Char.IsLetter(element) && Char.IsUpper(element)) swapped.Append(element.ToString().ToLower());
                if (!Char.IsLetter(element)) swapped.Append(element.ToString());
            }

            return swapped.ToString();
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.HiddenDigits
{
    class HiddenDigitsSolution
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
                        Console.WriteLine(GetHiddenDigit(singleLine));
                    }
                }
            }
        }

        private static string GetHiddenDigit(string singleLine)
        {
            var unhiddenDigits = new StringBuilder();
            
            Dictionary<string, int> acceptedDigits = new Dictionary<string, int>();
            acceptedDigits.Add("a", 0);
            acceptedDigits.Add("b", 1);
            acceptedDigits.Add("c", 2);
            acceptedDigits.Add("d", 3);
            acceptedDigits.Add("e", 4);
            acceptedDigits.Add("f", 5);
            acceptedDigits.Add("g", 6);
            acceptedDigits.Add("h", 7);
            acceptedDigits.Add("i", 8);
            acceptedDigits.Add("j", 9);

            var singleLineArray = singleLine.ToCharArray();

            for (int i = 0; i < singleLineArray.Length; i++)
            {
                if (Char.IsDigit(singleLineArray[i])) unhiddenDigits.Append(singleLineArray[i]);
                else if (acceptedDigits.ContainsKey(singleLineArray[i].ToString())) unhiddenDigits.Append(acceptedDigits.FirstOrDefault(a => a.Key == singleLineArray[i].ToString()).Value);
            }

            return unhiddenDigits.ToString().Length == 0 ? "NONE" : unhiddenDigits.ToString();
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

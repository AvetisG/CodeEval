using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.RomanNumerals
{
    class RomanNumeralsSolution
    {
        private static readonly Dictionary<int, string> _romanNumerals = new Dictionary<int, string>()
        {
            {1, "I"},
            {5, "V"},
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000, "M"},
        };

        static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    if (singleLine != String.Empty)
                    {
                        Console.WriteLine(GetRomanNumerals(Convert.ToInt32(singleLine)));
                    }
                }
            }
        }

        private static string GetRomanNumerals(int number)
        {
            if (number == 0) return "";

            if (number == 1) return "I";

            if (number == 4) return "IV" + GetRomanNumerals(number - 4);

            if (number == 9) return "IX" + GetRomanNumerals(number - 9);

            if (number >= 40 && number < 50) return "XL" + GetRomanNumerals(number - 40);

            if (number >= 90 && number < 100 ) return "XC" + GetRomanNumerals(number - 90);

            if (number >= 400 && number < 500) return "CD" + GetRomanNumerals(number - 400);

            if (number >= 900 && number < 1000) return "CM" + GetRomanNumerals(number - 900);

            KeyValuePair<int, string> highestNumberThanTheGiven = _romanNumerals.LastOrDefault(rn => rn.Key <= number);

            return highestNumberThanTheGiven.Value + GetRomanNumerals(number - highestNumberThanTheGiven.Key);
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

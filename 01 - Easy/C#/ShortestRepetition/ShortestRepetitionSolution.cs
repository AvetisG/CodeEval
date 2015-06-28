using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.ShortestRepetition
{
    class ShortestRepetitionSolution
	{
		static void Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
                IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var singleLine in linesOfFile)
				{
                    Console.WriteLine(FindShortestRepetition(singleLine));	
				}
			}
		}

        private static int FindShortestRepetition(string singleLine)
        {
            var repeatingString = FindRepeatingString(singleLine);
            return singleLine.Length / singleLine.Replace(repeatingString, " ").Count();
        }

        private static string FindRepeatingString(string singleLine)
        {
            if (singleLine == new String(singleLine[0], singleLine.Length)) return singleLine[0].ToString();

            var charArrayOfRepeatingCharacters = singleLine.ToCharArray();
            var pattern = new StringBuilder();

            foreach (var character in charArrayOfRepeatingCharacters)
            {
                pattern.Append(character);

                if (singleLine.Replace(pattern.ToString(), "").Length == 0) return pattern.ToString();
            }

            return pattern.ToString();
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

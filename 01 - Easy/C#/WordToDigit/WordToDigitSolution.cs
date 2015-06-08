using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.WordToDigit
{
	class WordToDigitSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesInAFile = ReadFile(args[0]);

				foreach (var singleLine in linesInAFile)
				{
					string[] numbersInWords = singleLine.Split(';');

					List<int> convertedToNumbers = numbersInWords.Select(FromWordToNumber).ToList();

					Console.WriteLine(String.Join("", convertedToNumbers));
				}
			}
		}

		static int FromWordToNumber(string word)
		{
			switch (word)
			{
				case "zero":
					return 0;
				case "one":
					return 1;
				case "two":
					return 2;
				case "three":
					return 3;
				case "four":
					return 4;
				case "five":
					return 5;
				case "six":
					return 6;
				case "seven":
					return 7;
				case "eight":
					return 8;
				case "nine":
					return 9;
				default:
					return 0;
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


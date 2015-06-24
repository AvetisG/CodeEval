using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.SumOfDigits
{
	class SumOfDigitsSolution
	{
		static void Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfPositiveIntegers = ReadFile(args[0]);

				foreach (var lineOfPositiveIntegers in linesOfPositiveIntegers)
				{
					Console.WriteLine(GetTheSumOfTheNumbersThatMakeUpTheInteger(lineOfPositiveIntegers.ToCharArray()));
				}
			}
		}

		private static int GetTheSumOfTheNumbersThatMakeUpTheInteger(IEnumerable<char> argToCharArray)
		{
			int total = 0;

			foreach (var singleNumber in argToCharArray)
			{
				total = total + (int)Char.GetNumericValue(singleNumber);
			}

			return total;
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


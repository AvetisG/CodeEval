using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.SimpleSorting
{
	class SimpleSortingSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var singleLine in linesOfFile)
				{
					Console.WriteLine(String.Join(" ", GetArrayOfNumbers(singleLine.Split(' '))));
				}
			}
		}

		static IEnumerable<decimal> GetArrayOfNumbers(IEnumerable<string> argSingleLine)
		{
			List<decimal> arrayOfNumbers = argSingleLine.Select(line => Convert.ToDecimal(line)).ToList();

			return arrayOfNumbers.OrderBy(argArg => argArg);
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

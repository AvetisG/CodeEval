using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.SumOfIntegersFromFile
{
	class SumOfIntegersFromFileSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> listOfIntegers = ReadFile(args[0]);

				int total = listOfIntegers.Aggregate(0, (current, singleInteger) => current + Convert.ToInt16(singleInteger));

				Console.Write(total);
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


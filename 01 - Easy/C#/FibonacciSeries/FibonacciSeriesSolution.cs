using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.FibonacciSeries
{
	class FibonacciSeriesSolution
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
						Console.WriteLine(GetNthFibonacciOf(Convert.ToInt16(singleLine)));
					}
				}
			}
		}

		static int GetNthFibonacciOf(int seed)
		{
			int startA = 0;
			int startB = 1;

			for (int i = 0; i < seed; i++)
			{
				var placeHolderValue = startA;
				startA = startB;
				startB = placeHolderValue + startB;

			}

			return startA;
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

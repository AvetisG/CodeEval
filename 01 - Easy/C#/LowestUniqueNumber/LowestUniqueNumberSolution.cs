using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.LowestUniqueNumber
{
	class LowestUniqueNumberSolution
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
						Console.WriteLine(GetLowestUniqueNumberPlayerPosition(singleLine.Split(' ')));
					}
				}
			}
		}

		private static int GetLowestUniqueNumberPlayerPosition(string[] singleLine)
		{
			Dictionary<int, int> lowestUniqueNumbers = new Dictionary<int, int>();

			for (int i=0; i<singleLine.Length; i++)
			{
				if (singleLine.Count(l => l.Equals(singleLine[i])) == 1) lowestUniqueNumbers.Add(i + 1, Convert.ToInt32(singleLine[i]));
			}

			if (!lowestUniqueNumbers.Any()) return 0;

			return lowestUniqueNumbers.FirstOrDefault(a => a.Value == lowestUniqueNumbers.Min(argA => argA.Value)).Key;
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

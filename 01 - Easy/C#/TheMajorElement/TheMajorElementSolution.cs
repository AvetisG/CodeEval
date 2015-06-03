using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.TheMajorElement
{
	class TheMajorElementSolution
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
						Console.WriteLine(FindMajorElement(singleLine.Split(',')));
					}
				}
			}
		}

		private static string FindMajorElement(string[] argSingleLine)
		{
			string majorElement = "None";
			int majorElementRepetitionCount = argSingleLine.Length/2;

			var optimizedArray = argSingleLine.OrderBy(a => a).ToArray();
			
			for (int i = 0; i < optimizedArray.Length; i++)
			{
				if (i == 0)
				{
					if (argSingleLine.Count(a => a == optimizedArray[i]) >= majorElementRepetitionCount)
					{
						return optimizedArray[i];
					}
				}
				else if (optimizedArray[i - 1] != optimizedArray[i])
				{
					if (argSingleLine.Count(a => a == optimizedArray[i]) >= majorElementRepetitionCount)
					{
						return optimizedArray[i];
					}
				}
			}

			return majorElement;
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

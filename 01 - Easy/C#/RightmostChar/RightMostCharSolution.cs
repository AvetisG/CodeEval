using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.RightmostChar
{
	class RightMostCharSolution
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
						var stringToSearchIn = singleLine.Split(',')[0];
						var characterForSearch = singleLine.Split(',')[1];

						Console.WriteLine(stringToSearchIn.LastIndexOf(characterForSearch));
					}
				}
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

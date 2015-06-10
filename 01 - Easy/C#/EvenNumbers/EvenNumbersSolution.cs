using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.EvenNumbers
{
	class EvenNumbersSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesInAFile = ReadFile(args[0]);

				foreach (var singleLine in linesInAFile)
				{
					if (Convert.ToInt16(singleLine) > 0 && Convert.ToInt16(singleLine) < 5000)
					{
						Console.WriteLine(Convert.ToInt16(singleLine) % 2 == 0 ? 1 : 0);
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


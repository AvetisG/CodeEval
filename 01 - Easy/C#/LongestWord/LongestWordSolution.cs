using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.LongestWord
{
	class LongestWordSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var lineOfFile in linesOfFile)
				{
					var individualWords = lineOfFile.Split(' ');

					Console.WriteLine(GetTheLongestWord(individualWords));
				}
			}
		}

		private static string GetTheLongestWord(IEnumerable<string> individualWords)
		{
			return individualWords.OrderByDescending(s => s.Length).FirstOrDefault();
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

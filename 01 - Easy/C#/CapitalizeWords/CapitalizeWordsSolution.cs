using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.CapitalizeWords
{
	class CapitalizeWordsSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var lineOfFile in linesOfFile)
				{
					var individualWords = lineOfFile.Split(' ');

					Console.WriteLine(CapitalizeFirstLetters(individualWords));
				}
			}
		}

		private static string CapitalizeFirstLetters(IEnumerable<string> individualWords)
		{
			var individualWordsTitleCasesList = new List<string>();

			foreach (var individualWord in individualWords)
			{
				if (individualWord != String.Empty)
				{
					if (!Char.IsDigit(individualWord[0]))
					{
						individualWordsTitleCasesList.Add(FirstCharToUpper(individualWord));
					}
					else
					{
						individualWordsTitleCasesList.Add(individualWord);
					}
				}
		    }

			return String.Join(" ", individualWordsTitleCasesList);
		}

		public static string FirstCharToUpper(string input)
		{
			return input.First().ToString().ToUpper() + input.Substring(1);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.ReverseWords
{
	class ReverseWords
	{
		static void Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> listOfText = ReadFile(args[0]);

				foreach (var singleLine in listOfText)
				{
					if (singleLine != String.Empty)
					{
						var arrayOfWords = singleLine.Split(' ').Select(a => a).Where(a => a != String.Empty).ToArray();

						Array.Reverse(arrayOfWords);

						Console.WriteLine(String.Join(" ", arrayOfWords));	
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


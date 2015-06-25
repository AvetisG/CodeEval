using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.Lowercase
{
	class LowercaseSolution
	{
		static void Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfLowercaseableText = ReadFile(args[0]);
				
				foreach (var lineOfLowercaseableText in linesOfLowercaseableText)
				{
					Console.WriteLine(lineOfLowercaseableText.ToLower());	
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


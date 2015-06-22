using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.JugglingWithZeros
{
	class JugglingWithZerosSolution
	{
		static void Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesInAFile = ReadFile(args[0]);

				foreach (var singleLine in linesInAFile)
				{
					if (singleLine != String.Empty)
					{
						Console.WriteLine(Convert.ToInt64(ConvertToBinary(singleLine.Split(' ')), 2));
					}
				}
			}
		}

		private static string ConvertToBinary(string[] zeroBasedStrings)
		{
			var binaryString = new StringBuilder();
			var isFlag = true;

			for (int i=0; i<zeroBasedStrings.Length; i++)
			{
				if (!isFlag)
				{
					if (zeroBasedStrings[i - 1] == "00")
					{
						binaryString.Append(new String(Convert.ToChar("1"), zeroBasedStrings[i].Count()));	
					}
					else if (zeroBasedStrings[i - 1] == "0")
					{
						binaryString.Append(zeroBasedStrings[i]);
					}
				}

				isFlag = !isFlag;
			}

			return binaryString.ToString();
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.SelfDescribingNumbers
{
	internal class SelfDescribingNumbersSolution
	{
		private static void _Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
                IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var singleLine in linesOfFile)
				{
					Console.WriteLine(IsSelfDescribingNumber(singleLine));
				}
			}
		}

		private static int IsSelfDescribingNumber(string singleLine)
		{
			var individualDigits = singleLine.ToCharArray();

			for (int position = 0; position < individualDigits.Count(); position++)
			{
				int valueInPosition = (int) Char.GetNumericValue(individualDigits[position]);

                if (individualDigits.Count(a => (int)Char.GetNumericValue(a) == position) != valueInPosition)
				{
					return 0;
				}
			}
			return 1;
		}

		private static IEnumerable<string> ReadFile(string filePath)
		{
			string[] fileLines = {};

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

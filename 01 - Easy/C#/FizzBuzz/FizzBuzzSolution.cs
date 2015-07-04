using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.FizzBuzz
{
	class FizzBuzzSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> fizzBuzzInstructionLines = ReadFile(args[0]);

				foreach (var fizzBuzzInstructionLine in fizzBuzzInstructionLines)
				{
					if (fizzBuzzInstructionLine != String.Empty)
					{
						string[] fizzBuzzInstructionList = fizzBuzzInstructionLine.Split(' ').Select(a => a).Where(a => a != String.Empty).ToArray(); ;

						DoFizzBuzz(fizzBuzzInstructionList);
					}
				}
			}
		}

		private static void DoFizzBuzz(string[] argFizzBuzzInstructionList)
		{
			var FizzBuzzString = new List<string>();

			for (int i = 1; i <= Convert.ToInt16(argFizzBuzzInstructionList[2]); i++)
			{
				var fizzBuzzText = new StringBuilder();
				bool shouldFizz = i%Convert.ToInt16(argFizzBuzzInstructionList[0]) == 0;
				bool shouldBuzz = i%Convert.ToInt16(argFizzBuzzInstructionList[1]) == 0;

				if (shouldFizz) fizzBuzzText.Append("F");
				if (shouldBuzz) fizzBuzzText.Append("B");

				if (!shouldFizz && !shouldBuzz) fizzBuzzText.Append(i.ToString());

				FizzBuzzString.Add(fizzBuzzText.ToString());
			}

			Console.WriteLine(String.Join(" ", FizzBuzzString));
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


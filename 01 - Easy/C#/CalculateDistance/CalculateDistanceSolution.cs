using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.CalculateDistance
{
	class CalculateDistanceSolution
	{
		static void Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
                IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var singleLine in linesOfFile)
				{
				    var digits = singleLine.Split(' ');

                    Console.WriteLine(CalculateDistanceFrom(digits));
				}
			}
		}

	    private static int CalculateDistanceFrom(string[] digits)
	    {
	        return (int) Math.Sqrt(
                Math.Pow(Convert.ToInt32(digits[2].Replace("(", "").Replace(",", "")) - Convert.ToInt32(digits[0].Replace("(", "").Replace(",", "")), 2) +
                Math.Pow(Convert.ToInt32(digits[3].Replace(")", "")) - Convert.ToInt32(digits[1].Replace(")", "")), 2));
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

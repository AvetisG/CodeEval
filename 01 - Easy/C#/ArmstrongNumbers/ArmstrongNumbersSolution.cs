using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.ArmstrongNumbers
{
	class ArmstrongNumbersSolution
	{
		static void Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
                IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var singleLine in linesOfFile)
				{
                    Console.WriteLine(IsArmstrongNumber(singleLine.ToCharArray()));
				}
			}
		}

	    private static bool IsArmstrongNumber(char[] numbers)
	    {
	        var power = numbers.Length;

	        var sum = numbers.Aggregate(0.0, (current, number) => current + Math.Pow(char.GetNumericValue(number), power));

            if (String.Join("", numbers) == sum.ToString()) return true;

	        return false;
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

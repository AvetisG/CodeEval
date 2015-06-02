using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.AgeDistribution
{
	class AgeDistributionSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var age in linesOfFile)
				{
					if (age != String.Empty) Console.WriteLine(DetectAgeGroup(Convert.ToInt16(age)));
				}
			}
		}

		private static string DetectAgeGroup(int age)
		{
			if (age >= 0 && age <= 2)
			{
				return "Still in Mama's arms";
			}
			if (age == 3 || age == 4)
			{
				return "Preschool Maniac";
			}
			if (age >= 5 && age <= 11)
			{
				return "Elementary school";
			}
			if (age >= 12 && age <= 14)
			{
				return "Middle school";
			}
			if (age >= 15 && age <= 18)
			{
				return "High school";
			}
			if (age >= 19 && age <= 22)
			{
				return "College";
			}
			if (age >= 23 && age <= 65)
			{
				return "Working for the man";
			}
			if (age >= 66 && age <= 100)
			{
				return "The Golden Years";
			}
			if (age < 0 || age > 100)
			{
				return "This program is for humans";
			}
			return "";
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

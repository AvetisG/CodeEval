using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.WorkingExperience
{
	class WorkingExperienceSolution
	{
		private static readonly string[] _shortenedMonthNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;

		static void Main(string[] args)
		{
			//if (args[0] != String.Empty)
			{
				IEnumerable<string> linesInAFile = ReadFile("C:/Users/avo.ghukasyan/Documents/CodeEval/01 - Easy/C#/WorkingExperiance/file.txt");

				foreach (var singleLine in linesInAFile)
				{
					if (singleLine != String.Empty)
					{
						var experianceStartTimeline = singleLine.Split(';')
							.Select(a => new DateTime(
								Convert.ToInt32(a.TrimEnd().TrimStart().Split('-')[0].Split()[1]),
								Array.IndexOf(_shortenedMonthNames, a.TrimEnd().TrimStart().Split('-')[0].Split()[0]),
								DateTime.Now.Day)).OrderBy(a => a);

						var c = 9;

						var experianceEndTimeline = singleLine.Split(';')
							.Select(a => new DateTime(
								Convert.ToInt32(a.TrimEnd().TrimStart().Split('-')[1].Split()[1]),
								c = Array.IndexOf(_shortenedMonthNames, GetMonth(a)),
								DateTime.Now.Day)).OrderBy(a => a);

						Console.WriteLine(Math.Floor(experianceEndTimeline.Last().Subtract(experianceStartTimeline.First()).TotalDays/365));
					}
				}
			}
		}

		static string GetMonth(string var)
		{
			var a = var.TrimEnd().TrimStart().Split('-')[1].Split()[0];
			return a;
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

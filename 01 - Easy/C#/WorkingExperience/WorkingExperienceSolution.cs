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

		static void _Main(string[] args)
		{
			//if (args[0] != String.Empty)
			{
				IEnumerable<string> linesInAFile = ReadFile("C:/Users/avo.ghukasyan/Documents/CodeEval/01 - Easy/C#/WorkingExperience/file.txt");

				foreach (var singleLine in linesInAFile)
				{
					if (singleLine != String.Empty)
					{
						var experianceStartTimeline = singleLine.Split(';')
							.Select(a => MakeDateTime(
								Convert.ToInt32(a.TrimEnd().TrimStart().Split('-')[0].Split()[1]),
								Array.IndexOf(_shortenedMonthNames, a.TrimEnd().TrimStart().Split('-')[0].Split()[0]),
								1)).OrderBy(a => a);

						var experianceEndTimeline = singleLine.Split(';')
							.Select(a => MakeDateTime(
								Convert.ToInt32(a.TrimEnd().TrimStart().Split('-')[1].Split()[1]),
								Array.IndexOf(_shortenedMonthNames, a.TrimEnd().TrimStart().Split('-')[1].Split()[0]),
								1)).OrderBy(a => a);

						Console.WriteLine(Math.Floor(experianceEndTimeline.Last().Subtract(experianceStartTimeline.First()).TotalDays/365));
					}
				}
			}
		}

		private static DateTime MakeDateTime(int argToInt32, int argIndexOf, int argDay)
		{
			var a = new DateTime(argToInt32, (argIndexOf + 1), argDay);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.DeltaTime
{
	class DeltaTimeSolution
	{
		static void Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

				foreach (var singleLine in linesInAFile)
				{
				    var firstTime = singleLine.Split()[0].Split(':').Select(a => Convert.ToInt32(a)).ToArray();
                    var secondTime = singleLine.Split()[1].Split(':').Select(a => Convert.ToInt32(a)).ToArray();

                    Console.WriteLine(GetDifference(firstTime, secondTime));
				}
			}
		}

	    private static string GetDifference(int[] firstTime, int[] secondTime)
	    {
            TimeSpan timeDifference = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, firstTime[0], firstTime[1], firstTime[2])
                                        .Subtract(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, secondTime[0], secondTime[1], secondTime[2]));

            return String.Format("{0:D2}:{1:D2}:{2:D2}", Math.Abs(timeDifference.Hours), Math.Abs(timeDifference.Minutes), Math.Abs(timeDifference.Seconds));
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


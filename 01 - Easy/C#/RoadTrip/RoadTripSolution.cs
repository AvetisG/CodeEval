using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.RoadTrip
{
	class RoadTripSolution
	{
		static void _Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

				foreach (var singleLine in linesInAFile)
				{
					if (singleLine != String.Empty)
					{
					    var distances = singleLine.Replace(" ", "").Split(';')
                            .Select(a => a != String.Empty ? Convert.ToInt32(a.Split(',')[1]) : 0 )
                            .Where(a => a != 0);

                        Console.WriteLine(CalculateAndFormattedDistances(distances));
					}
				}
			}
		}

	    private static string CalculateAndFormattedDistances(IEnumerable<int> structuredData)
	    {
	        var orderedDistances = structuredData.OrderBy(a => a).ToList();
	        var calculatedAndFormattedDistances = new List<int>();

            for (int i = 0; i < orderedDistances.Count(); i++)
            {
                if (i == 0) calculatedAndFormattedDistances.Add(orderedDistances[i]);
                else calculatedAndFormattedDistances.Add(orderedDistances[i] - orderedDistances[i - 1]);
            }

            return String.Join(",", calculatedAndFormattedDistances);
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

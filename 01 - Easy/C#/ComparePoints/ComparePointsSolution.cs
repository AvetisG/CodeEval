using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.ComparePoints
{
	class ComparePointsSolution
	{
		static void _Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var lineOfFile in linesOfFile)
				{
                    Console.WriteLine(GetPointComparison(lineOfFile.Split().Select(a => Convert.ToInt32(a)).ToArray()));
				}
			}
		}

	    private static string GetPointComparison(int[] allPoints)
	    {
	        var o = allPoints[0];
            var p = allPoints[1];
            var q = allPoints[2];
            var r = allPoints[3];

            if (o == q)
            {
                if (p == r) return "here";
                if (p < r) return "N";
                if (p > r) return "S";
            }

            if (o < q)
            {
                if (p == r) return "E";
                if (p < r) return "NE";
                if (p > r) return "SE";
            }

            if (o > q)
            {
                if (p == r) return "W";
                if (p < r) return "NW";
                if (p > r) return "SW";
            }

	        return String.Empty;
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

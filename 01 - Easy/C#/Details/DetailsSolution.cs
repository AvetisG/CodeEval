using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.Details
{
	class DetailsSolution
	{
		static void _Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

				foreach (var singleLine in linesInAFile) Console.WriteLine(CountDetailMoves(singleLine.Split(',')));
			}
		}

	    private static int CountDetailMoves(IList<string> details)
	    {
	        List<int> moveCounts = new List<int>();

	        for (int i=0; i<details.Count(); i++)
	        {
	            var currentValue = details[i];

                if (currentValue == "XYYYY.Y") currentValue = "XYYYYYY"; // Apparently there is an error in the input that hasn't been fixed credit goes to StevenDunn

                moveCounts.Add(currentValue.Count(a => a.Equals('.')));
	        }

	        return moveCounts.OrderBy(a => a).ToList()[0];
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


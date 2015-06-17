using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.SetIntersection
{
    class SetIntersectionSolution
	{
		static void Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var singleLine in linesOfFile)
				{
                    Console.WriteLine(FindIntersection(singleLine.Split(';')[0].Split(','), singleLine.Split(';')[1].Split(',')));	
				}
			}
		}

        private static string FindIntersection(string[] firstArray, string[] secondArray)
        {
            List<int> setIntersections = new List<int>();
            
            for (int i=0; i<firstArray.Length; i++)
            {
                for (int j = 0; j < secondArray.Length; j++)
                {
                    if (i != j && firstArray[i].Equals(secondArray[j]))
                    {
                        setIntersections.Add(Convert.ToInt32(firstArray[i]));
                    }
                }
            }

            return String.Join(",", setIntersections.OrderBy(a => a));
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

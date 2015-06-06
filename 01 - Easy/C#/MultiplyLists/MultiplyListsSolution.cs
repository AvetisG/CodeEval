using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.MultiplyLists
{
	class MultiplyListsSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var singleLine in linesOfFile)
				{
					List<string> multipledList = new List<string>();
					string[] firstList = singleLine.Split('|')[0].Split(' ').Select(e => e).Where(e => e != String.Empty).ToArray();
					string[] secondList = singleLine.Split('|')[1].Split(' ').Select(e => e).Where(e => e != String.Empty).ToArray();

					for (int i=0; i<firstList.Count(); i++)
					{
						multipledList.Add((Convert.ToInt16(firstList[i])*Convert.ToInt16(secondList[i])).ToString());
					}

					Console.WriteLine(String.Join(" ", multipledList));
				}
			}
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

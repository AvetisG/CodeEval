using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.DecimalToBinary
{
	class DecimalToBinarySolution
	{
		static void Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesInAFile = ReadFile(args[0]);
				
				foreach (var singleLine in linesInAFile)
				{
					if (singleLine != String.Empty)
					{
						if (singleLine != String.Empty)
						{
							int givenNumber = int.Parse(singleLine);

							string remainder = "";

							if (givenNumber == 0)
							{
								remainder = "0";
							}
							else
							{
								while (givenNumber >= 1)
								{
									int quotient = givenNumber/2;
									remainder += (givenNumber%2).ToString();
									givenNumber = quotient;
								}	
							}
							

							string binaryRepresentation = "";

							for (int i = remainder.Length - 1; i >= 0; i--) binaryRepresentation = binaryRepresentation + remainder[i];

							Console.WriteLine(binaryRepresentation);
						}
					}
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

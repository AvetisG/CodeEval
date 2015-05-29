using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.WithoutRepititions
{
	class WithoutRepititionsSolution
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
						var sentence = singleLine.Split(' ');

						Console.WriteLine(ReturnSentenceWithNoRepetitions(sentence));
					}
				}
			}
		}

		private static string ReturnSentenceWithNoRepetitions(IEnumerable<string> argSentence)
		{
			var noRepetitions = (from sequence in argSentence where sequence != String.Empty select StripRepeatingLettersInSequence(sequence)).ToList();

			return String.Join(" ", noRepetitions);
		}

		private static string StripRepeatingLettersInSequence(string argSequence)
		{	
			var sequenceCharArray = argSequence.ToCharArray();
		    var cleanString = new StringBuilder();

			for (int i = 0; i < sequenceCharArray.Length; i++)
			{
			    if (i == 0)
			    {
                    cleanString.Append(sequenceCharArray[i]);
			    }
                else if (sequenceCharArray[i-1] != sequenceCharArray[i])
                {
                    cleanString.Append(sequenceCharArray[i]);
                }
			}

            return cleanString.ToString();
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

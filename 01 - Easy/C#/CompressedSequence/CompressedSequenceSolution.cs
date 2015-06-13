using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.CompressedSequence
{
	class CompressedSequenceSolution
	{
		static void Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var lineOfFile in linesOfFile)
				{
					var individualSequence = lineOfFile.Split(' ');

                    Console.WriteLine(CompressedThisSequence(individualSequence));
				}
			}
		}

	    private static string CompressedThisSequence(string[] individualSequence)
	    {
	        List<int> compressedSequence = new List<int>();

	        int count = 1;
	        int sequenceIndex = 0;

            for (int i=0; i<individualSequence.Length; i++)
	        {
                if (sequenceIndex != i && individualSequence[sequenceIndex].Equals(individualSequence[i]))
                {
                    count++;
                }
                else if (!individualSequence[sequenceIndex].Equals(individualSequence[i]))
                {
                    compressedSequence.Add(count);
                    compressedSequence.Add(Convert.ToInt32(individualSequence[sequenceIndex]));

                    count = 1;
                    sequenceIndex = i;
                }
	        }

            compressedSequence.Add(count);
            compressedSequence.Add(Convert.ToInt32(individualSequence[sequenceIndex]));

	        return String.Join(" ", compressedSequence);
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

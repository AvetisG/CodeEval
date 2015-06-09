using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.SlangFlavor
{
	class SlangFlavorSolution
	{
		static void Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
                bool skipPunctuation = true;
                int slangListindex = 0;

                List<string> slangList = new List<string>();
				slangList.Add(", yeah!");
				slangList.Add(", this is crazy, I tell ya.");
				slangList.Add(", can U believe this?");
				slangList.Add(", eh?");
				slangList.Add(", aw yea.");
				slangList.Add(", yo.");
				slangList.Add("? No way!");
				slangList.Add(". Awesome!");

                IEnumerable<string> listOfText = ReadFile(args[0]);

				foreach (var singleLine in listOfText)
				{
				    var words = singleLine.Split(' ');
				    var slangSentence = new List<string>();

				    foreach (var word in words)
				    {
                        if (FoundEndPunctuation(word) && !skipPunctuation)
                        {
                            slangSentence.Add(word.Substring(0, word.Length - 1) + slangList[slangListindex]);

                            slangListindex = slangListindex == 7 ?  0 : slangListindex + 1;
                        }
				        else
				        {
				            slangSentence.Add(word);
				        }

				        if (FoundEndPunctuation(word)) skipPunctuation = !skipPunctuation;
				    }

				    Console.WriteLine(String.Join(" ", slangSentence));
				}
			}
		}

	    static bool FoundEndPunctuation(string word)
	    {
	        return (word.Contains(".") || word.Contains("!") || word.Contains("?"));
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


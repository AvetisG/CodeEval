using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.BeautifulStrings
{
	class BeautifulStringsSolution
	{
		static void Main(string[] args)
		{
            //if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile("C:/Users/ghukasyana/Documents/CodeEval/01 - Easy/C#/BeautifulStrings/file.txt");

				foreach (var lineOfFile in linesOfFile)
				{
					Console.WriteLine(GetStringBeauty((lineOfFile.ToLower()).ToCharArray()));
				}
			}
		}

	    private static string GetStringBeauty(char[] characterCollection)
	    {
	        int beautifulStringValue = 0;

            Dictionary<int, char> characterOccurance = new Dictionary<int, char>();

            foreach (var character in characterCollection)
	        {
                if (!characterOccurance.ContainsKey(characterCollection.Count(a => a == character)))
	            {
                    characterOccurance.Add(characterCollection.Count(a => a == character), character);
	            }
	        }

            IOrderedEnumerable<KeyValuePair<int, char>> orderedCharacterOccurance = characterOccurance.OrderByDescending(a => a.Key);
	        int num = 26;

            foreach (var orderedCharacter in orderedCharacterOccurance)
	        {
                beautifulStringValue = beautifulStringValue + (num * orderedCharacter.Key);

	            num = num - 1;
	        }

	        return "" + beautifulStringValue;
	    }

	    public static string FirstCharToUpper(string input)
		{
			return input.First().ToString().ToUpper() + input.Substring(1);
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

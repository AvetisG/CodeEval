using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.BeautifulStrings
{
	class BeautifulStringsSolution
	{
		static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var lineOfFile in linesOfFile)
				{
					Console.WriteLine(GetStringBeauty((lineOfFile.ToLower()).ToCharArray()));
				}
			}
		}

		private static string GetStringBeauty(char[] characterCollection)
		{
			int beautifulStringValue = 0;

			Dictionary<char, int> characterOccurance = new Dictionary<char, int>();

			foreach (var character in characterCollection)
			{
				if (character != ' ' && Char.IsLetter(character))
				{
					if (!characterOccurance.ContainsKey(character))
					{
						characterOccurance.Add(character, characterCollection.Count(a => a == character));
					}
				}
			}

			IOrderedEnumerable<KeyValuePair<char, int>> orderedCharacterOccurance = characterOccurance.OrderByDescending(a => a.Value);
			int num = 26;

			foreach (var orderedCharacter in orderedCharacterOccurance)
			{
				beautifulStringValue = beautifulStringValue + (num * orderedCharacter.Value);

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

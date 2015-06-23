using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.MorseCode
{
	class MorseCodeSolution
	{
        private static readonly Dictionary<string, string> _morseCodeDictionary = new Dictionary<string, string>()
        {
            {".-", "A"},
            {"-...", "B"},
            {"-.-.", "C"},
            {"-..", "D"},
            {".", "E"},
            {"..-.", "F"},
            {"--.", "G"},
            {"....", "H"},
            {"..", "I"},
            {".---", "J"},
            {"-.-", "K"},
            {".-..", "L"},
            {"--", "M"},
            {"-.", "N"},
            {"---", "O"},
            {".--.", "P"},
            {"--.-", "Q"},
            {".-.", "R"},
            {"...", "S"},
            {"-", "T"},
            {"..-", "U"},
            {"...-", "V"},
            {".--", "W"},
            {"-..-", "X"},
            {"-.--", "Y"},
            {"--..", "Z"},
            {".----", "1"},
            {"..---", "2"},
            {"...--", "3"},
            {"....-", "4"},
            {".....", "5"},
            {"-....", "6"},
            {"--...", "7"},
            {"---..", "8"},
            {"----.", "9"},
            {"-----", "0"},
            {"..--..", "?"},
            {"-..-.", "/"},
            {".-.-.-", "."},
            {"--..--", ","},
            {".--.-.", "@"},
        }; 

		static void _Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
                IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var singleLine in linesOfFile)
				{
				    var words = singleLine.Split(' ');
					Console.WriteLine(ConvertFromMorseCode(words));
				}
			}
		}

	    private static string ConvertFromMorseCode(IEnumerable<string> words)
	    {
	        var convertedString = new StringBuilder();

            foreach (var word in words)
            {
                convertedString.Append(word.Equals("")
                    ? " "
                    : _morseCodeDictionary.FirstOrDefault(a => a.Key == word).Value);
            }

	        return convertedString.ToString();
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

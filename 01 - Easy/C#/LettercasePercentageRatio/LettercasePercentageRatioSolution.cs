using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.LettercasePercentageRatio
{
	class LettercasePercentageRatioSolution
	{
		static void Main(string[] args)
		{
            if (args[0] != String.Empty)
			{
                IEnumerable<string> linesOfFile = ReadFile(args[0]);

				foreach (var singleLine in linesOfFile)
				{
                    PercentageRatios percentageRatios = GetPercentageRatios(singleLine.ToCharArray());

                    Console.WriteLine("lowercase: {0} uppercase: {1}",
                        FormatNumberForDisplay(percentageRatios.LowercasePercentage),
                        FormatNumberForDisplay(percentageRatios.UppercasePercentage));
				}
			}
		}

	    private static string FormatNumberForDisplay(double number)
	    {
	        if (!number.ToString().Contains(".")) return String.Format("{0}.00", number);
	        return number.ToString();
	    }

	    private static PercentageRatios GetPercentageRatios(char[] letters)
	    {
	        PercentageRatios calculatedPercentageRatios = new PercentageRatios();

            double lowerCaseAmount = 0;
            double upperCaseAmount = 0;

            foreach (var letter in letters)
            {
                if (char.IsUpper(letter)) upperCaseAmount++; 
                else lowerCaseAmount++;
            }

	        calculatedPercentageRatios.LowercasePercentage = Math.Round((lowerCaseAmount / letters.Length) * 100, 2);
	        calculatedPercentageRatios.UppercasePercentage = Math.Round((upperCaseAmount / letters.Length) * 100, 2);

	        return calculatedPercentageRatios;
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

    class PercentageRatios
    {
        public double LowercasePercentage { get; set; }
        public double UppercasePercentage { get; set; }
    }
}

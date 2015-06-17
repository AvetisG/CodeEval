using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.StringMask
{
    class StringMaskSolution
    {
        private static void Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
					Console.WriteLine(UnmaskTheString(singleLine.Split(' ')[0], singleLine.Split(' ')[1]));
                }
            }
        }

	    private static string UnmaskTheString(string maskedWord, string binary)
	    {
		    var binaryArray = binary.ToCharArray();
		    var unmaskedString = new StringBuilder();

			for (int i = 0; i < binaryArray.Length; i++)
		    {
				if (((int)Char.GetNumericValue(binaryArray[i])) == 1)
			    {
					unmaskedString.Append(maskedWord[i].ToString().ToUpper());
			    }
			    else
			    {
					unmaskedString.Append(maskedWord[i]);
			    }
		    }

		    return unmaskedString.ToString();
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

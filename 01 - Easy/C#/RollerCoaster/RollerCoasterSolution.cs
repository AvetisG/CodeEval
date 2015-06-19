using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.RollerCoaster
{
    class RollerCoasterSolution
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
						Console.WriteLine(GetRollerCoasterText(singleLine.ToCharArray()));
                    }
                }
            }
        }

	    private static string GetRollerCoasterText(char[] argSingleLine)
	    {
		    bool upperCaseIt = true;
		    var rollerCoasterText = new StringBuilder();

			foreach (var letter in argSingleLine)
		    {
			    if (upperCaseIt && Char.IsLetter(letter))
			    {
				    rollerCoasterText.Append(letter.ToString().ToUpper());
				    upperCaseIt = false;
			    }
				else if (!upperCaseIt && Char.IsLetter(letter))
			    {
				    rollerCoasterText.Append(letter.ToString().ToLower());
				    upperCaseIt = true;
			    }
			    else
			    {
					rollerCoasterText.Append(letter);
			    }
		    }

		    return rollerCoasterText.ToString();
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

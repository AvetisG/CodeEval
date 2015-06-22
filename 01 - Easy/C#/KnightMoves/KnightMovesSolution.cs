using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.KnightMoves
{
	class KnightMovesSolution
	{
	    private const string _chessBoardC = "abcdefgh";
	    private const string _chessBoardN = "12345678";

	    private static void _Main(string[] args)
	    {
            if (args[0] != String.Empty)
	        {
                IEnumerable<string> linesOfFile = ReadFile(args[0]);

	            foreach (var lineOfFile in linesOfFile)
	            {
                    Console.WriteLine(PrintKnightMovePossibilities(lineOfFile.ToCharArray()));
	            }
	        }
	    }

	    private static string PrintKnightMovePossibilities(char[] knightPosition)
	    {
	        List<string> allPossibilities = new List<string>();

	        var cPositionPossibilities = new char[4];
            var nPositionPossibilities = new char[4];

	        var cPosition = _chessBoardC.IndexOf(knightPosition[0]);
            var nPosition = _chessBoardN.IndexOf(knightPosition[1]);

	        if (cPosition - 2 >= 0) cPositionPossibilities[0] = _chessBoardC[cPosition - 2];
            if (cPosition - 1 >= 0) cPositionPossibilities[1] = _chessBoardC[cPosition - 1];
            if (cPosition + 1 <= _chessBoardC.Length - 1) cPositionPossibilities[2] = _chessBoardC[cPosition + 1];
            if (cPosition + 2 <= _chessBoardC.Length - 1) cPositionPossibilities[3] = _chessBoardC[cPosition + 2];

            if (nPosition - 2 >= 0) nPositionPossibilities[0] = _chessBoardN[nPosition - 2];
            if (nPosition - 1 >= 0) nPositionPossibilities[1] = _chessBoardN[nPosition - 1];
            if (nPosition + 1 <= _chessBoardC.Length - 1) nPositionPossibilities[2] = _chessBoardN[nPosition + 1];
            if (nPosition + 2 <= _chessBoardC.Length - 1) nPositionPossibilities[3] = _chessBoardN[nPosition + 2];

            allPossibilities.Add((cPositionPossibilities[1] + "" +  nPositionPossibilities[0]));
            allPossibilities.Add((cPositionPossibilities[1] + "" + nPositionPossibilities[3]));
            allPossibilities.Add((cPositionPossibilities[2] + "" + nPositionPossibilities[0]));
            allPossibilities.Add((cPositionPossibilities[2] + "" + nPositionPossibilities[3]));

            allPossibilities.Add((cPositionPossibilities[0] + "" + nPositionPossibilities[1]));
            allPossibilities.Add((cPositionPossibilities[0] + "" + nPositionPossibilities[2]));
            allPossibilities.Add((cPositionPossibilities[3] + "" + nPositionPossibilities[1]));
            allPossibilities.Add((cPositionPossibilities[3] + "" + nPositionPossibilities[2]));

	        return String.Join(" ", allPossibilities.Select(a => a).Where(a => !a.Contains('\0')).OrderBy(a => a));
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

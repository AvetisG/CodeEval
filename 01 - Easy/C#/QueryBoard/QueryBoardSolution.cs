using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.QueryBoard
{
    class QueryBoardSolution
    {
        private static readonly int[,] _queryBoard = new int[256, 256];

        static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    var command = singleLine.Split(' ')[0];
                    var argument1 = singleLine.Split(' ')[1];
                    var argument2 = singleLine.Split(' ').Length == 3 ? singleLine.Split(' ')[2] : "";

                    if (command == "SetRow") setRow(Convert.ToInt32(argument1), Convert.ToInt32(argument2));
                    if (command == "SetCol") setCol(Convert.ToInt32(argument1), Convert.ToInt32(argument2));
                    if (command == "QueryRow") Console.WriteLine(queryRow(Convert.ToInt32(argument1)));
                    if (command == "QueryCol") Console.WriteLine(queryCol(Convert.ToInt32(argument1)));
                }
            }
        }

        private static void setRow(int row, int value)
        {
            for (int i = 0; i < 256; i++)
            {
                _queryBoard[row, i] = value;
            }
        }

        private static void setCol(int col, int value)
        {
            for (int i = 0; i < 256; i++)
            {
                _queryBoard[i, col] = value;
            }
        }

        private static int queryRow(int row)
        {
            int sum = 0;

            for (int i = 0; i < 256; i++)
            {
                sum = sum + _queryBoard[row, i];
            }

            return sum;
        }

        private static int queryCol(int col)
        {
            int sum = 0;

            for (int i = 0; i < 256; i++)
            {
                sum = sum + _queryBoard[i, col];
            }

            return sum;
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

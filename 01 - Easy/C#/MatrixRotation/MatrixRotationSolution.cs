using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.MatrixRotation
{
    class MatrixRotationSolution
    {
        static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    if (singleLine != String.Empty)
                    {
                        Console.WriteLine(singleLine.Length == 1 ? singleLine : SerializeArray(CreateMatrix(singleLine)));
                    }
                }
            }
        }

        private static string[,] CreateMatrix(string singleLine)
        {
            var array = singleLine.Split(' ');
            var width = Math.Sqrt(array.Length);
            var height = Math.Sqrt(array.Length);

            var counter = 0;
            var matrix = new string[(int)width, (int)height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = array[counter];
                    counter++;
                }
            }

            return RotateMatrix(matrix, (int)width);
        }

        private static string SerializeArray(string[,] strings)
        {
            var serialized = new List<string>();
            
            for (int i = 0; i < strings.GetLength(0); i++)
            {
                for (int j = 0; j < strings.GetLength(0); j++)
                {
                    serialized.Add(strings[i, j]);
                } 
            }

            return String.Join(" ", serialized);
        }

        public static string[,] RotateMatrix(string[,] matrix, int n)
        {
            string[,] ret = new string[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[i, j] = matrix[n - j - 1, i];
                }
            }

            return ret;
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


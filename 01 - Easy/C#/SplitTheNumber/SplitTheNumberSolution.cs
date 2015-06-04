using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEvalSolutions.SplitTheNumber
{
    class SplitTheNumberSolution
    {
        private static void _Main(string[] args)
        {
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                foreach (var singleLine in linesInAFile)
                {
                    var parameters = singleLine.Split(' ');
                    var numbers = parameters[0];
                    var equationSide1 = parameters[1].Contains("+") ? parameters[1].Split('+')[0] : parameters[1].Split('-')[0];
                    var equationSide2 = parameters[1].Contains("+") ? parameters[1].Split('+')[1] : parameters[1].Split('-')[1];
                    var operation = parameters[1].Contains("+") ? "+" : "-";

                    Console.WriteLine(RunEquation(numbers, equationSide1, equationSide2, operation));
                }
            }
        }

        private static double RunEquation(string numbers, string equationSide1, string equationSide2, string operation)
        {
            var firstSide = new StringBuilder();

            for (int i = 0; i < equationSide1.Length; i++)
            {
                firstSide.Append(numbers[i]);
            }

            var secondSide = new StringBuilder();

            for (int i = equationSide1.Length; i < equationSide1.Length + equationSide2.Length; i++)
            {
                secondSide.Append(numbers[i]);
            }

            return operation == "+"
                ? Convert.ToDouble(firstSide.ToString()) + Convert.ToDouble(secondSide.ToString())
                : Convert.ToDouble(firstSide.ToString()) - Convert.ToDouble(secondSide.ToString());
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

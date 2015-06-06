using System;

namespace CodeEvalSolutions.MultiplicationTable
{
    class MultiplicationTableSolution
    {
        static void Main(string[] args)
        {
            string[,] multiplicationTable = new string[12, 12];
            
            for (int i = 12; i > 0; i--)
            {
                for (int j = 12; j > 0; j--)
                {
                    int result = (i*j);

                    multiplicationTable[j - 1, i - 1] = GetFormattedResult(result);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(SmartTrimBeginning(multiplicationTable[i, j]));
                    }
                    else if (j == 11)
                    {
                        Console.Write(multiplicationTable[i, j].TrimEnd());
                    }
                    else
                    {
                        Console.Write(multiplicationTable[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        private static string GetFormattedResult(int result)
        {
            var amountOfSpaces = "".PadRight(4 - result.ToString().Length);
            return amountOfSpaces + result;
        }

        private static string SmartTrimBeginning(string untrimmedString)
        {
            var trimmedString = untrimmedString.TrimStart();

            if (trimmedString.Length == 1) return "".PadRight(1) + trimmedString;
            if (trimmedString.Length == 2) return trimmedString;

            return trimmedString;
        }
    }
}

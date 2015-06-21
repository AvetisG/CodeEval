using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.RacingChars
{
    class RacingCharsSolution
    {
        static void Main(string[] args)
        {
            //if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile("C:/Users/ghukasyana/Documents/CodeEval/01 - Easy/C#/RacingChars/file.txt");

                var checkpointsPassedMap = PassCheckPoints(linesInAFile.ToList());

                PrintMap(checkpointsPassedMap);
            }
        }

        private static void PrintMap(IEnumerable<string> checkpointsPassedMap)
        {
            foreach (var lineInMap in checkpointsPassedMap)
            {
                Console.WriteLine(lineInMap);
            }
        }

        private static IEnumerable<string> PassCheckPoints(List<string> linesInAFile)
        {
            List<string> checkpointsPassedMap = new List<string>();

            for (int i=0; i<linesInAFile.Count(); i++)
            {
                var firstPath = linesInAFile[i];
                var secondPath = linesInAFile[i+1];

                var enteryPointFirstPath = firstPath.IndexOf('_');

                var enteryPointSecondPath = secondPath.IndexOf('_');
                var checkPointSecondPath = secondPath.IndexOf('C');

                                                                                     
            }

            return checkpointsPassedMap;
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

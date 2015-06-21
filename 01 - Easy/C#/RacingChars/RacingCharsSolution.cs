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
            if (args[0] != String.Empty)
            {
                IEnumerable<string> linesInAFile = ReadFile(args[0]);

                var checkpointsPassedMap = GetThroughMap(linesInAFile.ToList());

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

        private static IEnumerable<string> GetThroughMap(List<string> linesInAFile)
        {
            List<string> checkpointsPassedMap = new List<string>();

            for (int i=0; i<linesInAFile.Count(); i++)
            {
                if (i==0)
                {
                    checkpointsPassedMap.Add(linesInAFile[i].Replace(linesInAFile[i].IndexOf('C') == -1 ? "_" : "C", "|"));
                }
                else
                {
                    GetThroughCheckPoint(linesInAFile, i, checkpointsPassedMap);
                }                                                                        
            }

            return checkpointsPassedMap;
        }

        private static void GetThroughCheckPoint(List<string> linesInAFile, int index, List<string> checkpointsPassedMap)
        {
            var previousPath = linesInAFile[index - 1];
            var currentPath = linesInAFile[index];

            var entryPointFrom = previousPath.IndexOf('C') == -1 ? previousPath.IndexOf('_') : previousPath.IndexOf('C');
            var entryPointTo = currentPath.IndexOf('C') == -1 ? currentPath.IndexOf('_') : currentPath.IndexOf('C');

            if (entryPointFrom == entryPointTo)
            {
                checkpointsPassedMap.Add(currentPath.Replace(currentPath.IndexOf('C') == -1 ? "_" : "C", "|"));
            }
            else if (entryPointFrom > entryPointTo)
            {
                checkpointsPassedMap.Add(currentPath.Replace(currentPath.IndexOf('C') == -1 ? "_" : "C", "/"));
            }
            else if (entryPointFrom < entryPointTo)
            {
                checkpointsPassedMap.Add(currentPath.Replace(currentPath.IndexOf('C') == -1 ? "_" : "C", "\\"));
            }
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

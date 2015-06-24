using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalSolutions.NiceAngles
{
    class NiceAnglesSolution
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
                        var d = (int) Convert.ToDouble(singleLine);
                        var m = (int) ((Convert.ToDouble(singleLine) - d) * 60);
                        var s = (int) ((Convert.ToDouble(singleLine) - d - ((double) m/60)) * 3600);

                        Console.WriteLine("{0}.{1}'{2}\"", 
                            d,
                            m.ToString().Length == 1 ? string.Format("0{0}", m) : m.ToString(), 
                            s.ToString().Length == 1 ? string.Format("0{0}", s) : s.ToString());
                    }
                }
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

using System;
using System.IO;

namespace CodeEvalSolutions.FileSize
{
	class FileSizeSolution
	{
		private static void _Main(string[] args)
		{
			if (args[0] != String.Empty)
			{
				FileInfo fileInfo = new FileInfo(args[0]);
				Console.WriteLine(fileInfo.Length);
			}
		}
	}
}

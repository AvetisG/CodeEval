using System;

namespace CodeEvalSolutions.OddNumbers
{
	class OddNumbersSolution
	{
		static void _Main(string[] args)
		{
			for (int i = 1; i <= 99; i++)
			{
				if (i % 2 != 0)
				{
					Console.WriteLine(i);
				}
			}
		}
	}
}


using System;

namespace CodeEvalSolutions.SumOfPrimes
{
	class SumOfPrimesSolution
	{
		static void _Main(string[] args)
		{
			int currentNumber = 2;
			int index = 0;
			long total = 0;

			while (index < 1000)
			{
				if (IsPrime(currentNumber))
				{
					total += currentNumber;
					index++;
				}
				currentNumber++;
			}

			Console.Write(total);
		}

		private static bool IsPrime(int number)
		{
			for (int i = 2; i <= number / 2; i++)
			{
				if (number % i == 0) return false;

			}
			return true;
		}
	}


}

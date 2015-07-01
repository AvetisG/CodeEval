using System;

namespace CodeEvalSolutions.PrimePalindrome
{
	class PrimePalindromeSolution
	{
		static void _Main(string[] args)
		{
			bool shouldStop = false;
			int counter = 1000;

			while (!shouldStop)
			{
				if (IsPrime(counter) && IsPalindrome(counter))
				{
					Console.WriteLine(counter);
					shouldStop = true;
				}
				counter--;
			}
		}

		static bool IsPalindrome(int number)
		{
			if (number.ToString().Length < 2) return false;

			char[] numberToCharArray1 = number.ToString().ToCharArray();
			char[] numberToCharArray2 = number.ToString().ToCharArray();

			Array.Reverse(numberToCharArray2);

			for (int i = 0; i < numberToCharArray1.Length; i++)
			{
				if (numberToCharArray1[i] != numberToCharArray2[i])
				{
					return false;
				}
			}

			return true;
		}

		public static bool IsPrime(int number)
		{
			double boundary = Math.Floor(Math.Sqrt(number));

			if (number == 1) return false;
			if (number == 2) return true;

			for (int i = 2; i <= boundary; ++i)
			{
				if (number % i == 0) return false;
			}

			return true;
		}

	}
}

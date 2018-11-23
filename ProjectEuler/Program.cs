using System;
using System.Diagnostics;

namespace ProjectEuler
{
	class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				Problem121(); ;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			finally
			{
				Console.ReadLine();
			}
		}

		public static long ArrangedProbability()
		{
			long b = 15;
			long n = 21;
			long target = 1000000000000;

			while (n < target)
			{
				long btemp = 3 * b + 2 * n - 2;
				long ntemp = 4 * b + 3 * n - 3;

				b = btemp;
				n = ntemp;
			}

			return b;
		}

		public static void Problem121()
		{
			Stopwatch clock = Stopwatch.StartNew();

			int limit = 15;
			long[] outcomes = new long[limit + 1];
			outcomes[limit] = 1;
			outcomes[limit - 1] = 1;

			for (int i = 2; i <= limit; i++)
			{
				for (int j = 0; j < outcomes.Length - 1; j++)
				{
					outcomes[j] = outcomes[j + 1];
				}
				outcomes[limit] = 0;

				for (int j = outcomes.Length - 1; j > 0; j--)
				{
					outcomes[j] += outcomes[j - 1] * i;
				}
			}

			long positive = 0;
			for (int i = 0; i < limit / 2 + 1; i++)
			{
				positive += outcomes[i];
			}

			long total = 1;
			for (int i = 2; i < limit + 2; i++)
			{
				total *= i;
			}


			clock.Stop();
			Console.WriteLine("There are {0} positive outcomes out of {1}", positive, total);
			Console.WriteLine("This gives a prize allocation of {0}", total / positive);
			Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
		}
	}
}

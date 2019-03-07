using System;
using System.Collections.Generic;
using System.Diagnostics;
using ProjectEuler.Utilities;

namespace ProjectEuler
{
	class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				Problem144();
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

		private static void PermutedMultiples()
		{
			Stopwatch clock = Stopwatch.StartNew();
			long result = 0;
			var isPermutedMultiple = false;
			long start = 1;

			while (!isPermutedMultiple)
			{
				start *= 10;
				for (long i = start; i < start * 10 / 6; i++)
				{
					isPermutedMultiple = true;
					for (int j = 6; j > 1; j--)
					{
						if (!Helpers.IsPermutation(i, i * j))
						{
							isPermutedMultiple = false;
							break;
						}
					}

					if (isPermutedMultiple)
					{
						result = i;
						break;
					}
				}
			}

			Console.WriteLine("Smallest positive permuted multiple: {0}", result);
			Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
		}

		private static void PrimeDigitReplacements()
		{
			Stopwatch clock = Stopwatch.StartNew();
			//  Get all primes between 56004 and 1000000
			var testList = new List<string>();

			// foreach, create mask based on replacing up to n - 1 digits,
			// where n is the number of digits in the prime

			for (int i = 56009; i < 1000000; i++)
			{
				if (Helpers.IsPrime(i))
				{
					var prime = i.ToString();

					var maskTemplates = CreateMaskTemplates(prime.Length);
					foreach (var template in maskTemplates)
					{
						var maskIndexes = digitArr2(template);
						foreach (var index in maskIndexes)
						{
							var mask = ReplaceAt(prime, index, '.', 1);
							testList.Add(mask);
						}
					}
				}
			}

			testList.Sort();

			var temp = testList[0];
			var count = 0;
			for (int i = 1; i < testList.Count; i++)
			{
				count++;
				if (count == 8)
				{
					break;
				}

				if (testList[i] != temp)
				{
					count = 0;
				}

				temp = testList[i];
			}

			int result = 0;

			for (int i = 0; i < 10; i++)
			{
				var candidate = int.Parse(temp.Replace(".", i.ToString()));
				if (Helpers.IsPrime(candidate))
				{
					result = candidate;
					break;
				}
			}

			clock.Stop();
			Console.WriteLine("Smallest prime digit replacement octet: {0}", result);
			Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
		}

		private static List<int> CreateMaskTemplates(int length)
		{
			var permBase = "";
			for (int i = 1; i <= length; i++)
			{
				permBase += i.ToString();
			}

			var perms = Helpers.GetPermutations(permBase);
			perms.Sort();

			var subList = new List<int>();
			foreach (var perm in perms)
			{
				for (int i = 1; i < perm.Length; i++)
				{
					var temp = int.Parse(perm.Substring(0, i));
					if (!subList.Contains(temp))
					{
						subList.Add(temp);
					}
				}
			}

			subList.Sort();
			return subList;
		}

		private static string ReplaceAt(string value, int startIndex, char maskChar, int count)
		{
			var temp = value.ToCharArray();
			for (int i = startIndex; i <= count; i++)
			{
				temp[i] = maskChar;
			}

			return temp.ToString();
		}

		public static int numDigits(int n)
		{
			if (n < 0)
			{
				n = (n == Int32.MinValue) ? Int32.MaxValue : -n;
			}
			if (n < 10) return 1;
			if (n < 100) return 2;
			if (n < 1000) return 3;
			if (n < 10000) return 4;
			if (n < 100000) return 5;
			if (n < 1000000) return 6;
			if (n < 10000000) return 7;
			if (n < 100000000) return 8;
			if (n < 1000000000) return 9;
			return 10;
		}

		public static int[] digitArr2(int n)
		{
			var result = new int[numDigits(n)];
			for (int i = result.Length - 1; i >= 0; i--)
			{
				result[i] = n % 10;
				n /= 10;
			}
			return result;
		}

		private static string CreateMask(string num, int index, char maskChar)
		{
			int[] arr = new int[10];

			var maskedDigit = "";
			for (int i = 0; i < 10; i++)
			{
				if (arr[i] == 2)
				{
					maskedDigit = (maskedDigit == "") ? i.ToString() : "";
				}
			}

			var mask = (maskedDigit == "") ? "" : num.ToString().Replace(maskedDigit, ".");

			return mask;
		}


		{
			Stopwatch clock = Stopwatch.StartNew();

			int result = 0;

			double xA = 0.0;
			double yA = 10.1;

			double xO = 1.4;
			double yO = -9.6;

			while (xO > 0.01 || xO < -0.01 || yO < 0)
			{

				//Calculate the slope of A
				double slopeA = (yO - yA) / (xO - xA);

				//Calculate the slope of the ellipse tangent
				double slopeO = -4 * xO / yO;

				//Calculate the slope of B
				double tanA = (slopeA - slopeO) / (1 + slopeA * slopeO);
				double slopeB = (slopeO - tanA) / (1 + tanA * slopeO);

				//calculate intercept of line B
				double interceptB = yO - slopeB * xO;

				//solve the quadratic equation for finding
				// the intersection of B and the ellipse
				// a*x^2 + b*x + c = 0
				double a = 4 + slopeB * slopeB;
				double b = 2 * slopeB * interceptB;
				double c = interceptB * interceptB - 100;

				double ans1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
				double ans2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

				xA = xO;
				yA = yO;

				//Take the solution which is furtherst from x0
				xO = (Math.Abs(ans1 - xO) > Math.Abs(ans2 - xO)) ? ans1 : ans2;
				yO = slopeB * xO + interceptB;

				result++;
			}

			clock.Stop();
			Console.WriteLine("The beam will reflect {0} times", result);
			Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
		}
	}
}

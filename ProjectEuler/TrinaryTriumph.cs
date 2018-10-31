using System;
using ProjectEuler.Utilities;

namespace ProjectEuler
{
	internal static class TrinaryTriumph
	{
		/// <summary>
		/// Problem 1
		/// </summary>
		/// <returns></returns>
		internal static int MultiplesOf3And5()
		{
			var result = 0;

			for (int i = 1; i < 1000; i++)
			{
				if ((i % 3) == 0 || (i % 5) == 0)
				{
					result += i;
				}
			}

			return result;
		}

		/// <summary>
		/// Problem 3
		/// </summary>
		/// <returns></returns>
		internal static long LargestPrimeFactor(long num)
		{
			var factors = Helpers.PrimeFactors(num);

			factors.Sort();
			return factors[factors.Count - 1];
		}

		/// <summary>
		/// Problem 9
		/// </summary>
		/// <param name="maxSum"></param>
		/// <returns></returns>
		internal static long SpecialPythagoreanTriplet(int maxSum)
		{
			var result = 0;

			// For integers m and n, where m > n, either (but NOT both) m or n is odd, and both are positive:
			// a = (m^2 - n^2)
			// b = 2mn
			// c = (m^2 ^ n^2)

			double m;
			double n;
			int a = 0;
			int b = 0;
			int c = 0;
			int total = 0;
			bool matchFound = false;

			m = 2;
			while (!matchFound)
			{
				n = 1;
				while (n < m)
				{

					a = (int)(Math.Pow(m, 2) - Math.Pow(n, 2));
					b = (int)(2 * m * n);
					c = (int)(Math.Pow(m, 2) + Math.Pow(n, 2));

					total = (a + b + c);

					if (total == maxSum)
					{
						int multiplier = maxSum / total;
						result = multiplier * a * b * c;
						matchFound = true;

						break;
					}

					n++;
				}

				if (matchFound)
				{
					break;
				}

				m++;
			}

			return result;
		}

		/// <summary>
		/// Problem 27
		/// </summary>
		/// <param name="maxCoefficient"></param>
		/// <returns></returns>
		internal static long QuadraticPrimes(int maxCoefficient)
		{
			long aMax = 0;
			long bMax = 0;
			long nMax = 0;
			long[] bPos = Helpers.ESieve(maxCoefficient);

			for (int a = -999; a < 1001; a += 2)
			{
				for (int i = 1; i < bPos.Length; i++)
				{
					for (int j = 0; j < 2; j++)
					{
						int n = 0;
						int sign = (j == 0) ? 1 : -1;
						int aodd = (i % 2 == 0) ? -1 : 0; // Making a even if b is even
						while (Helpers.IsPrime(Math.Abs(n * n + (a + aodd) * n + sign * bPos[i])))
						{
							n++;
						}

						if (n > nMax)
						{
							aMax = a;
							bMax = bPos[i];
							nMax = n;
						}
					}
				}
			}

			return (aMax * bMax);
		}

		/// <summary>
		/// Problem 81
		/// </summary>
		/// <returns></returns>
		internal static long PathSumTwoWays()
		{
			long sum = 0;
			var filename = "D:\\dev\\ProjectEuler\\p081_matrix.txt";
			var matrix = new long[80, 80];

			var numbers = Helpers.ReadLinesFromFile(filename, ',');

			// Load numbers into 80 x 80 array
			var r = 0;
			var c = 0;

			var i = 0;
			while (r < 80)
			{
				while (c < 80)
				{
					matrix[r, c] = long.Parse(numbers[i]);
					i++;
					c++;
				}

				r++;
				c = 0;
			}

			var rMax = matrix.GetUpperBound(0);
			var cMax = matrix.GetUpperBound(1);
			r = 0;
			c = 0;

			sum += matrix[r, c];
			while (r <= rMax || c <= cMax)
			{
				if (r == rMax && c == cMax)
				{
					break;
				}

				if (r == rMax)
				{
					c += 1;
					sum += matrix[r, c];
					continue;
				}

				if (c == cMax)
				{
					r += 1;
					sum += matrix[r, c];
					continue;
				}

				var rTemp = r == rMax ? rMax : r + 1;
				var cTemp = c == cMax ? cMax : c + 1;

				if (matrix[r, cTemp] > matrix[rTemp, c])
				{
					r = rTemp;
				}
				else
				{
					c = cTemp;
				}

				sum += matrix[r, c];
			}

			return sum;
		}

		/// <summary>
		/// Problem 243
		/// </summary>
		/// <returns></returns>
		internal static long Resilience()
		{
			long denominator = 0;

			return denominator;
		}
	}
}

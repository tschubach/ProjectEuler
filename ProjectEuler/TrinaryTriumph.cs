using System;
using System.Linq;
using System.Net.Http.Headers;
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
            var filename = "C:\\source\\repos\\ProjectEuler\\p081_matrix.txt";
            var matrix = new long[80, 80];

            var numbers = Helpers.ReadLinesFromFile(filename, ',');
            int gridSize = matrix.GetLength(0);

            // Load numbers into array
            var r = 0;
            var c = 0;

            var i = 0;
            while (r < gridSize)
            {
                while (c < gridSize)
                {
                    matrix[r, c] = Int64.Parse(numbers[i]);
                    i++;
                    c++;
                }

                r++;
                c = 0;
            }



            //calculate the solution for bottom and right
            for (int k = gridSize - 2; k >= 0; k--)
            {
                matrix[gridSize - 1, k] += matrix[gridSize - 1, k + 1];
                matrix[k, gridSize - 1] += matrix[k + 1, gridSize - 1];
            }

            for (int k = gridSize - 2; k >= 0; k--)
            {
                for (int j = gridSize - 2; j >= 0; j--)
                {
                    matrix[k, j] += Math.Min(matrix[k + 1, j], matrix[k, j + 1]);
                }
            }

            return matrix[0, 0];
        }

        /// <summary>
        /// Problem 243
        /// </summary>
        /// <returns></returns>
        internal static long Resilience()
        {
            // Patterns
            // 1. All prime numbers have an R(p) of 1
            // 2. The first nad last fraction are always resilient
            // 3. All fractions with a prime numerator that is not a factor
            //    of the denominator are resilient
            // 4. Numerators that share no prime factors with the denominator are resilient
            double resilience = 0;
            double rMax = 15499 / 94744;
            var nMax = 15499;
            var dMax = 94744;

            long denominator = 2;

            while (denominator < 1000000000)
            {
                long totient = phi(denominator);
                if ((totient / (denominator - 1)) < (nMax / dMax))
                {
                    break;
                }

                denominator++;
            }

            return denominator;
        }

        /// <summary>
        /// Calculates the totient value of a denominator
        /// the totient value is the number of resilient
        /// fractions that can be formed with the denominator.
        /// A resilient fractions is a proper fractions that cannot
        /// be reduced.
        /// </summary>
        /// <param name="denominator"></param>
        /// <returns>Number of resilient fractions</returns>
	    public static long phi(long denominator)
        {
            // 1. All prime numbers have a resiliency of 1
            // 2. The first and last fraction are always resilient
            // 3. All fractions with a prime numerator that is not a factor
            //    of the denominator are resilient
            // 4. Numerators that share no prime factors with the denominator are resilient
            long count = 1;

            if (!Helpers.IsPrime(denominator))
            {
                var denPrimes = Helpers.PrimeFactors(denominator);
                count = 2;  // First and last fractions are always resilient
                
                for (int i = 2; i < denominator - 1; i++)
                {
                    if (denominator % i != 0) // Numerator is not a factor of the denominator
                    {
                        var numPrimes = Helpers.PrimeFactors(i);
                        if (!denPrimes.Any(p => numPrimes.Contains(p)))  // Prime factors of numerator and denominator are unique
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using ProjectEuler.Utilities;

namespace ProjectEuler
{
<<<<<<< HEAD
	class Program
	{
		public static void Main(string[] args)
		{
			Stopwatch clock = Stopwatch.StartNew();

			try
			{
				Problem121();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			finally
			{
				clock.Stop();
				Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
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


			Console.WriteLine("There are {0} positive outcomes out of {1}", positive, total);
			Console.WriteLine("This gives a prize allocation of {0}", total / positive);
		}
	}
=======
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("56003: '" + GetDigitMask(56003) + "'");
                //Console.WriteLine("50003: '" + GetDigitMask(50003) + "'");
                //Console.WriteLine("56003448: '" + GetDigitMask(56003448) + "'");
                PrimeDigitReplacements();
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

            // foreach, create mask based on duplicated digit:
            //    - Digit can only appear twice
            // find mask that is duplicated eight times

            for (int i = 56009; i < 1000000; i++)
            {
                if (Helpers.IsPrime(i))
                {
                    var mask = GetDigitMask(i);
                    if (mask != "")
                    {
                        testList.Add(mask);
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

            long result = 0;

            for (int i = 0; i < 10; i++)
            {
                var candidate = long.Parse(temp.Replace(".", i.ToString()));
                if (Helpers.IsPrime(candidate))
                {
                    result = candidate;
                    break;
                }
            }

            clock.Stop();
            Console.WriteLine("Smallest of prime digit replacement octet: {0}", result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
        }

        private static string GetDigitMask(int num)
        {
            int[] arr = new int[10];

            var temp = num;
            while (temp > 0)
            {
                arr[temp % 10]++;
                temp /= 10;
            }

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
    }
>>>>>>> 907557bef77e1344eaa59df5e584b1db2048fb79
}

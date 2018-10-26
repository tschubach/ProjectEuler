using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Answer: \n" + SquareDigitChains());
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

        private static int SquareDigitChains()
        {
            var result = 0;

            for (int i = 2; i < 10000000; i++)
            {
                long next = i;
                while (next != 89 && next != 1)
                {
                    long temp = 0;
                    foreach (var item in Utilities.DigitArray(next))
                    {
                        temp += (item * item);
                    }

                    next = temp;
                }

                if (next == 89)
                {
                    result++;
                }
            }

            return result;
        }

        private static string PrimePermutations()
        {
            var result = "";
            var primes = Prime.NDigitPrimes(4);
            var primePerms = new List<long>();
            var count = 0;
            var temp = "";

            primes.Sort();

            for (int i = 1001; i < 10000; i++)
            {
                if (i == 1487 || i == 4817 || i == 8147 || !primes.Contains(i))
                {
                    continue;
                }

                var maxStep = (int)((10000 - i) / 2);
                var step = 0;
                while (step <= maxStep)
                {
                    step++;
                    var prime1 = i + step;
                    var prime2 = i + (step * 2);

                    if (!primes.Contains(prime1) || !primes.Contains(prime2))
                    {
                        continue;
                    }

                    if (!Utilities.IsPermutation(i, prime1) || !Utilities.IsPermutation(i, prime2))
                    {
                        continue;
                    }

                    // If we get here, we've found the answer
                    result = i.ToString() + prime1.ToString() + prime2.ToString();

                    break;
                } // end while

                if (result.Length > 0)
                {
                    break;
                }

            } // end for

            return result;
        }
    }
}

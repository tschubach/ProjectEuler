using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using ProjectEuler.Utilities;
using ProjectEuler.Archive;
using System.Numerics;

namespace ProjectEuler
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var maxVal = (BigInteger)Math.Pow(10, 25);
                var powersOfTwo = PowersOfTwo.GetPowersOfTwo(1);

                // Displaying the output when 
                // the bit is '1' in binary 
                // equivalent of number. 
                List<int> powerList = powersOfTwo.ToList();
                var powersOfTwoSums = new List<string>();
                powersOfTwoSums.Add(CreateDelimitedString(powerList, ","));

                foreach (var item in powersOfTwoSums)
                {
                    Console.Write(item);
                }

                //foreach (var item in powerList)
                //{
                //    var tempList = new List<int>();
                //    if (item % 2 == 0)
                //    {
                //        foreach (var val in PowersOfTwo.GetPowersOfTwo(item))
                //        {
                //            tempList.Add(val);
                //        }
                //    }
                //    else
                //    {
                //        tempList.Add(item);
                //    }
                //}

                Console.WriteLine();
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

        private static string CreateDelimitedString(List<int> powerList, string delimiter)
        {
            var result = new StringBuilder();
            for (int i = 0; i < powerList.Count(); i++)
            {
                if (powerList[i] == 1)
                {
                    result.Append(i);

                    if (i != powerList.Count() - 1)
                        result.Append(delimiter);
                }
            }

            return result.ToString();
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
            var testDictionary = new SortedDictionary<string, int>();

            for (int i = 56004; i < 1000000; i++)
            {
                if (Helpers.IsPrime(i))
                {
                    var primeArray = i.ToString().ToCharArray();
                    var upperLimit = Math.Pow(2, primeArray.Length);
                    for (byte b = 1; b < upperLimit; b++)
                    {
                        var mask = Convert.ToString(b, 2)
                                          .PadLeft(primeArray.Length, '0')
                                          .ToCharArray();

                        var maskedVal = new StringBuilder();
                        for (int j = 0; j < mask.Length; j++)
                        {
                            maskedVal.Append(mask[j] == '0' ? '.' : primeArray[j]);
                        }

                        if (!testDictionary.ContainsKey(maskedVal.ToString()))
                        {
                            testDictionary.Add(maskedVal.ToString(), 0); ;
                        }

                        testDictionary[maskedVal.ToString()]++;
                    }
                }
            }

            var results = new List<int>();
            foreach (var item in testDictionary.Where(d => d.Value >= 8))
            {
                var candidate = item.Key;

                int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    var test = int.Parse(candidate.Replace(".", i.ToString()));
                    if (test > 56009 && test.ToString().Length == candidate.Length)
                    {
                        if (Helpers.IsPrime(test))
                        {
                            count++;
                            results.Add(test);
                        }
                    }
                }

                if (count >= 8)
                {
                    break;
                }
                results.Clear();
            }

            results.Sort();

            clock.Stop();
            Console.WriteLine("Smallest prime digit replacement octet: {0}", results[0]);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
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

        public static int[] DigitsToArray(int n)
        {
            var result = new int[numDigits(n)];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = n % 10;
                n /= 10;
            }
            return result;
        }

        private static void Problem144()
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

                //Take the solution which is furthest from x0
                xO = (Math.Abs(ans1 - xO) > Math.Abs(ans2 - xO)) ? ans1 : ans2;
                yO = slopeB * xO + interceptB;

                result++;
            }

            clock.Stop();
            Console.WriteLine("The beam will reflect {0} times", result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
        }

        private static void ReplaceWithCharAtIndex(List<string> list, string value, char replacement, int index)
        {
            var temp = "";

            for (int i = 0; i < value.Length; i++)
            {
                temp += i == index ? '*' : value[i];
            }

            if (!list.Contains(temp))
            {
                list.Add(temp);
            }

            var start = index + 1;
            for (int i = start; i < value.Length; i++)
            {
                ReplaceWithCharAtIndex(list, temp, replacement, start);
            }
        }
    }
}

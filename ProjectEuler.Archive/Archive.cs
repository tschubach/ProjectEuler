using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using ProjectEuler.Utilities;

namespace ProjectEuler.Archive
{
    internal sealed class Archive
    {
        /// <summary>
        /// Find the unique positive integer whose square has the form 1_2_3_4_5_6_7_8_9_0,
        /// where each “_” is a single digit.
        /// </summary>
        /// <returns></returns>
        private static ulong Problem206()
        {
            // Assertions:
            // 1. From the given pattern, the square ends in zero, which means the square root must be a multiple of 10,
            //    making the last 3 digits of the resulting square '900'.
            // 2. The square must be a number whose second-to-last digit squares to a value ending in 9.  The only 2 numbers
            //    whose squares end in 9 are 3 (square = 9), and 7 (square = 49).  Therefore, we only need to concentrate
            //    on those numbers whose value ends in 30 or 70.
            // 3. For the pattern given and assertion 1, the min and max possible values are
            //    1020304050607080900 and 192939495969798900.  This makes the min and max roots
            //    1010101010 and 1389026632.
            // 4. Based on the previous assertions, the min and max feasible square roots are 1010101030 and 1389026630

            ulong result = 0;
            Regex pattern = new Regex("1.2.3.4.5.6.7.8.900");

            // Loop through possible square roots, starting with the max feasible value.
            for (ulong root = 1389026630; root >= 1010101030; root -= 10)
            {
                ulong test = root * root;

                if (pattern.Match(test.ToString()).Success)
                {
                    result = root;

                    break;
                }
            }

            return result;

        }

        private static int EvenFibonacci()
        {
            int result = 0;
            List<int> series = new List<int>
            {
                1, 2
            };

            for (int i = 2; i < 4000000; i++)
            {
                var nextValue = series[i - 1] + series[i - 2];
                if (nextValue >= 4000000)
                {
                    break;
                }

                series.Add(nextValue);
            }

            for (int i = 0; i < series.Count; i++)
            {
                if (series[i] % 2 == 0)
                {
                    result += series[i];
                }
            }

            return result;
        }

        private static int IndexOfFirstFibonacciTerm(int length)
        {
            var testValue = BigInteger.Pow(10, 999);

            BigInteger term1 = 89;
            BigInteger term2 = 144;

            var index = 12;
            var nextValue = term1 + term2;
            while (nextValue < testValue)
            {
                nextValue = term2 + term1;
                term1 = term2;
                term2 = nextValue;
                index++;
            }

            return index;
        }

        private static string LargestPalindrome()
        {
            int result = 0;
            int p = 990;
            int q = 999;

            for (p = 990; p > 99; p--)
            {
                for (q = 999; q > 99; q--)
                {
                    int test = p * q;

                    if (result < test && Helpers.IsPalindrome(test))
                    {
                        result = test;

                        break;
                    }
                    else if (test < result)
                    {
                        break;
                    }
                }
            }

            return "p: " + p.ToString() + "; q: " + q.ToString() + "; palindrome: " + result;
        }

        private static int SmallestDivisibleBy20()
        {
            int result = 0;
            int lower = 380;
            bool isSmallest = false;

            while (!isSmallest)
            {
                var isDivisible = true;
                for (int j = 19; j > 2; j--)
                {
                    int test = lower % j;

                    if (test != 0)
                    {
                        isDivisible = false;
                        lower += 20;

                        break;
                    }
                }

                if (isDivisible)
                {
                    isSmallest = true;
                    result = lower;
                }
            }

            return result;
        }

        private static int SumOfSquaresDiff()
        {
            int sumOfSquares = SumOfSquares(100);
            int squareofSums = SquareOfSums(100);

            return Math.Abs(sumOfSquares - squareofSums);
        }

        private static int SumOfSquares(int max)
        {
            int sum = 0;

            for (int i = 1; i <= max; i++)
            {
                sum += i * i;
            }

            return sum;

        }

        private static int SquareOfSums(int max)
        {
            int sqr = 0;

            for (int i = 1; i <= max; i++)
            {
                sqr += i;
            }

            return (sqr * sqr);
        }

        /// <summary>
        ///
        /// Problem 9: For the given 1000 digit number, find the
        /// 13 consecutive digits that have the largest product
        /// </summary>
        /// <returns></returns>
        private static ulong LargestProductOf13()
        {
            ulong result = 0;
            ulong temp = 1;
            int group = 13;
            var digits = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

            for (var i = 0; i < (digits.Length - (@group - 1)); i++)
            {
                temp = 1;
                var test = digits.Substring(i, @group);
                for (var j = 0; j < @group; j++)
                {
                    temp *= (ulong)(test[j] - '0');

                    if (temp > result)
                    {
                        result = temp;
                    }
                }
            }

            //for (int i = 0; i < results.Count; i++)
            //{
            //    Console.WriteLine(results[i].ToString());
            //}

            Console.WriteLine("");

            return result;
        }

        private static long RoutesThroughGrid(int gridSize)
        {
            // Combinatorics
            long paths = 1;

            for (int i = 0; i < gridSize; i++)
            {
                paths *= (2 * gridSize) - i;
                paths /= i + 1;
            }

            //// Dynamic Programming
            //long[,] grid = new long[gridSize + 1, gridSize + 1];

            //// Initialise the grid with boundary conditions
            //for (int i = 0; i < gridSize; i++)
            //{
            //	grid[i, gridSize] = 1; grid[gridSize, i] = 1;
            //}

            //for (int i = gridSize - 1; i >= 0; i--)
            //{
            //	for (int j = gridSize - 1; j >= 0; j--)
            //	{
            //		grid[i, j] = grid[i + 1, j] + grid[i, j + 1];
            //	}
            //}

            //paths = grid[0, 0];

            return paths;
        }

        private static int MaximumPathSum()
        {
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\p067_triangle.txt";
            int[,] inputTriangle = Helpers.ReadInput(filename);
            int lines = inputTriangle.GetLength(0);

            for (int i = lines - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    inputTriangle[i, j] += Math.Max(inputTriangle[i + 1, j], inputTriangle[i + 1, j + 1]);
                }
            }

            return inputTriangle[0, 0];
        }

        private static int CountingSundays()
        {
            // Count the number of times the first day of the month fell on a Sunday
            // between 1 Jan 1900 and 31 Dec 2000
            int numSundays = 0;

            int day = 1;

            for (int y = 1901; y <= 2000; y++)
            {
                for (int m = 1; m <= 12; m++)
                {
                    var fom = new DateTime(y, m, day);
                    if (fom.DayOfWeek == DayOfWeek.Sunday)
                    {
                        numSundays++;
                    }
                }
            }

            return numSundays;
        }

        private static long NameScores()
        {
            long total = 0;
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\p022_names.txt";
            var names = Helpers.ReadLinesFromFile(filename, ',').ToList();

            names.Sort();

            for (var i = 0; i < names.Count; i++)
            {
                total += (WordScore(names[i]) * (i + 1));
            }

            return total;
        }

        private static long WordScore(string name)
        {
            long score = 0;
            foreach (var letter in name)
            {
                int asciiValue = (int)letter;
                if (asciiValue < 65 || asciiValue > 122)
                {
                    continue;
                }

                var value = (int)letter - 64;
            }

            return score;
        }

        private static long NonAbundantSums()
        {
            // Get sum of all positive integers which cnnot be written as the sum of two abundant numbers
            // 12 - Smallest abundant number
            // 28123 - Upper limit of integers that cannot be written as the sum of two abundant numbers

            var limit = 28123;
            var abundant = new List<int>();
            var total = 0;
            long[] primeList = Helpers.ESieve((long)Math.Sqrt(limit));

            // Get list of abundant numbers between 12 and 28123 (inclusive)
            for (int i = 2; i <= limit; i++)
            {
                if (Helpers.SumOfFactorsPrime(i, primeList) > i)
                {
                    abundant.Add(i);
                }
            }

            // Make all the sums of two abundant numbers
            bool[] canBeWrittenasAbundant = new bool[limit + 1];
            for (int i = 0; i < abundant.Count; i++)
            {
                for (int j = i; j < abundant.Count; j++)
                {
                    if (abundant[i] + abundant[j] <= limit)
                    {
                        canBeWrittenasAbundant[abundant[i] + abundant[j]] = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //Sum the numbers which are not sums of two abundant numbers
            for (int i = 1; i <= limit; i++)
            {
                if (!canBeWrittenasAbundant[i])
                {
                    total += i;
                }
            }

            return total;
        }

        private static long AmicableNumbers(int upperLimit)
        {

            long sumAmicable = 0;
            long[] primeList = Helpers.ESieve((long)Math.Sqrt(upperLimit) + 1);

            for (int i = 2; i <= upperLimit; i++)
            {
                var factors1 = Helpers.SumOfFactorsPrime(i, primeList);
                if (factors1 > i && factors1 <= upperLimit)
                {
                    var factors2 = Helpers.SumOfFactorsPrime(factors1, primeList);
                    if (factors2 == i)
                    {
                        sumAmicable += i + factors1;
                    }
                }
            }

            return sumAmicable;
        }

        private static string RepeatingDecimal(int numerator, int denominator)
        {

            int sequenceLength = 0;
            int dee = 0;

            for (int i = 1000; i > 1; i--)
            {
                dee = i;
                if (sequenceLength >= i)
                {
                    dee = i + 1;

                    break;
                }

                int[] foundRemainders = new int[i];
                int value = 1;
                int position = 0;

                while (foundRemainders[value] == 0 && value != 0)
                {
                    foundRemainders[value] = position;
                    value *= 10;
                    value %= i;
                    position++;
                }

                if (position - foundRemainders[value] > sequenceLength)
                {
                    sequenceLength = position - foundRemainders[value];
                }
            }

            var result = String.Format("d: {0}, Sequence Length: {1}", dee, sequenceLength);

            return result;

        }

        private static int DistinctPowers()
        {
            var powers = new List<double>();

            for (double a = 2; a < 101; a++)
            {
                for (double b = 2; b < 101; b++)
                {
                    var power = Math.Pow(a, b);
                    if (!powers.Contains(power))
                    {
                        powers.Add(power);
                    }
                }
            }

            return powers.Count;
        }

        private static int DigitFifthPowers()
        {
            int result = 0;

            for (int i = 2; i < 355000; i++)
            {
                int sumOfPowers = 0;
                int number = i;
                while (number > 0)
                {
                    int d = number % 10;
                    number /= 10;

                    int temp = d;
                    for (int j = 1; j < 5; j++)
                    {
                        temp *= d;
                    }

                    sumOfPowers += temp;
                }

                if (sumOfPowers == i)
                {
                    result += i;
                }
            }

            return result;
        }

        private static long SumOfPrimes(int value)
        {
            long result = 0;

            for (int i = 2; i < value; i++)
            {
                if (Helpers.IsPrime(i))
                {
                    result += i;
                }
            }

            return result;
        }

        private static int NthPrime(int max)
        {
            int numPrimes = 1;
            int numm = 1;

            while (numPrimes < max)
            {
                numm = numm + 2;
                if (Helpers.IsPrime(numm))
                {
                    numPrimes++;
                }
            }

            return numm;
        }

        private static int HighlyDivisibleTriangle(int numDivisors)
        {
            var result = 0;
            var number = 7;
            var triangle = 28;

            while (true)
            {
                var divisors = 0;
                triangle += (++number);

                for (int i = 1; i <= triangle; i++)
                {
                    if (triangle % i == 0)
                    {
                        divisors++;
                    }
                }

                if (divisors > numDivisors)
                {
                    result = triangle;

                    break;
                }
            }

            return result;
        }

        private static int CoinSums()
        {
            int target = 200;
            int[] coinSizes =
            {
                1, 2, 5, 10, 20, 50, 100, 200
            };

            int[] ways = new int[target + 1];
            ways[0] = 1;

            for (int i = 0; i < coinSizes.Length; i++)
            {
                for (int j = coinSizes[i]; j <= target; j++)
                {
                    ways[j] += ways[j - coinSizes[i]];
                }
            }

            return ways[ways.GetUpperBound(0)];
        }

        private static int PandigitalProducts()
        {
            var products = new List<int>();
            var total = 0;

            for (int i = 1; i < 9999; i++)
            {
                for (int j = 1; j < 9999; j++)
                {
                    var product = i * j;
                    if (!IsPandigitalProduct(i, j, product))
                    {
                        continue;
                    }

                    if (!products.Contains(product))
                    {
                        products.Add(product);
                    }
                }
            }

            foreach (var prod in products)
            {
                total += prod;
            }

            return total;
        }

        private static bool IsPandigitalProduct(int multiplicand, int multiplier, int product)
        {
            var allDigits = multiplicand.ToString() + multiplier.ToString() + product.ToString();

            if (allDigits.Length != 9 || (allDigits.Contains("0")))
            {
                return false;
            }

            var digitArray = new string[9];
            for (int i = 0; i < 9; i++)
            {
                var digit = allDigits[i].ToString();
                for (int j = 0; j < digitArray.Length; j++)
                {
                    if (digitArray[j] == digit)
                    {
                        return false;
                    }

                    digitArray[i] = digit;
                }
            }

            ;

            return true;
        }

        private static int[] DigitsToArray(int n)
        {
            var numDigits = n.ToString().Length;
            var result = new int[numDigits];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = n % 10;
                n /= 10;
            }

            return result;
        }

        private static long DigitCancellingFractions()
        {
            var fractions = new List<Fraction>();

            for (int i = 10; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    continue;
                }

                for (int j = 10; j < 100; j++)
                {
                    if (j % 10 == 0)
                    {
                        continue;
                    }

                    if (i < j)
                    {
                        int? digit = CommonDigit(i, j);
                        if (digit.HasValue && digit.Value != 0)
                        {
                            double expected = (double)i / (double)j;
                            var iPrime = (double)RemoveDigit(i.ToString(), digit.Value);
                            var jPrime = (double)RemoveDigit(j.ToString(), digit.Value);

                            if (iPrime / jPrime == expected)
                            {
                                fractions.Add(new Fraction(i, j, digit.Value));
                            }
                        }
                    }
                }
            }

            var numerator = 1;
            var denominator = 1;
            foreach (var fraction in fractions)
            {
                numerator *= fraction.Numerator;
                denominator *= fraction.Denominator;
            }

            if (denominator % numerator == 0)
            {
                return denominator / numerator;
            }

            return denominator / MaxCommonFactor(numerator, denominator);

        }

        private static long MaxCommonFactor(int numerator, int denominator)
        {
            if (denominator % numerator == 0)
            {
                return numerator;
            }

            var numFactors = Helpers.PrimeFactors(numerator).ToList();
            var denomFactors = Helpers.PrimeFactors(denominator).ToList();
            long maxFactor = 1;

            for (int i = denomFactors.Count - 1; i >= 0; i--)
            {
                for (int j = numFactors.Count - 1; j >= 0; j--)
                {
                    if (denomFactors[i] == numFactors[j])
                    {
                        maxFactor = (denomFactors[i] > maxFactor) ? denomFactors[i] : maxFactor;
                    }
                }
            }

            return maxFactor;
        }

        private static int? CommonDigit(int value1, int value2)
        {
            var count = 0;
            var value1Str = value1.ToString();
            var value2Str = value2.ToString();
            int? digit = null;

            for (int i = 0; i < value1Str.Length; i++)
            {
                for (int j = 0; j < value2Str.Length; j++)
                {
                    if (value1Str[i] == value2Str[j])
                    {
                        count++;
                        digit = (int)(value2Str[j] - '0');
                    }
                }
            }

            return (count == 1) ? digit : null;
        }

        private static int RemoveDigit(string value, int digit)
        {
            var newValue = value.Replace(digit.ToString(), "");

            return int.Parse(newValue);
        }

        private static int CircularPrimes(int upper)
        {
            var circularPrimes = new List<int>();

            for (int i = 2; i < upper; i++)
            {

                if (!circularPrimes.Contains(i))
                {
                    if (IsCircularPrime(i))
                    {
                        circularPrimes.Add(i);
                    }
                }
            }

            return circularPrimes.Count;
        }

        private static bool IsCircularPrime(int value)
        {
            if (value.ToString().IndexOf("0") != -1)
            {
                return false;
            }

            var rotations = Helpers.Rotations(value);

            foreach (var item in rotations)
            {
                if (!Helpers.IsPrime(item))
                {
                    return false;
                }
            }

            return true;
        }

        private static int DoubleBasePalindromes(int upper)
        {
            var palindromes = new List<int>();
            var sum = 0;

            for (int i = 1; i < upper; i += 2)
            {
                if (Helpers.IsPalindrome(i.ToString()))
                {
                    var base2 = Helpers.IntToBase(i, 2);
                    if (Helpers.IsPalindrome(base2))
                    {
                        palindromes.Add(i);
                    }
                }
            }

            for (int i = 0; i < palindromes.Count; i++)
            {
                sum += palindromes[i];
            }

            return sum;
        }

        private static long[] TruncatablePrimes()
        {
            // Skip single-digit numbers
            // No even numbers other than 2 at beginning or end
            // No numbers divisible by 10 or 25
            // No numbers that begin or end with 1 or 9
            // There are only 11 primes that qualify, so stop after finding these

            bool isTruncatable = true;
            var count = 0;
            var maxCount = 11;
            var truncatablePrimes = new List<long>();

            long num = 23;
            var loopCtr = 0;
            while (count < maxCount)
            {
                isTruncatable = true;

                var truncValue = num;
                var modValue = num;
                var numString = num.ToString();
                var firstDigit = int.Parse(numString.Substring(0, 1));
                var lastDigit = int.Parse(numString.Substring(numString.Length - 1, 1));

                if (num % 25 == 0 || num % 10 == 0 || num % 2 == 0)
                {
                    num += 2;

                    continue;
                }

                if (firstDigit == 1 || lastDigit == 1)
                {
                    num += 2;

                    continue;
                }

                if (Helpers.IsPrime(num))
                {
                    // Run the number through 2 loops - one to successively remove digits from right-to-left,
                    // checking if the result is prime; the other to remove digits from left-to-right
                    //    n / 10 - remove digits from right to left
                    //    n % 10 - remove digits from left to right
                    // If any pass fails the prime test, continue to next integer
                    var digits = Helpers.NumDigits(modValue);
                    truncValue = truncValue / 10;
                    modValue = modValue % (int)(Math.Pow(10, digits - 1));
                    while (truncValue != 0 && modValue != 0)
                    {
                        if (!Helpers.IsPrime(truncValue) || !Helpers.IsPrime(modValue))
                        {
                            isTruncatable = false;

                            break;
                        }

                        digits = Helpers.NumDigits(modValue);
                        truncValue = truncValue / 10;
                        modValue = (modValue < 10) ? 0 : modValue % (int)(Math.Pow(10, digits - 1));
                    }

                    if (isTruncatable)
                    {
                        truncatablePrimes.Add(num);
                        count++;
                        Console.WriteLine(num.ToString() + ": " + count.ToString());
                    }
                }

                if (count == 11)
                {
                    break;
                }

                num += 2;
                loopCtr++;
            }

            return truncatablePrimes.ToArray();
        }

        private static long PandigitalMultiples()
        {
            int result = 0;

            for (int i = 9387; i >= 9234; i--)
            {
                var test = Helpers.Concatenate(i, 2 * i);
                if (Helpers.IsPandigital(test) && test > result)
                {
                    result = test;
                }
            }

            return result;
        }

        private static ulong PentagonNumbers(int terms)
        {
            ulong diff = (ulong)(terms * ((3 * terms) - 1)) / 2;
            var pentagonNums = new List<ulong>();

            for (ulong i = 1; i <= (ulong)terms; i++)
            {
                pentagonNums.Add((i * ((3 * i) - 1)) / 2);
            }

            for (int h = 0; h < pentagonNums.Count; h++)
            {
                for (int i = h + 1; i < pentagonNums.Count; i++)
                {
                    var testSum = pentagonNums[i] + pentagonNums[h];
                    var testDiff = pentagonNums[i] - pentagonNums[h];

                    if (pentagonNums.Contains(testSum) && pentagonNums.Contains(testDiff))
                    {
                        if (testDiff < diff)
                        {
                            diff = testDiff;
                        }
                    }
                }
            }

            return diff;
        }

        private static ulong Problem45()
        {
            ulong result = 0;

            var triangles = Helpers.TriangleSeries(1000000).ToList();
            var pentagons = Helpers.PentagonSeries(1000000).ToList();
            var hexagons = Helpers.HexagonSeries(1000000).ToList();

            for (int i = 285; i < triangles.Count; i++)
            {
                ulong triangle = triangles[i];
                var pTerm = pentagons.IndexOf(triangle);
                var hTerm = hexagons.IndexOf(triangle);

                if (pentagons.Contains(triangle) && hexagons.Contains(triangle))
                {
                    result = triangle;

                    break;
                }
            }

            return result;
        }

        private static int Problem46()
        {
            var result = 0;
            var next = 33;
            var counter = 0;

            while (result != next)
            {
                var isGoldbach = false;
                next += 2;
                counter++;

                if (!Helpers.IsPrime(next))
                {
                    foreach (var prime in Helpers.Primes(next))
                    {
                        if ((next - prime) % 2 == 0)
                        {
                            var square = (next - prime) / 2;
                            if ((Math.Sqrt(square)) % 1 == 0)
                            {
                                isGoldbach = true;

                                break;
                            }
                        }
                    }

                    if (!isGoldbach)
                    {
                        result = next;

                        break;
                    }
                }
            }

            return result;
        }

        private static List<long> DistinctPrimeFactors(int run)
        {
            var distinct = new List<long>();
            long number = 2;
            var count = 0;

            while (count < run)
            {
                if (Helpers.PrimeFactors(number).ToList().Count == run)
                {
                    if (distinct.Count != 0)
                    {
                        if (distinct[count - 1] != (number - 1))
                        {
                            distinct.Clear();
                            count = 0;
                        }
                    }

                    distinct.Add(number);
                    count++;
                }

                number++;
            }

            distinct.Sort();

            return distinct;
        }

        private static string SelfPowers()
        {
            BigInteger result = 10405071317;

            for (int i = 11; i <= 1000; i++)
            {
                result += Helpers.SelfPower(i);
            }

            int len = result.ToString().Length;

            return result.ToString().Substring(len - 10);
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
                    foreach (var item in Helpers.DigitArray(next))
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

                    if (!Helpers.IsPermutation(i, prime1) || !Helpers.IsPermutation(i, prime2))
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
